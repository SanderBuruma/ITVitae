using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace _4Dierenpark
{
    [Serializable]
    class Gezin
    {
        public string Naam { get; set; }
        public string Prijs { get; set; }
        public int Kinderen { get; set; }
        public List<Volwassene> Volwassenen { get; set; }
        public Gezin(string naam, int aantalKinderen)
        {
            Naam = naam;
            Volwassenen = new List<Volwassene> { };
            Prijs = "n/a";
            Kinderen = aantalKinderen;
        }

        public void VoegVolwasseneToe(string naam, DateTime geboorteDatum)
        {
            Volwassenen.Add(new Volwassene(naam, geboorteDatum.ToShortDateString()));
        }
        public void VerwijderVolwassene(Volwassene persoon)
        {
            try
            {
                Volwassenen.Remove(persoon);
            }
            catch (Exception err)
            {
                MessageBox.Show("ERROR:\n\n" + err.Message);
            }
        }

    }
}
