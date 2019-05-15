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

namespace _8Transportbedrijf
{
    public partial class Data : UserControl
    {

        private readonly BinaryFormatter Formatter = new BinaryFormatter();
        private readonly string DATA_FILENAME = "TransportItemData.dat";
        internal List<TransportItem> TransportItems { get; set; } = new List<TransportItem> { };

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
                DataGridXML.ItemsSource = TransportItems;
                return;
            }

            try
            {
                FileStream VerhuringenBestand = new FileStream(DATA_FILENAME, FileMode.Open, FileAccess.Read);
                TransportItems = (List<TransportItem>)Formatter.Deserialize(VerhuringenBestand);
                VerhuringenBestand.Close();
                DataGridXML.ItemsSource = TransportItems;
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

                Formatter.Serialize(VerhuringenBestand, TransportItems);

                VerhuringenBestand.Close();
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message);
            }
        }

        private void VerwijderTransportItemButton_Click(object sender, RoutedEventArgs e)
        {
            TransportItems.Remove((TransportItem)DataGridXML.SelectedItem);
            DataGridXML.ItemsSource = TransportItems;
            DataGridXML.Items.Refresh();
            SaveToFile();
        }

        private void AddTransportItemButton_Click(object sender, RoutedEventArgs e)
        {
            int binnenKm = (int)(Math.Ceiling(KmBinnenlandsSlider.Value) * 10);
            int buitenKm = (int)(Math.Ceiling(KmBuitenlandsSlider.Value) * 10);
            int kg = (int)(Math.Ceiling(KgSlider.Value) * 25);
            int m3 = (int)(Math.Ceiling(M3Slider.Value));
            double lw = double.Parse(LadingWaardeBox.Text);
            double bedrag = 0;
            double kmTarief = 0;
            if (VloeibareladingCheckbox.IsChecked == true)
                kmTarief += 1.25 * m3 + .45 * kg;
            else
                kmTarief += 0.8 * m3 + .55 * kg;

            if (buitenKm == 0)
                bedrag += kmTarief * binnenKm;
            else
                bedrag += kmTarief * binnenKm * 1.45 + Math.Max(0.03 * lw, 45);

            TransportItems.Add(new TransportItem(
                binnenKm,
                buitenKm,
                kg,
                m3,
                string.Format("€{0:N2}", bedrag),
                lw
            ));
            DataGridXML.Items.Refresh();
            SaveToFile();
        }

        private void M3Slider_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            M3Label.Content = Math.Ceiling(M3Slider.Value) + " m3";
        }

        private void KgSlider_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            KgLabel.Content = (Math.Ceiling(KgSlider.Value) * 25).ToString() + " kg";
        }

        private void KmBinnenlandsSlider_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            KmBinnenlandsLabel.Content = Math.Ceiling(KmBinnenlandsSlider.Value) * 10 + " km";
        }

        private void KmBuitenlandsSlider_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            KmBuitenlandsLabel.Content = Math.Ceiling(KmBuitenlandsSlider.Value) * 10 + " km";
        }

        private void LadingWaardeBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (!double.TryParse(LadingWaardeBox.Text, out _))
            {
                MessageBox.Show("Gebruik alleen getallen in deze textbox");
                LadingWaardeBox.Text = "0";
            }
        }
    }
}
