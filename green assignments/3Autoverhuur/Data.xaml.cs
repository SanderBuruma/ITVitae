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

namespace _3Autoverhuur
{
    /// <summary>
    /// Interaction logic for UserControl1.xaml
    /// </summary>
    public partial class Data : UserControl
    {

        private readonly BinaryFormatter Formatter = new BinaryFormatter();
        private readonly string DATA_FILENAME = "VerhuringenData.dat";
        internal List<Verhuring> Verhuringen { get; set; } = new List<Verhuring> { };

        public Data()
        {
            InitializeComponent();
            LoadFromFile();
            //DataGridXML.CanUserDeleteRows = true;
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
                Verhuringen = (List<Verhuring>) Formatter.Deserialize(VerhuringenBestand);
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

        private void VerwijderVerhuringButton_Click(object sender, RoutedEventArgs e)
        {
            Verhuringen.Remove((Verhuring)DataGridXML.SelectedItem);
            DataGridXML.ItemsSource = Verhuringen;
            DataGridXML.Items.Refresh();
            SaveToFile();
        }

        private void GeredenKmsBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (!int.TryParse(GeredenKmsBox.Text, out _))
                GeredenKmsBox.Text = "0";
        }

        private void AddVerhuringButton_Click(object sender, RoutedEventArgs e)
        {
            if (!DateTime.TryParse(EindeDatumBox.Text, out DateTime eindeDt))
            {
                MessageBox.Show("Input aub een geldige einde datum.");
                return;
            }
            if (!DateTime.TryParse(BeginDatumBox.Text, out DateTime beginDt))
            {
                MessageBox.Show("Input aub een geldige begin datum.");
                return;
            }
            if (!int.TryParse(GeredenKmsBox.Text, out int geredenKilometers))
            {
                MessageBox.Show("Gereden kilometers moet een getal zijn");
                return;
            }

            int duurVdVerhuring = (int)(eindeDt - beginDt).TotalDays + 1;
            double kilometerprijs = 0;
            double bedrag = 0;
            if (TypeVoertuigBox.SelectedIndex == 0)
            {//auto
                bedrag = 50 * duurVdVerhuring;
                kilometerprijs = .2;
            }
            else if (TypeVoertuigBox.SelectedIndex == 1)
            {//busje
                bedrag = 95 * duurVdVerhuring;
                kilometerprijs = .3;
            }

            if (geredenKilometers > duurVdVerhuring * 100)
                bedrag += (geredenKilometers - duurVdVerhuring * 100) * kilometerprijs;

            bedrag = Math.Round(bedrag);

            string typeVoertuig = ((ListBoxItem)TypeVoertuigBox.SelectedItem).Content.ToString();
            Verhuringen.Add(new Verhuring(geredenKilometers, beginDt.ToShortDateString(), eindeDt.ToShortDateString(), "€ " + bedrag.ToString(), typeVoertuig));
            DataGridXML.Items.Refresh();
            SaveToFile();
        }

        private void BeginDatumBox_CalendarClosed(object sender, RoutedEventArgs e)
        {
            if (!DateTime.TryParse(EindeDatumBox.Text, out DateTime eindeDt))
                return;

            if (!DateTime.TryParse(BeginDatumBox.Text, out DateTime beginDt))
                return;

            if ((int)eindeDt.Ticks < (int)beginDt.Ticks)
                EindeDatumBox.Text = BeginDatumBox.Text;
        }

        private void EindeDatumBox_CalendarClosed(object sender, RoutedEventArgs e)
        {
            if (!DateTime.TryParse(EindeDatumBox.Text, out DateTime eindeDt))
                return;

            if (!DateTime.TryParse(BeginDatumBox.Text, out DateTime beginDt))
                return;

            if ((eindeDt - beginDt).TotalDays < 0)
                EindeDatumBox.Text = BeginDatumBox.Text;
        }
    }
}
