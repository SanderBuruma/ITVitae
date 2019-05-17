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

namespace _2Ouderbijdrage
{
    public partial class Data : UserControl
    {
        private readonly BinaryFormatter Formatter = new BinaryFormatter();
        private readonly string DATA_FILENAME = "FamilieData.dat";
        internal List<Familie> Families { get; set; } = new List<Familie> { };

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
                DataGridXML.ItemsSource = Families;
                return;
            }

            try
            {
                FileStream VerhuringenBestand = new FileStream(DATA_FILENAME, FileMode.Open, FileAccess.Read);
                Families = (List<Familie>)Formatter.Deserialize(VerhuringenBestand);
                VerhuringenBestand.Close();
                DataGridXML.ItemsSource = Families;
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
                ErrorMessage(err);
            }
        }

        private void ErrorMessage(Exception err)
        {
            MessageBox.Show("ERROR:\n\n" + err.Message);
        }

        private void HerberekenBijdrage(Familie familie)
        {
            if (familie.Kinderen.Count == 0)
            {
                familie.Bijdrage = "€ 0";
                DataGridXML.Items.Refresh();
                return;
            }
            if (!DateTime.TryParse(PeildatumPicker.Text, out DateTime peildatum))
            {
                MessageBox.Show("Selecteer een peildatum aub");
                return;
            }

            int bijdrage = 50;
            foreach (Kind kind in familie.Kinderen)
            {
                bijdrage += 25;
                DateTime geboortedatum = DateTime.Parse(kind.GeboorteDatum);
                double leeftijd = (peildatum - geboortedatum).TotalDays;
                if (leeftijd > 3652.5)
                    bijdrage += 12;
            }
            bijdrage = Math.Min(150, bijdrage);

            if (familie.EenOuder)
                bijdrage = (int)Math.Floor(bijdrage * .75);
            familie.Bijdrage = "€ " + bijdrage;

            DataGridXML.Items.Refresh();
        }

        private void HerberekenAlles()
        {
            if (!DateTime.TryParse(PeildatumPicker.Text, out _))
            {
                MessageBox.Show("Selecteer een geldige peildatum");
                return;
            }

            foreach (Familie familie in Families)
                HerberekenBijdrage(familie);
        }

        private void CheckTextBox(TextBox textbox, string pattern = "[^a-zA-Z ]")
        {
            if (!Regex.IsMatch(textbox.Text, pattern))
                return;

            int caretIndex = textbox.CaretIndex - 1;
            textbox.Text = Regex.Replace(textbox.Text, pattern, "");
            textbox.CaretIndex = Math.Min(0, caretIndex);
        }

        private void VerwijderFamilieButton_Click(object sender, RoutedEventArgs e)
        {
            if (DataGridXML.SelectedIndex < 0)
                return;

            DataGridKinderen.SelectedIndex = -1;

            try
            {
                Families.Remove((Familie)DataGridXML.SelectedItem);
            }
            catch (Exception err)
            {
                ErrorMessage(err);
                return;
            }

            DataGridXML.ItemsSource = Families;
            DataGridXML.Items.Refresh();
            SaveToFile();
        }

        private void VerwijderKindButton_Click(object sender, RoutedEventArgs e)
        {
            if (DataGridXML.SelectedIndex < 0)
                return;
            if (DataGridKinderen.SelectedIndex < 0)
                return;

            Familie familie = (Familie)DataGridXML.SelectedItem;
            familie.VerwijderKind((Kind)DataGridKinderen.SelectedItem);
            HerberekenBijdrage(familie);

            DataGridKinderen.Items.Refresh();
            SaveToFile();
        }

        private void AddFamilieButton_Click(object sender, RoutedEventArgs e)
        {
            if (EenOuderCheckBox.IsChecked == true)
                Families.Add(new Familie(FamilieNaamBox.Text, true));
            else
                Families.Add(new Familie(FamilieNaamBox.Text));

            DataGridXML.Items.Refresh();
            SaveToFile();
        }

        private void AddKindButton_Click(object sender, RoutedEventArgs e)
        {
            if (!DateTime.TryParse(KindGeboorteDatum.Text, out DateTime geboorteDatum))
            {
                MessageBox.Show("Selecteer geboortedatum");
                return;
            }

            Familie familie = (Familie)DataGridXML.SelectedItem;
            familie.VoegKindToe(KindNaamBox.Text, geboorteDatum);
            HerberekenBijdrage(familie);

            DataGridKinderen.Items.Refresh();
            SaveToFile();
        }

        private void FamilieNaamBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            CheckTextBox(FamilieNaamBox);
        }

        private void KindNaamBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            CheckTextBox(KindNaamBox);
        }

        private void DataGridXML_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            try
            {
                DataGridKinderen.ItemsSource = ((Familie)DataGridXML.SelectedItem).Kinderen;
                DataGridKinderen.Items.Refresh();
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
    }
}
