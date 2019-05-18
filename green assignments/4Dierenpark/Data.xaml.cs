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

namespace _4Dierenpark
{
    public partial class Data : UserControl
    {
        private readonly BinaryFormatter Formatter = new BinaryFormatter();
        private readonly string DATA_FILENAME = "GezinData.dat";
        internal List<Gezin> Gezinnen { get; set; } = new List<Gezin> { };

        public Data()
        {
            InitializeComponent();
            LoadFromFile();
            PeildatumPicker.Text = DateTime.Now.ToShortDateString();
            HerberekenAlles();
            DataGridXML.CanUserSortColumns = false;
            DataGridXML.CanUserResizeRows = false;
            DataGridXML.CanUserResizeColumns = false;
            DataGridXML.IsReadOnly = true;
        }

        private void LoadFromFile()
        {
            if (!File.Exists(DATA_FILENAME))
            {
                DataGridXML.ItemsSource = Gezinnen;
                return;
            }

            try
            {
                FileStream VerhuringenBestand = new FileStream(DATA_FILENAME, FileMode.Open, FileAccess.Read);
                Gezinnen = (List<Gezin>)Formatter.Deserialize(VerhuringenBestand);
                VerhuringenBestand.Close();
                DataGridXML.ItemsSource = Gezinnen;
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

                Formatter.Serialize(VerhuringenBestand, Gezinnen);

                VerhuringenBestand.Close();
            }
            catch (Exception err)
            {
                ErrorMessage(err);
            }
        }

        private void ErrorMessage(Exception err)
        {
            MessageBox.Show("ERROR:\n\n" + err.Message);
        }

        private void Herbereken(Gezin gezin)
        {
            if (gezin.Volwassenen.Count == 0)
            {
                gezin.Prijs = "n/a";
                DataGridXML.Items.Refresh();
                return;
            }
            if (!DateTime.TryParse(PeildatumPicker.Text, out DateTime peildatum))
            {
                MessageBox.Show("Selecteer een peildatum aub");
                return;
            }

            int volwassenen = 0, senioren = 0, bijdrage = 0;
            foreach (Volwassene persoon in gezin.Volwassenen)
            {
                DateTime geboortedatum = DateTime.Parse(gezin.Volwassenen[0].GeboorteDatum);
                double leeftijd = (peildatum - geboortedatum).TotalDays/365.25;

                volwassenen++;
                if (leeftijd > 65)
                {
                    senioren++;
                }
            }

            if (volwassenen == 1)
            {
                bijdrage += 30;
                if (senioren == 1)
                {
                    bijdrage -= 4;
                }
            }
            if (volwassenen == 2 && senioren > 0)
                bijdrage += 65;
            else if (volwassenen == 2)
                bijdrage += 61;

            if (gezin.Kinderen > 0)
                bijdrage += 11 * gezin.Kinderen - 1;

            gezin.Prijs = "€ " + bijdrage;
        }

        private void HerberekenAlles()
        {
            if (!DateTime.TryParse(PeildatumPicker.Text, out _))
            {
                MessageBox.Show("Selecteer een geldige peildatum");
                return;
            }

            foreach (Gezin Gezin in Gezinnen)
                Herbereken(Gezin);
            DataGridXML.Items.Refresh();
        }

        private void CheckTextBox(TextBox textbox, string pattern = "[^a-zA-Z ]")
        {
            if (!Regex.IsMatch(textbox.Text, pattern))
                return;

            int caretIndex = textbox.CaretIndex - 1;
            textbox.Text = Regex.Replace(textbox.Text, pattern, "");
            textbox.CaretIndex = Math.Min(0, caretIndex);
        }

        private void VerwijderGezinButton_Click(object sender, RoutedEventArgs e)
        {
            if (DataGridXML.SelectedIndex < 0)
                return;

            Gezin gezin = (Gezin)DataGridXML.SelectedItem;
            Gezinnen.Remove(gezin);
            DataGridPersonen.SelectedIndex = -1;
            DataGridXML.SelectedIndex = -1;
            DataGridXML.Items.Refresh();
            SaveToFile();
        }

        private void VerwijderVolwasseneButton_Click(object sender, RoutedEventArgs e)
        {
            if (DataGridXML.SelectedIndex < 0)
                return;
            if (DataGridPersonen.SelectedIndex < 0)
                return;

            Gezin gezin = (Gezin)DataGridXML.SelectedItem;
            gezin.VerwijderVolwassene((Volwassene)DataGridPersonen.SelectedItem);
            Herbereken(gezin);

            DataGridXML.Items.Refresh();
            DataGridPersonen.Items.Refresh();
            SaveToFile();
        }

        private void AddGezinButton_Click(object sender, RoutedEventArgs e)
        {
            Gezinnen.Add(new Gezin(GezinNaamBox.Text.Trim(), (int)KinderenAantalSlider.Value));
            DataGridXML.Items.Refresh();
            SaveToFile();
        }

        private void AddVolwasseneButton_Click(object sender, RoutedEventArgs e)
        {
            if (DataGridXML.SelectedIndex == -1)
            {
                MessageBox.Show("Selecteer een gezin");
                return;
            }
            if (!DateTime.TryParse(VolwasseneGeboorteDatum.Text, out DateTime geboorteDatum))
            {
                MessageBox.Show("Selecteer geboortedatum");
                return;
            }

            Gezin gezin = (Gezin)DataGridXML.SelectedItem;
            if (gezin.Volwassenen.Count > 1)
            {
                MessageBox.Show("Maximaal 2 volwassenen per gezin toegestaan");
                return;
            }
            gezin.VoegVolwasseneToe(VolwasseneNaamBox.Text, geboorteDatum);
            Herbereken(gezin);
            DataGridXML.Items.Refresh();
            DataGridPersonen.Items.Refresh();
            SaveToFile();
        }

        private void GezinNaamBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            CheckTextBox(GezinNaamBox);
        }

        private void VolwasseneNaamBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            CheckTextBox(VolwasseneNaamBox);
        }

        private void DataGridXML_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            try
            {
                DataGridPersonen.ItemsSource = ((Gezin)DataGridXML.SelectedItem).Volwassenen;
                DataGridPersonen.Items.Refresh();
            }
            catch (Exception err)
            {
                MessageBox.Show(err.Message);
            }
        }

        private void PeildatumPicker_CalendarClosed(object sender, RoutedEventArgs e)
        {
            HerberekenAlles();
        }

        private void KinderenAantalSlider_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            KinderenAantalLabel.Content = "Kinderen: " + KinderenAantalSlider.Value.ToString();
        }
    }
}
