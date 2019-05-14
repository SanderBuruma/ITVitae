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

namespace _5KinderBijslag
{
    /// <summary>
    /// Interaction logic for UserControl1.xaml
    /// </summary>
    public partial class Data : UserControl
    {

        private readonly BinaryFormatter Formatter = new BinaryFormatter();
        private readonly string DATA_FILENAME = "TaxirittenData.dat";
        private readonly Dictionary<string, int> MultiConstants = new Dictionary<string, int>
        {
            {"RitDuur", 1 },
            {"RitBegin", 5 },
        };
        internal List<Taxirit> Taxiritten { get; set; } = new List<Taxirit> { };

        public Data()
        {
            InitializeComponent();
            LoadFromFile();
            //DataGridXML.CanUserDeleteRows = true;
            DataGridXML.Items.IsLiveSorting = false;
            DataGridXML.IsReadOnly = true;
        }

        private void LoadFromFile()
        {
            if (!File.Exists(DATA_FILENAME))
            {
                DataGridXML.ItemsSource = Taxiritten;
                return;
            }

            try
            {
                FileStream TaxirittenBestand = new FileStream(DATA_FILENAME, FileMode.Open, FileAccess.Read);
                Taxiritten = (List<Taxirit>) Formatter.Deserialize(TaxirittenBestand);
                TaxirittenBestand.Close();
                DataGridXML.ItemsSource = Taxiritten;
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
                FileStream TaxirittenBestand =
                    new FileStream("TaxirittenData.dat", FileMode.OpenOrCreate, FileAccess.Write);

                Formatter.Serialize(TaxirittenBestand, Taxiritten);

                TaxirittenBestand.Close();
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message);
            }
        }

        private void DataGridXML_CellEditEnding(object sender, DataGridCellEditEndingEventArgs e)
        {
            string newValue = e.EditingElement.ToString().Replace("System.Windows.Controls.TextBox: ", "");
            string columnHeader = e.Column.Header.ToString();

            if (columnHeader == "Familienaam" && newValue.Length < 2)
            {
                MessageBox.Show("Nieuwe familienaam moet minstens 2 letters lang zijn");
                e.Cancel = true;
                return;
            }

            var task = Task.Run(async () => {
                await Task.Delay(1);
                SaveToFile();
            });
        }

        private void VerwijderTaxiritButton_Click(object sender, RoutedEventArgs e)
        {
            Taxiritten.Remove((Taxirit)DataGridXML.SelectedItem);
            DataGridXML.ItemsSource = Taxiritten;
            DataGridXML.Items.Refresh();
            SaveToFile();
        }
        private void GeredenKmsBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (!int.TryParse(GeredenKmsBox.Text, out _))
                GeredenKmsBox.Text = "0";
        }

        private void RitBeginSlider_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            int BeginInt = (int)RitBeginSlider.Value * MultiConstants["RitBegin"];
            RitBeginLabel.Content = string.Format("{1:00}:{0:00}", BeginInt % 60, Math.Floor((float)BeginInt / 60));
        }

        private void RitDuurSlider_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            int duurInt = (int)RitDuurSlider.Value * MultiConstants["RitDuur"];
            RitDuurLabel.Content = string.Format("{1}h {0}m", duurInt % 60, Math.Floor((float)duurInt / 60));

        }


        private void AddTaxiritButton_Click(object sender, RoutedEventArgs e)
        {
            if (!int.TryParse(GeredenKmsBox.Text, out int kilometers))
            {
                MessageBox.Show("Kon niet gereden kilometers parsen");
                return;
            }
            int beginInt = (int)RitBeginSlider.Value * MultiConstants["RitBegin"];
            int duurInt = (int)RitDuurSlider.Value * MultiConstants["RitDuur"];
            double bedrag = kilometers;
            bedrag += 0.25 * duurInt;

            //extra bedrag voor bepaalde tijden vd dag
            if (beginInt > 480 && duurInt + beginInt < 1080)
            {//wanneer de rit helemaal tussen 8AM en 6PM is
                bedrag += 0.20 * duurInt;
            }
            else if (beginInt < 480 && beginInt + duurInt > 480)
            {//wanneer een rit overgaat van voor 8AM tot na 8AM
                bedrag += (beginInt + duurInt - 480) * .2;
            }
            else if (beginInt < 1080 && beginInt + duurInt > 1080)
            {//wanneer een rit overgaat van voor 6PM naar na 6PM
                bedrag += (1080 - beginInt) * .2;
            }

            //berekenen speciale toeslag voor het weekend
            int dagVdWeek = (int)DateTime.Parse(BegindatumBox.Text).DayOfWeek;
            beginInt += 1440 * dagVdWeek;
            //BeginInt = 0 staat nu gelijk aan zondag om middernacht aan het begin van die zondag;
            if (beginInt < 1860 || beginInt > 8520)
            {//wanner een rit voor maandag 7AM of na 10PM vrijdag begint
                bedrag *= 1.15;
            }
            bedrag = Math.Round(bedrag, 2);

            string stringDuur = string.Format("{1}h {0}m", duurInt % 60, Math.Floor((float)duurInt / 60));
            string stringBegin = string.Format("{2} {1:00}:{0:00}", beginInt % 60, Math.Floor((float)(beginInt % 1440) / 60), DateTime.Parse(BegindatumBox.Text).DayOfWeek.ToString());
            Taxiritten.Add(new Taxirit(kilometers, stringBegin, stringDuur, "€ " + bedrag.ToString()));
            DataGridXML.Items.Refresh();
            SaveToFile();
        }
    }
}
