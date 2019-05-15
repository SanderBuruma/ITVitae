using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _3Autoverhuur
{
    [Serializable]
    class Verhuring
    {
        public string TypeVoertuig { get; set; }
        public int Kilometers { get; set; }
        public string HuurBegin { get; set; }
        public string HuurEinde { get; set; }
        public string Bedrag {get; set;}
        public Verhuring(int km, string huurBegin, string huurEinde, string bd, string tv)
        {
            TypeVoertuig = tv;
            Kilometers = km;
            HuurBegin = huurBegin;
            HuurEinde = huurEinde;
            Bedrag = bd;
        }
    }
}
