using System;

namespace EvenFibonacciNumbers
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("This program calculates and returns the sum of all even Fibanacci when given the initial values a & b, up to x!");
            Console.WriteLine("All values must be integers larger than 0\n");
            Console.WriteLine("a & b are the initial values of the fibonacci sequence");
            Console.WriteLine("x is the limiting value which ends the loop\n");

            Console.Write("a: ");
            if (!Int32.TryParse(Console.ReadLine(), out int a) || a < 1)
            {
                Console.WriteLine("Did not receive a valid value for a");
                Console.ReadLine();
                return;
            }
            Console.Write("b: ");
            if (!Int32.TryParse(Console.ReadLine(), out int b) || b < 1)
            {
                Console.WriteLine("Did not receive a valid value for b");
                Console.ReadLine();
                return;
            }
            Console.Write("x: ");
            if (!Int32.TryParse(Console.ReadLine(), out int x) || x < 1)
            {
                Console.WriteLine("Did not receive a valid value for x");
                Console.ReadLine();
                return;
            }

            Console.WriteLine("a:{0} b:{1} x:{2}", a, b, x);
            int sum = 0;
            while (true)
            {
                int c = a + b;
                if (a % 2 == 0) sum += a;
                if (c >= x)
                {
                    if (b % 2 == 0) sum += b;
                    break;
                }
                a = b;
                b = c;
            }

            Console.WriteLine("The sum is: {0}", sum);
            Console.ReadLine();
        }
    }
}
