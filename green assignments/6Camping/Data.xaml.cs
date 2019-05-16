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

namespace _6Camping
{
    public partial class Data : UserControl
    {

        private readonly BinaryFormatter Formatter = new BinaryFormatter();
        private readonly string DATA_FILENAME = "ReserveringData.dat";
        internal List<Reservering> Reserveringen { get; set; } = new List<Reservering> { };

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
                DataGridXML.ItemsSource = Reserveringen;
                return;
            }

            try
            {
                FileStream VerhuringenBestand = new FileStream(DATA_FILENAME, FileMode.Open, FileAccess.Read);
                Reserveringen = (List<Reservering>)Formatter.Deserialize(VerhuringenBestand);
                VerhuringenBestand.Close();
                DataGridXML.ItemsSource = Reserveringen;
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

                Formatter.Serialize(VerhuringenBestand, Reserveringen);

                VerhuringenBestand.Close();
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message);
            }
        }

        private void VerwijderReserveringButton_Click(object sender, RoutedEventArgs e)
        {
            Reserveringen.Remove((Reservering)DataGridXML.SelectedItem);
            DataGridXML.ItemsSource = Reserveringen;
            DataGridXML.Items.Refresh();
            SaveToFile();
        }

        private void AddReserveringButton_Click(object sender, RoutedEventArgs e)
        {
            if (!DateTime.TryParse(BeginHuurDatePicker.Text, out DateTime beginDatum))
            {
                MessageBox.Show("Selecteer aub een begin datum");
                return;
            }
            if (!DateTime.TryParse(EindeHuurDatePicker.Text, out DateTime eindDatum))
            {
                MessageBox.Show("Selecteer aub een eind datum");
                return;
            }
            double etmaalBedrag = 25;
            if (AutoCheckBox.IsChecked == true)
                etmaalBedrag += 6;
            if (HondCheckBox.IsChecked == true)
                etmaalBedrag += 4;

            int breedte = int.Parse(PlaatsBreedteM3.Text);
            if (breedte > 10)
                etmaalBedrag += (breedte - 10) * 3;
            if (breedte < 10)
                etmaalBedrag -= (breedte - 10) * 2;
            etmaalBedrag += int.Parse(AantalPersonenBox.Text) * 5;

            //totaalbedrag wordt simpelweg berekent zonder oog op het seizoen en daarna wordt er aan 
            //opgeteld aan de hand van het aantal dagen dat de huurperiode in het seizoen valt
            double totaalBedrag = Math.Floor(etmaalBedrag * (1 + (eindDatum - beginDatum).TotalDays));
            if (beginDatum.Day > 10 && beginDatum.Month > 6 &&
                beginDatum.Day < 16 && beginDatum.Month < 9)
            {//huur begint na 11 Juli en voor 15 Augustus
                if (eindDatum.Day < 16 && eindDatum.Month < 9)
                    totaalBedrag += 5 * ((eindDatum - beginDatum).TotalDays + 1);
                else
                    totaalBedrag += 5 * ((new DateTime(beginDatum.Year, 8, 15) - beginDatum).TotalDays + 1);
            }
            else if (eindDatum.Day > 10 && eindDatum.Month > 6 &&
                eindDatum.Day < 16 && eindDatum.Month < 9)
            {//einddatum eindigt in seizoen
                totaalBedrag += 5 * ((eindDatum - new DateTime(eindDatum.Year, 7, 11)).TotalDays + 1);
            }
            else
                if (beginDatum.Day < 11 && beginDatum.Month < 7 &&
                    eindDatum.Day > 15 && eindDatum.Month > 8)
            {//huurperiode overstrekt het hele seizoen
                totaalBedrag += 5 * ((eindDatum - new DateTime(eindDatum.Year, 7, 11)).TotalDays + 1);
            }

            Reserveringen.Add(new Reservering(
                NaamHuurderBox.Text, 
                beginDatum.ToShortDateString(), 
                eindDatum.ToShortDateString(), 
                breedte, 
                AutoCheckBox.IsChecked == true ? true : false, 
                HondCheckBox.IsChecked == true ? true : false, 
                string.Format("€{0:N2}", totaalBedrag)
            ));
            DataGridXML.Items.Refresh();
            SaveToFile();
        }

        private void PlaatsBreedteM3_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (!int.TryParse(PlaatsBreedteM3.Text, out _))
            {
                PlaatsBreedteM3.Text = "0";
                PlaatsBreedteM3.CaretIndex = PlaatsBreedteM3.Text.Length;
            }
        }

        private void BeginHuurDatePicker_CalendarClosed(object sender, RoutedEventArgs e)
        {
            if (!DateTime.TryParse(BeginHuurDatePicker.Text, out DateTime bDt))
                return;
            if (!DateTime.TryParse(EindeHuurDatePicker.Text, out DateTime eDt))
                return;
            if (bDt > eDt)
                EindeHuurDatePicker.Text = BeginHuurDatePicker.Text;
        }

        private void EindeHuurDatePicker_CalendarClosed(object sender, RoutedEventArgs e)
        {
            if (!DateTime.TryParse(BeginHuurDatePicker.Text, out DateTime bDt))
                return;
            if (!DateTime.TryParse(EindeHuurDatePicker.Text, out DateTime eDt))
                return;
            if (bDt > eDt)
                EindeHuurDatePicker.Text = BeginHuurDatePicker.Text;
        }

        private void AantalPersonenBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (!int.TryParse(AantalPersonenBox.Text, out _))
            {
                AantalPersonenBox.Text = "0";
                AantalPersonenBox.CaretIndex = AantalPersonenBox.Text.Length;
            }
        }

        private void NaamHuurderBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            string naamHuurder = NaamHuurderBox.Text;
            Regex rgx = new Regex("[^a-zA-Z ]+");
            if (rgx.IsMatch(naamHuurder))
                NaamHuurderBox.Text = Regex.Replace(naamHuurder, @"[^a-zA-Z ]+", "");
            NaamHuurderBox.CaretIndex = NaamHuurderBox.Text.Length;
        }
    }
}
