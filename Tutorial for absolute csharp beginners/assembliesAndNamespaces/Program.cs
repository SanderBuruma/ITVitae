using System;
using System.IO;
using System.Net;

namespace assembliesAndNamespaces
{
    class Program
    {
        static void Main(string[] args)
        {
            WebClient client = new WebClient();
            string reply = client.DownloadString("https://www.barnhardt.biz/");
            string text = "A class is the most powerful data type in C#. Like a structure " +
                "a class defines the data behavior of the program";

            File.WriteAllText(@"C:\Users\Cubit32\Desktop\coding\ITVitae\assembliesAndNamespaces\writeText.txt", text);
            File.WriteAllText(@"C:\Users\Cubit32\Desktop\coding\ITVitae\assembliesAndNamespaces\website.txt", reply);

            Console.WriteLine("Hello moon!");
            Console.ReadLine();
        }
    }
}
