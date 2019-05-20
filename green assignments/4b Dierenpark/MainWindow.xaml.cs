using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text.RegularExpressions;
using System.Timers;
using System.Threading;
using System.Globalization;

namespace _4b_Dierenpark
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private readonly BinaryFormatter Formatter = new BinaryFormatter();
        public List<Familie> Families = new List<Familie> { };
        public readonly string DATA_FILENAME = "Personen.dat";
        public MainWindow()
        {
            InitializeComponent();
            LoadFromFile();
            DataGrid1.CanUserSortColumns = false;
            DataGrid1.CanUserResizeRows = false;
            DataGrid1.CanUserResizeColumns = false;
            DataGrid1.IsReadOnly = true;
            DataGrid2.CanUserSortColumns = false;
            DataGrid2.CanUserResizeRows = false;
            DataGrid2.CanUserResizeColumns = false;
            DataGrid2.IsReadOnly = true;

            Peildatum.Text = DateTime.Today.ToShortDateString();
            foreach (Familie familie in Families)
                familie.Herbereken(DateTime.Parse(Peildatum.Text));
            DataGrid1.Items.Refresh();
        }

        private void LoadFromFile()
        {
            DataGrid1.ItemsSource = Families;
            if (!File.Exists(DATA_FILENAME))
                return;

            try
            {
                FileStream VerhuringenBestand = new FileStream(DATA_FILENAME, FileMode.Open, FileAccess.Read);
                Families = (List<Familie>)Formatter.Deserialize(VerhuringenBestand);
                VerhuringenBestand.Close();
                DataGrid1.ItemsSource = Families;
            }
            catch (Exception err)
            {
                MessageBox.Show(err.Message);
            }
        }

        private void SaveToFile()
        {
            try
            {
                FileStream VerhuringenBestand =
                    new FileStream(DATA_FILENAME, FileMode.OpenOrCreate, FileAccess.Write);

                Formatter.Serialize(VerhuringenBestand, Families);

                VerhuringenBestand.Close();
            }
            catch (Exception err)
            {
                MessageBox.Show(err.Message);
            }
        }
        private void TestTextBox(TextBox textbox, string pattern = "[^a-zA-Z ]")
        {
            if (!Regex.IsMatch(textbox.Text, pattern))
                return;

            int caretIndex = textbox.CaretIndex - 1;
            textbox.Text = Regex.Replace(textbox.Text, pattern, "");
            textbox.CaretIndex = Math.Min(0, caretIndex);
        }

        [Serializable]
        public class Familie
        {
            public string Achternaam { get; set; }
            public int Kinderen { get; set; }
            public string Bijdrage { get; set; }
            public List<Persoon> Personen { get; set; }
            public Familie(string achternaam, int kinderen, double bijdrage)
            {
                Achternaam = achternaam;
                Kinderen = kinderen;
                Bijdrage = string.Format("€{0:N2}", bijdrage);
                Personen = new List<Persoon> { };
            }

            public void Herbereken(DateTime peildatum)
            {
                double bijdrage = Kinderen * 11 - 1;
                if (Personen.Count == 0)
                {
                    Bijdrage = string.Format("€{0:N2}", bijdrage);
                    return;
                }

                int bejaarden = 0;
                foreach (Persoon persoon in Personen)
                {
                    if ((peildatum - DateTime.Parse(persoon.Geboortedatum)).Days > 365.25 * 65)
                        bejaarden++;
                }

                if (bejaarden == 0)
                {
                    if (Personen.Count == 1)
                        bijdrage += 30;
                    else
                        bijdrage += 61;
                }
                else
                {
                    if (Personen.Count == 1)
                        bijdrage += 26;
                    else
                        bijdrage += 65;
                }

                Bijdrage = string.Format("€{0:N2}", bijdrage);
            }
        }

        [Serializable]
        public class Persoon
        {
            public string Naam { get; set; }
            public string Geboortedatum { get; set; }
            public Persoon(string naam, DateTime geboortedatum)
            {
                Naam = naam;
                Geboortedatum = geboortedatum.ToShortDateString();
            }
        }

        private void KinderenSlider_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            KinderenLabel.Content = "Kinderen: " + KinderenSlider.Value.ToString();
        }

        private void FamilieNaam_TextChanged(object sender, TextChangedEventArgs e)
        {
            TestTextBox(FamilieNaam);
        }


        private void DataGrid1_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (DataGrid1.SelectedIndex == -1)
                return;

            DataGrid2.ItemsSource = ((Familie)DataGrid1.SelectedItem).Personen;
            DataGrid2.Items.Refresh();
        }

        private void PersoonNaam_TextChanged(object sender, TextChangedEventArgs e)
        {
            TestTextBox(PersoonNaam);
        }
        private void VoegFamilieToeButton_Click(object sender, RoutedEventArgs e)
        {
            if (FamilieNaam.Text.Trim().Length < 2)
            {
                MessageBox.Show("Familienaam is te kort");
                return;
            }
            Familie familie = new Familie(
                FamilieNaam.Text.Trim(),
                (int)KinderenSlider.Value,
                0
            );
            familie.Herbereken(DateTime.Parse(Peildatum.Text));
            Families.Add(familie);
            DataGrid1.SelectedItem = familie;
            DataGrid1.Items.Refresh();
            SaveToFile();
        }

        private void VoegPersoonToeButton_Click(object sender, RoutedEventArgs e)
        {
            if (DataGrid1.SelectedIndex == -1)
                return;

            if (!DateTime.TryParse(GeboorteDatumPicker.Text, out DateTime geboortedatum))
                return;

            Familie familie = (Familie)DataGrid1.SelectedItem;
            List<Persoon> personen = familie.Personen;
            if (personen.Count > 1)
            {
                MessageBox.Show("Niet meer dan 2 volwassenen toegestaan per familie");
                return;
            }

            personen.Add(new Persoon(PersoonNaam.Text, geboortedatum));
            familie.Herbereken(DateTime.Parse(Peildatum.Text));
            DataGrid1.Items.Refresh();
            DataGrid2.Items.Refresh();
            SaveToFile();
        }

        private void VerwijderFamilieButton_Click(object sender, RoutedEventArgs e)
        {
            if (DataGrid1.SelectedIndex == -1)
                return;

            foreach (Familie familie in DataGrid1.SelectedItems)
                Families.Remove(familie);
            DataGrid1.SelectedIndex = -1;
            DataGrid1.Items.Refresh();


            DataGrid2.SelectedIndex = -1;
            DataGrid2.ItemsSource = new List<Persoon> { };
            DataGrid2.Items.Refresh();
            SaveToFile();
        }

        private void VerwijderPersoonButton_Click(object sender, RoutedEventArgs e)
        {
            if (DataGrid1.SelectedIndex == -1)
                return;
            if (DataGrid2.SelectedIndex == -1)
                return;

            Familie familie = (Familie)DataGrid1.SelectedItem;
            familie.Personen.Remove((Persoon)DataGrid2.SelectedItem);
            DataGrid2.SelectedIndex = -1;
            DataGrid2.Items.Refresh();

            familie.Herbereken(DateTime.Parse(Peildatum.Text));
            DataGrid1.Items.Refresh();
            SaveToFile();
        }

        private void Peildatum_CalendarClosed(object sender, RoutedEventArgs e)
        {
            foreach (Familie familie in Families)
                familie.Herbereken(DateTime.Parse(Peildatum.Text));
            DataGrid1.Items.Refresh();
        }
    }
}
