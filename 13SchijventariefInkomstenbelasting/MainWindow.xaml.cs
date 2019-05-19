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

namespace _13SchijventariefInkomstenbelasting
{

    public partial class MainWindow : Window
    {
        internal List<Persoon> Personen = new List<Persoon> { };
        private readonly string DATA_FILENAME = "personen.dat";
        private readonly BinaryFormatter Formatter = new BinaryFormatter();
        public readonly List<double> Tarieven = new List<double>
        {
            419,
            8799,
            17179,
            15503,
            15503
        };

        public MainWindow()
        {
            InitializeComponent();

            LoadFromFile();
            PersonenDataGrid.ItemsSource = Personen;
            PersonenDataGrid.Items.Refresh();
            PersonenDataGrid.CanUserSortColumns = false;
            PersonenDataGrid.CanUserResizeRows = false;
            PersonenDataGrid.CanUserResizeColumns = false;
            PersonenDataGrid.IsReadOnly = true;

            BelastingVrijeSomLabel.Content = "Belastingvrije Som: €" + Tarieven[TariefComboBox.SelectedIndex];
        }

        private void LoadFromFile()
        {
            if (!File.Exists(DATA_FILENAME))
            {
                PersonenDataGrid.ItemsSource = Personen;
                return;
            }

            try
            {
                FileStream PersonenBestand = new FileStream(DATA_FILENAME, FileMode.Open, FileAccess.Read);
                Personen = (List<Persoon>)Formatter.Deserialize(PersonenBestand);
                PersonenBestand.Close();
                PersonenDataGrid.ItemsSource = Personen;
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

                Formatter.Serialize(VerhuringenBestand, Personen);

                VerhuringenBestand.Close();
            }
            catch (Exception err)
            {
                MessageBox.Show(err.Message);
            }
        }

        private void NaamBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (new Regex("[^a-zA-Z ]").IsMatch(NaamBox.Text))
            {
                NaamBox.Text = Regex.Replace(NaamBox.Text, "[^a-zA-Z ]", "");
                NaamBox.CaretIndex = NaamBox.Text.Length;
            }
        }

        private void InkomenBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (!double.TryParse(InkomenBox.Text, out _))
            {
                InkomenBox.Text = "0";
                return;
            }
        }

        private void VoegtoePersoonButton_Click(object sender, RoutedEventArgs e)
        {
            if (NaamBox.Text.Trim().Length < 2)
            {
                MessageBox.Show("Vul aub een naam in");
                return;
            }
            double inkomsten = double.Parse(InkomenBox.Text);
            if (inkomsten < 100)
            {
                MessageBox.Show("Inkomsten behoren meer dan 100,- zijn");
                return;
            }
            Personen.Add(new Persoon(
                NaamBox.Text, 
                TariefComboBox.SelectedIndex, 
                inkomsten,
                Tarieven
            ));
            PersonenDataGrid.Items.Refresh();
            SaveToFile();
        }

        private void VerwijderPersoonButton_Click(object sender, RoutedEventArgs e)
        {
            if (PersonenDataGrid.SelectedIndex < 0)
                return;

            foreach (Persoon persoon in PersonenDataGrid.SelectedItems)
                Personen.Remove(persoon);

            PersonenDataGrid.Items.Refresh();
            SaveToFile();
        }

        private void TariefComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            BelastingVrijeSomLabel.Content = "Belastingvrije Som: €" + Tarieven[TariefComboBox.SelectedIndex];
        }
    }

    [Serializable]
    internal class Persoon
    {
        public string Naam { get; set; }
        public string Inkomsten { get; set; }
        public int Tarief { get; set; }
        public string Belasting { get; set; }
        public Persoon(
            string naam, 
            int tarief, 
            double inkomsten, 
            List<double> tarieven
        )
        {
            Naam = naam;
            Tarief = tarief+1;
            Inkomsten = string.Format("€{0:N2}", inkomsten);

            double belastingDouble;
            if (tarieven[tarief] > inkomsten)
            {
                Belasting = string.Format("€{0:N2}", 0);
                return;
            }

            inkomsten -= tarieven[tarief];

            if (inkomsten < 8001)
                belastingDouble = inkomsten * .3575;
            else if (inkomsten < 25001)
                belastingDouble = 
                    8000 * .3575 +
                    (inkomsten - 8000) * .3705;
            else if (inkomsten < 54001)
                belastingDouble = 
                    8000 * .3575 +
                    17000 * .3705 +
                    (inkomsten - 25000) * .5;
            else
                belastingDouble =
                    8000 * .3575 +
                    17000 * .3705 +
                    29000 * .5 +
                    (inkomsten - 54000) * .6;

            belastingDouble += Math.Min(6704, inkomsten * .12);

            Belasting = string.Format("€{0:N2}", belastingDouble);
        }
    }
}
