using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace _9MorseCode
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {

        private Dictionary<char, string> Dict {get; set;}

        public MainWindow()
        {
            Dict = new Dictionary<char, string> { };
            Dict.Add('a', ".- ");
            Dict.Add('b', "-... ");
            Dict.Add('c', "-.-. ");
            Dict.Add('d', "-.. ");
            Dict.Add('e', ". ");
            Dict.Add('f', "..-. ");
            Dict.Add('g', "--. ");
            Dict.Add('h', ".... ");
            Dict.Add('i', ".. ");
            Dict.Add('j', ".--- ");
            Dict.Add('k', "-.- ");
            Dict.Add('l', ".-.. ");
            Dict.Add('m', "-- ");
            Dict.Add('n', "-. ");
            Dict.Add('o', "--- ");
            Dict.Add('p', ".--. ");
            Dict.Add('q', "--.- ");
            Dict.Add('r', ".-. ");
            Dict.Add('s', "... ");
            Dict.Add('t', "- ");
            Dict.Add('u', "..- ");
            Dict.Add('w', ".-- ");
            Dict.Add('x', "-..- ");
            Dict.Add('y', "-.-- ");
            Dict.Add('z', "--.. ");
            Dict.Add('0', "----- ");
            Dict.Add('1', "----. ");
            Dict.Add('2', "---.. ");
            Dict.Add('3', "--... ");
            Dict.Add('4', "-.... ");
            Dict.Add('5', "..... ");
            Dict.Add('6', "-.... ");
            Dict.Add('7', "--... ");
            Dict.Add('8', "---.. ");
            Dict.Add('9', "----. ");
            Dict.Add(' ', "/ ");
            InitializeComponent();
        }

        private void Button2Plain_Click(object sender, RoutedEventArgs e)
        {
            char[] morseCodeChars = MorseCodeBox.Text.ToCharArray();
            string word = "";
            string returnString = "";

            foreach (char c in morseCodeChars)
            {
                word += c;
                if (c == ' ')
                {
                    foreach (KeyValuePair<char, string> kvp in Dict)
                    {
                        if (word == kvp.Value)
                        {
                            returnString += kvp.Key;
                            break;
                        }
                    }
                    word = "";
                }
            }

            PlainTextBox.Text = returnString;
        }

        private void Button2Morse_Click(object sender, RoutedEventArgs e)
        {
            char[] plainTextChars = PlainTextBox.Text.ToCharArray();
            string returnStr = "";

            foreach (char c in plainTextChars)
            {
                char x = char.ToLower(c);
                foreach (KeyValuePair<char, string> kvp in Dict)
                {
                    if (x == kvp.Key)
                    {
                        returnStr += kvp.Value;
                        break;
                    }
                }
            }

            MorseCodeBox.Text = returnStr;
        }
    }
}
