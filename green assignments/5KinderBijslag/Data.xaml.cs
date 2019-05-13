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

namespace _5KinderBijslag
{
    /// <summary>
    /// Interaction logic for UserControl1.xaml
    /// </summary>
    public partial class Data : UserControl
    {
        public Data()
        {
            InitializeComponent();
            LoadFromFile();
            PeilDatum = new DateTime(2019, 05, 12);
            PeildatumBox.SelectedDate = PeilDatum;
            //DataGridXML.CanUserDeleteRows = true;
            DataGridXML.IsReadOnly = false;
        }

        private readonly BinaryFormatter Formatter = new BinaryFormatter();
        private readonly string DATA_FILENAME = "KinderenData.dat";
        public DateTime PeilDatum;

        internal List<Kind> Kinderen { get; set; } = new List<Kind> { };

        private void LoadFromFile()
        {
            if (!File.Exists(DATA_FILENAME))
                return;

            try
            {
                FileStream KinderBestand = new FileStream(DATA_FILENAME, FileMode.Open, FileAccess.Read);
                Kinderen = (List<Kind>) Formatter.Deserialize(KinderBestand);
                KinderBestand.Close();

                foreach (Kind kind in Kinderen)
                    DataGridXML.Items.Add(kind);
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
                FileStream KinderBestand =
                    new FileStream("KinderenData.dat", FileMode.OpenOrCreate, FileAccess.Write);

                Formatter.Serialize(KinderBestand, Kinderen);

                KinderBestand.Close();
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message);
            }
        }

        private void AddKindButton_Click(object sender, RoutedEventArgs e)
        {
            if (KindVoornaamBox.Text.Length < 3 || KindFamilienaamBox.Text.Length < 3)
            {
                MessageBox.Show("Voor en familienaam moeten minstens 3 letters bevatten.");
                return;
            }
            Regex negativeLetterCheck = new Regex("[^a-zA-Z ]");
            if (negativeLetterCheck.IsMatch(KindVoornaamBox.Text))
            {
                MessageBox.Show("Gebruik alleen letters en spaties in de voornaam a.u.b.");
                return;
            }
            if (negativeLetterCheck.IsMatch(KindFamilienaamBox.Text))
            {
                MessageBox.Show("Gebruik alleen letters en spaties in de familienaam a.u.b.");
                return;
            }
            if (!DateTime.TryParse(KindGeboortedatumBox.Text, out DateTime gd))
            {
                MessageBox.Show("Er is iets foutgegaan met het herkennen van de geboortedatum.");
                return;
            }

            Kinderen.Add(new Kind(
                KindVoornaamBox.Text.Trim(),
                KindFamilienaamBox.Text.Trim(),
                string.Format("{0:0000}/{1:00}/{2:00}", gd.Year, gd.Month, gd.Day)
            ));
            DataGridXML.Items.Add(Kinderen[Kinderen.Count - 1]);
            SaveToFile();

            KindVoornaamBox.Text = "";
            KindFamilienaamBox.Text = "";

        }

        private void PeildatumBox_CalendarClosed(object sender, RoutedEventArgs e)
        {
            if (!DateTime.TryParse(PeildatumBox.Text, out DateTime dt))
            {
                MessageBox.Show("Could not parse Data.xml:PeildatumBox.Text as date");
                return;
            };
            PeilDatum = dt;
        }
    }
}
