using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace cars1
{
    class Program
    {
        static void Main(string[] args)
        {
            Car myCar = new Car("Toyota", "Truck", 2020, "Light Grey");
            Car otherCar = myCar;

            Console.WriteLine("{0} {1} {2} {3}",
                otherCar.Make,
                otherCar.Model,
                otherCar.Year,
                otherCar.Color);

            otherCar.Color = "Red";

            Console.WriteLine("{0} {1} {2} {3}",
                myCar.Make,
                myCar.Model,
                myCar.Year,
                myCar.Color);

            Console.ReadLine();
        }

        private static decimal DetermineMarketValue(Car car)
        {
            decimal carValue = 100.00m;

            return carValue;

        }

        class Car
        {
            public string Make { get; set; }
            public string Model { get; set; }
            public int Year { get; set; }
            public string Color { get; set; }

            public Car(string make, string model, int year, string color)
            {
                Make = make;
                Model = model;
                Year = year;
                Color = color;
            }

            public decimal DetermineMarketValue()
            {
                decimal carValue;

                if (Year > 1990) carValue = 10000;
                else carValue = 2000;

                return carValue;
            }
        }
    }
}
