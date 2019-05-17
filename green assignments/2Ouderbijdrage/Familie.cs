using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace _2Ouderbijdrage
{
    [Serializable]
    class Familie
    {
        public string Naam { get; set; }
        public string Bijdrage { get; set; }
        public bool EenOuder { get; set; }
        public List<Kind> Kinderen { get; set; }
        public Familie(string naam, bool eenouder = false)
        {
            Naam = naam;
            Kinderen = new List<Kind> { };
            Bijdrage = "0";
            EenOuder = eenouder;
        }

        public void VoegKindToe(string naam, DateTime geboorteDatum)
        {
            Kinderen.Add(new Kind(naam, geboorteDatum.ToShortDateString()));
        }
        public void VerwijderKind(Kind kind)
        {
            try
            {
                Kinderen.Remove(kind);
            }
            catch (Exception err)
            {
                MessageBox.Show("ERROR:\n\n" + err.Message);
            }
        }
    }
}
