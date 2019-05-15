using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _9Waterverbruik
{
    [Serializable]
    class Waterverbruik
    {
        public string Naam { get; set; }
        public double Gebruik { get; set; }
        public string Bedrag {get; set;}
        public Waterverbruik(string naam, double gebruik, string bedrag)
        {
            Naam = naam;
            Gebruik = gebruik;
            Bedrag = bedrag;
        }
    }
}
