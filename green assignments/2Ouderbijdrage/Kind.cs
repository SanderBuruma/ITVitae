using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _2Ouderbijdrage
{
    [Serializable]
    class Kind
    {
        public string Voornaam { get; set; }
        public string GeboorteDatum { get; set; }
        public Kind(string voornaam, string geboorteDatum)
        {
            Voornaam = voornaam;
            GeboorteDatum = geboorteDatum;
        }
    }
}
