using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _4Dierenpark
{
    [Serializable]
    class Volwassene
    {
        public string Voornaam { get; set; }
        public string GeboorteDatum { get; set; }
        public Volwassene(string voornaam, string geboorteDatum)
        {
            Voornaam = voornaam;
            GeboorteDatum = geboorteDatum;
        }
    }
}
