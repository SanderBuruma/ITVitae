using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _6Camping
{
    [Serializable]
    class Reservering
    {
        public string NaamHuurder { get; set; }
        public string BeginDatum { get; set; }
        public string EindDatum { get; set; }
        public int PlaatsBreedte { get; set; }
        public int Personen { get; set; }
        public bool Auto { get; set; }
        public bool Hond { get; set; }
        public string Bedrag { get; set; }

        public Reservering(string naamHuurder, string beginDatum, string eindeDatum, int plaatsBreedte, bool auto, bool hond, string bedrag)
        {
            NaamHuurder = naamHuurder;
            BeginDatum = beginDatum;
            EindDatum = eindeDatum;
            PlaatsBreedte = plaatsBreedte;
            Auto = auto;
            Hond = hond;
            Bedrag = bedrag;
        }

    }
}
