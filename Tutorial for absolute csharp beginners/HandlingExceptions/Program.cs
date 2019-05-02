using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace HandlingExceptions
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                string content = File.ReadAllText(@"C:\Users\Cubit32\desktop\coding\ITVitae\HandlingExceptions\example.txt");
                Console.WriteLine(content);
            }
            catch (FileNotFoundException e)
            {
                Console.WriteLine("There was a problem!");
                Console.WriteLine("Make sure the name of the file is correct.");
            }
            catch (DirectoryNotFoundException e)
            {
                Console.WriteLine("There was a problem!");
                Console.WriteLine("Make sure the path to the directory is correct.");
            }
            catch (Exception e) {
                Console.WriteLine(e);
            }
            finally
            {
                Console.WriteLine("Closing application now...");
                Console.ReadLine();
            }
        }
    }
}
