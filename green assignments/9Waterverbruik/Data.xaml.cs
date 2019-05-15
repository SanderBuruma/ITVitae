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

namespace _9Waterverbruik
{
    /// <summary>
    /// Interaction logic for UserControl1.xaml
    /// </summary>
    public partial class Data : UserControl
    {

        private readonly BinaryFormatter Formatter = new BinaryFormatter();
        private readonly string DATA_FILENAME = "WaterverbruikData.dat";
        internal List<Waterverbruik> Verhuringen { get; set; } = new List<Waterverbruik> { };

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
                DataGridXML.ItemsSource = Verhuringen;
                return;
            }

            try
            {
                FileStream VerhuringenBestand = new FileStream(DATA_FILENAME, FileMode.Open, FileAccess.Read);
                Verhuringen = (List<Waterverbruik>) Formatter.Deserialize(VerhuringenBestand);
                VerhuringenBestand.Close();
                DataGridXML.ItemsSource = Verhuringen;
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

                Formatter.Serialize(VerhuringenBestand, Verhuringen);

                VerhuringenBestand.Close();
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message);
            }
        }

        private void VerwijderWaterverbruikButton_Click(object sender, RoutedEventArgs e)
        {
            Verhuringen.Remove((Waterverbruik)DataGridXML.SelectedItem);
            DataGridXML.ItemsSource = Verhuringen;
            DataGridXML.Items.Refresh();
            SaveToFile();
        }

        private void WaterverbruikBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (!int.TryParse(WaterverbruikBox.Text, out _))
                WaterverbruikBox.Text = "0";
        }

        private void AddWaterverbruikButton_Click(object sender, RoutedEventArgs e)
        {
            if (!double.TryParse(WaterverbruikBox.Text, out double waterverbruik))
            {
                MessageBox.Show("Waterverbruik moet een getal zijn");
                return;
            }

            string naam = NaamBox.Text;
            double bedrag1 = 100, bedrag2 = 75;
            bedrag1 = Math.Round(bedrag1 + waterverbruik * .25, 2);
            bedrag2 = Math.Round(bedrag2 + waterverbruik * .38, 2);
            Verhuringen.Add(new Waterverbruik(naam.Trim(), waterverbruik, "€ " + Math.Min(bedrag1, bedrag2).ToString()));

            DataGridXML.Items.Refresh();
            SaveToFile();
        }
    }
}
