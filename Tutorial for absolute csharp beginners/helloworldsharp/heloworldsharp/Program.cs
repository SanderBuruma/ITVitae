using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace heloworldsharp
{
    class Program
    {
        static void Main(string[] args)
        {
            string lastName;
            Console.Write("What is your last name? ");
            lastName = Console.ReadLine();

            string firstName;
            Console.Write("What is your first name? ");
            firstName = Console.ReadLine();

            string age;
            Console.Write("How many years have passed since you were born? ");
            age = Console.ReadLine();

            Console.WriteLine("Hello " + firstName + " " + lastName + ". You are " + age + " years old.");
            Console.ReadLine();
        }
    }
}
