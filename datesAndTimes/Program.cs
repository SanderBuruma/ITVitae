using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace datesAndTimes
{
    class Program
    {
        static void Main(string[] args)
        {
            DateTime myValye = DateTime.Now;
            //Console.WriteLine(myValye.ToShortDateString());
            //Console.WriteLine(myValye.ToShortTimeString());
            //Console.WriteLine(myValye.ToLongDateString());
            //Console.WriteLine(myValye.ToLongTimeString());
            //Console.WriteLine(myValye.AddDays(3).ToShortDateString());

            DateTime myBirthDay = new DateTime(1987, 7, 3, 23, 59, 59);
            Console.WriteLine(myBirthDay.ToLongDateString());
            TimeSpan myAge = DateTime.Now.Subtract(myBirthDay);
            Console.WriteLine(myAge.TotalDays);

            Console.ReadLine();
        }
    }
}
