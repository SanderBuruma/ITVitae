using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _5KinderBijslag
{
    [Serializable]
    class Kind
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
}
