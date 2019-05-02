using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UnderstandingLINQ
{
    class Program
    {
        static void Main(string[] args)
        {
            List<Car> myCars = new List<Car>() {
                new Car() { VIN="A1", Make="BMW", Model= "550i", StickerPrice=55000, Year=2009},
                new Car() { VIN="B2", Make="Toyota", Model="4Runner", StickerPrice=35000, Year=2010},
                new Car() { VIN="C3", Make="BMW", Model = "745li", StickerPrice=75000, Year=2008},
                new Car() { VIN="D4", Make="Ford", Model="Escape", StickerPrice=25000, Year=2008},
                new Car() { VIN="E5", Make="BMW", Model="55i", StickerPrice=57000, Year=2010}
            };

            // LINQ query

            /*
            var bmws = from car in myCars
                       orderby car.Year descending
                       select car;
                       */


            // LINQ method
            //var bmws = myCars.Where(p => p.Make == "BMW" && p.Year == 2010);
            var bmws = myCars.OrderByDescending(p => p.Year);

            Console.WriteLine(myCars.TrueForAll(p => p.Year > 2012));

            myCars.ForEach(p => p.StickerPrice -= 10000);
            myCars.ForEach(p => Console.WriteLine("{0} {1:C} {2}", p.VIN, p.StickerPrice, p.Model));
            Console.WriteLine("{0:C}", myCars.Sum(p => p.StickerPrice));
            Console.WriteLine(myCars.GetType());
            /*
            foreach (var car in bmws)
            {
                Console.WriteLine("{0} {1} {2} {3:C}", car.Model, car.VIN, car.Year, car.StickerPrice);
            }*/

            var somethingCars = from car in myCars
                                where car.Make == "BMW"
                                select new { car.Make, car.Model };
            Console.WriteLine(somethingCars.GetType());

            Console.ReadLine();
        }
    }

    class Car
    {
        public string VIN { get; set; }
        public string Make { get; set; }
        public string Model { get; set; }
        public int Year { get; set; }
        public double StickerPrice { get; set; }
    }
}
