using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _8Transportbedrijf
{
    [Serializable]
    class TransportItem
    {
        public double LadingKg { get; set; }
        public double Ladingm3 { get; set; }
        public double LadingWaarde { get; set; }
        public int KmBinnenland { get; set; }
        public int KmBuitenland { get; set; }
        public string Bedrag { get; set; }
        public TransportItem(int bil, int bul, double kg, double m3, string bedrag, double lw)
        {
            LadingKg = kg;
            Ladingm3 = m3;
            KmBinnenland = bil;
            KmBuitenland = bul;
            Bedrag = bedrag;
            LadingWaarde = lw;
        }
    }
}
