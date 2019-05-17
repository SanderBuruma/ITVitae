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

namespace _16Vakantiedagen
{
    public partial class Data : UserControl
    {

        private readonly BinaryFormatter Formatter = new BinaryFormatter();
        private readonly string DATA_FILENAME = "WerknemerData.dat";
        internal List<Werknemer> Werknemers { get; set; } = new List<Werknemer> { };

        public Data()
        {
            InitializeComponent();
            LoadFromFile();
            DataGridXML.CanUserSortColumns = false;
            DataGridXML.CanUserResizeRows = false;
            DataGridXML.CanUserResizeColumns = false;
            DataGridXML.IsReadOnly = true;
        }

        private void LoadFromFile()
        {
            if (!File.Exists(DATA_FILENAME))
            {
                DataGridXML.ItemsSource = Werknemers;
                return;
            }

            try
            {
                FileStream VerhuringenBestand = new FileStream(DATA_FILENAME, FileMode.Open, FileAccess.Read);
                Werknemers = (List<Werknemer>)Formatter.Deserialize(VerhuringenBestand);
                VerhuringenBestand.Close();
                DataGridXML.ItemsSource = Werknemers;
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message);
            }
        }

        private void SaveToFile()
        {
            try
            {
                FileStream VerhuringenBestand =
                    new FileStream(DATA_FILENAME, FileMode.OpenOrCreate, FileAccess.Write);

                Formatter.Serialize(VerhuringenBestand, Werknemers);

                VerhuringenBestand.Close();
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message);
            }
        }

        private void VerwijderWerknemerButton_Click(object sender, RoutedEventArgs e)
        {
            Werknemers.Remove((Werknemer)DataGridXML.SelectedItem);
            DataGridXML.ItemsSource = Werknemers;
            DataGridXML.Items.Refresh();
            SaveToFile();
        }

        private void AddWerknemerButton_Click(object sender, RoutedEventArgs e)
        {
            if (!DateTime.TryParse(AanstellingsDatumPicker.Text, out DateTime aanstellingsDatum))
            {
                MessageBox.Show("Aanstellingsdatum is ongeldig");
                return;
            }
            if (!DateTime.TryParse(GeboorteDatumPicker.Text, out DateTime geboorteDatum))
            {
                MessageBox.Show("Geboortedatum is ongeldig");
                return;
            }
            if (!DateTime.TryParse(PeildatumPicker.Text, out DateTime peilDatum))
            {
                MessageBox.Show("Peildatum is ongeldig");
                return;
            }

            char firstChar = PersoonsNummerBox.Text.ToCharArray()[0];
            int vakantieDagen;
            if (firstChar == '1')
                vakantieDagen = 24;
            else if (firstChar == '2')
                vakantieDagen = 23;
            else if (firstChar == '3')
                vakantieDagen = 22;
            else
                vakantieDagen = 20;

            if ((peilDatum - aanstellingsDatum).TotalDays > 3652.5)
                vakantieDagen += 3;
            if ((peilDatum - geboorteDatum).TotalDays > 50 * 365.25)
                vakantieDagen += 5;
            else if ((peilDatum - geboorteDatum).TotalDays > 55 * 365.25)
                vakantieDagen += (int)Math.Ceiling(((peilDatum - geboorteDatum).TotalDays-365.25*55)/365.25);

            Werknemers.Add(new Werknemer(
                NaamBox.Text, 
                geboorteDatum.ToShortDateString(), 
                aanstellingsDatum.ToShortDateString(), 
                vakantieDagen, 
                PersoonsNummerBox.Text
            ));

            DataGridXML.Items.Refresh();
            SaveToFile();
        }

        private void LadingWaardeBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (!double.TryParse(PersoonsNummerBox.Text, out _))
            {
                MessageBox.Show("Gebruik alleen getallen in deze textbox");
                PersoonsNummerBox.Text = "0";
            }
        }

        private void GeboorteDatumPicker_CalendarClosed(object sender, RoutedEventArgs e)
        {
            if (!DateTime.TryParse(GeboorteDatumPicker.Text, out DateTime geboorteDatum))
            {
                return;
            }
            if (!DateTime.TryParse(AanstellingsDatumPicker.Text, out DateTime aanstellingsDatum))
            {
                return;
            }

            if (geboorteDatum > aanstellingsDatum)
            {
                MessageBox.Show("Aannemer kan niet geboren worden na zijn of haar aanstellingsdatum");
                AanstellingsDatumPicker.Text = GeboorteDatumPicker.Text;
            }
        }

        private void AanstellingsDatumPicker_CalendarClosed(object sender, RoutedEventArgs e)
        {
            if (!DateTime.TryParse(AanstellingsDatumPicker.Text, out DateTime aanstellingsDatum))
            {
                return;
            }
            if (!DateTime.TryParse(GeboorteDatumPicker.Text, out DateTime geboorteDatum))
            {
                return;
            }
            if (geboorteDatum > aanstellingsDatum)
            {
                MessageBox.Show("Aannemer kan niet geboren worden na zijn of haar aanstellingsdatum");
                AanstellingsDatumPicker.Text = GeboorteDatumPicker.Text;
            }
        }
    }
}
