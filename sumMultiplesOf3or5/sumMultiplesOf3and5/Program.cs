using System;

namespace sumMultiplesOf3and5
{
    class Program
    {
        static void Main(string[] args)
        {
            bool run = true;
            while(run)
            {
                Console.Clear();
                Console.WriteLine("Options: ");
                Console.WriteLine("1) Get the sum of all integers that are multiples of 3 or 5 equal to or less than X.");
                Console.WriteLine("2) Exit Program");
                string choice = Console.ReadLine();

                if (choice == "1")
                {
                    Console.Write("Positive Integer: ");
                    int x;
                    if (Int32.TryParse(Console.ReadLine(), out x))
                    {
                        sumOfMultiplesOf3or5(x);
                    }
                    else
                    {
                        Console.WriteLine("Please enter an integer to make a correct choice");
                    }
                    Console.WriteLine("\nPress enter to continue");
                    Console.ReadLine();
                }
                else
                {
                    run = false;
                }

            }
        }

        private static void sumOfMultiplesOf3or5(int x)
        {
            if (x > 0)
            {
                if (x < 1000001)
                {
                    int sum = 0;
                    while (x > 0)
                    {
                        if (x % 3 == 0 || x % 5 == 0)
                        {
                            sum += x;
                        }
                        x--;
                    }
                    Console.WriteLine(String.Format("sum: {0}", sum));
                }
                else Console.WriteLine("Integer may not be larger than 1,000,000");
            }
            else Console.WriteLine("Integer may not be smaller than 1");
        }
    }
}
