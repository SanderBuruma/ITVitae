using System;

namespace helloUser
{
    class Program
    {
        static void Main(string[] args)
        {
            string firstName, lastName, age;

            Console.Write("What is your first name?");
            firstName = Console.ReadLine();

            Console.Write("What is your last name?");
            lastName = Console.ReadLine();

            Console.Write("What is your age?");
            age = Console.ReadLine();

            DisplayResult(
                firstName,
                lastName,
                age);
            Console.ReadLine();
        }
        private static string reverseMessage(string x)
        {
            string message = x;
            char[] messageArray = message.ToCharArray();
            Array.Reverse(messageArray);
            return String.Concat(messageArray);
        }
        private static void DisplayResult(
            string firstName, 
            string lastName, 
            string age)
        {
            Console.WriteLine(reverseMessage(String.Format("Hello {0} {1}!\nYou are {2} years old.",
                firstName,
                lastName,
                age)));
        }
        private static void DisplayResult(string message)
        {
            Console.WriteLine(reverseMessage(message));
        }
    }
}
