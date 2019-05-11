﻿using System;
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
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private List<Kind> Kinderen = new List<Kind> { };
        private readonly BinaryFormatter Formatter =  new BinaryFormatter();
        private readonly string DATA_FILENAME = "KinderenData.dat";
        public MainWindow()
        {
            InitializeComponent();
            LoadFromFile();
        }

        [Serializable]
        public class Kind
        {
            public string Voornaam { get; set; }
            public string Familienaam { get; set; }
            public string Geboortedatum { get; set; }
            public Kind(string vn, string fn, string gd)
            {
                Voornaam = vn;
                Familienaam = fn;
                Geboortedatum = gd;
            }

        }

        private void LoadFromFile()
        {
            if (!File.Exists(DATA_FILENAME))
            {
                MessageBox.Show("\"" + DATA_FILENAME + "\" niet gevonden. Vul nieuwe data in en klik op de Save to File knop.");
                return;
            }

            try
            {
                FileStream KinderBestand = new FileStream(DATA_FILENAME,
                FileMode.Open, FileAccess.Read);
                Kinderen = (List<Kind>)
                    Formatter.Deserialize(KinderBestand);
                KinderBestand.Close();

                foreach (Kind kind in Kinderen)
                    DataGridXML.Items.Add(kind);
            }
            catch
            {
                MessageBox.Show("Er was een probleem met het laden van het \"" + DATA_FILENAME + "\" bestand.");
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
            catch
            {
                MessageBox.Show("Failed to write file");
            }
        }

        private void SaveToFileButton_Click(object sender, RoutedEventArgs e)
        {
            SaveToFile();
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
                KindVoornaamBox.Text,
                KindFamilienaamBox.Text,
                string.Format("{0:0000}/{1:00}/{2:00}", gd.Year, gd.Month, gd.Day)
            ));
            DataGridXML.Items.Add(Kinderen[Kinderen.Count-1]);
            SaveToFile();

            KindVoornaamBox.Text = "";
            KindFamilienaamBox.Text = "";

        }
    }
}
