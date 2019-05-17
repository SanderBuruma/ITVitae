using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _16Vakantiedagen
{
    [Serializable]
    class Werknemer
    {
        public string Naam { get; set; }
        public string GeboorteDag { get; set; }
        public string BeginDienst { get; set; }
        public string PersoneelsNummer { get; set; }
        public int Vakantiedagen { get; set; }
        public Werknemer(string naam, string geboorteDag, string begindienst, int vakantieDagen, string personeelsNummer)
        {
            Naam = naam;
            GeboorteDag = geboorteDag;
            BeginDienst = begindienst;
            Vakantiedagen = vakantieDagen;
            PersoneelsNummer = personeelsNummer;
        }

    }
}
