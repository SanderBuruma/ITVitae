using System;
using System.Collections.Generic;
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

namespace _5KinderBijslag
{
    /// <summary>
    /// Interaction logic for Result.xaml
    /// </summary>
    public partial class Result : UserControl
    {
        public Result()
        {
            InitializeComponent();
        }

        internal void UpdateResult(List<Kind> Kinderen, DateTime peildatum)
        {
            DataGridXML.Items.Clear();
            var Families = new Dictionary<string, Familie> {
            };
            foreach (Kind kind in Kinderen)
            {
                if (!DateTime.TryParse(kind.Geboortedatum, out DateTime dt))
                {
                    MessageBox.Show("Could not parse date: " + kind.Geboortedatum);
                }

                double bijslag = 0;
                double LeeftijdInJaren = (peildatum.Ticks - dt.Ticks)/864e9/365.25;
                if (LeeftijdInJaren < 12)
                {
                    bijslag = 150;
                    MessageBox.Show(kind.Voornaam + " is jonger dan 12");
                }
                else if (LeeftijdInJaren < 18)
                {
                    bijslag = 235;
                    MessageBox.Show(kind.Voornaam + " is jonger dan 18");
                }
                MessageBox.Show(LeeftijdInJaren.ToString("{0}"));

                if (!Families.ContainsKey(kind.Familienaam))
                {
                    Families.Add(kind.Familienaam, new Familie(bijslag));
                }
                else
                {
                    Families[kind.Familienaam].AantalKinderen++;
                    Families[kind.Familienaam].Bijslag+=bijslag;
                }
            }
        }
        public class Familie
        {
            public int AantalKinderen { get; set; }
            public double Bijslag { get; set; }
            public Familie(double b)
            {
                AantalKinderen = 1;
                Bijslag = b;
            }

        }
    }
}
