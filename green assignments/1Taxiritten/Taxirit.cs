using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _5KinderBijslag
{
    [Serializable]
    class Taxirit
    {
        public int Kilometers { get; set; }
        public string RitBegin { get; set; }
        public string RitTijd { get; set; }
        public string Bedrag {get; set;}
        public Taxirit(int km, string ritBegin, string ritTijd, string bd)
        {
            Kilometers = km;
            RitBegin = ritBegin;
            RitTijd = ritTijd;
            Bedrag = bd;
        }
    }
}
