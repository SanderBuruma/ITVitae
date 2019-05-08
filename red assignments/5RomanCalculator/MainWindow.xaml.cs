using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
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

namespace _5RomanCalculator
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private readonly Dictionary<string, int> RomanNumerals = new Dictionary<string, int> {
            {"MMM", 3000},
            {"MM", 2000},
            {"M", 1000},
            {"CM", 900},
            {"DCCC", 800},
            {"DCC", 700},
            {"DC", 600},
            {"D", 500},
            {"CD", 400},
            {"CCC", 300},
            {"CC", 200},
            {"C", 100},
            {"XC", 90},
            {"LXXX", 80},
            {"LXX", 70},
            {"LX", 60},
            {"L", 50},
            {"XL", 40},
            {"XXX", 30},
            {"XX", 20},
            {"X", 10},
            {"IX", 9},
            {"VIII", 8},
            {"VII", 7},
            {"VI", 6},
            {"V", 5},
            {"IV", 4},
            {"III", 3},
            {"II", 2},
            {"I", 1}
        };
        private readonly Regex NonRomanRgx = new Regex("[^IVXLCDM]");
        private int CalcOperator = 0;

        public MainWindow()
        {
            InitializeComponent();
        }

        private int RomanToInt(string input)
        {
            int number = 0;
            foreach (KeyValuePair<string, int> entry in RomanNumerals)
            {
                Regex rgx = new Regex("^" + entry.Key);
                if (rgx.IsMatch(input))
                {
                    number += entry.Value;
                    input = input.Substring(entry.Key.Length);
                }
            }
            if (input.Length > 0)
            {
                MessageBox.Show("Invalid Roman numeral, returning integer 0.");
                return 0;
            }
            return number;
        }

        private string IntToRoman(int input)
        {
            string romanNumeral = "";
            foreach (KeyValuePair<string, int> entry in RomanNumerals)
            {
                if (entry.Value <= input)
                {
                    romanNumeral += entry.Key;
                    input -= entry.Value;
                }
            }
            return romanNumeral;
        }

        private void Calculate()
        {
            int val1 = RomanToInt(Value1Box.Text);
            int val2 = RomanToInt(Value2Box.Text);
            int valOut = 0;
            switch (CalcOperator)
            {
                case 0:
                    valOut = val1 + val2;
                    break;
                case 1:
                    valOut = val1 - val2;
                    break;
                case 2:
                    valOut = val1 * val2;
                    break;
                case 3:
                    valOut = val1 / val2;
                    break;
                default:
                    valOut = 0;
                    break;
            }
            if (valOut > 3999)
                MessageBox.Show("This calculator is not meant to work with values greater than 4000, the output may be incorrect");
            OutputBox.Text = IntToRoman(valOut);
        }

        private void RadioAdd_Checked(object sender, RoutedEventArgs e)
        {
            CalcOperator = 0;
            OperatorLabel.Content = "+";
        }

        private void RadioSub_Checked(object sender, RoutedEventArgs e)
        {
            CalcOperator = 1;
            OperatorLabel.Content = "-";
        }

        private void RadioMult_Checked(object sender, RoutedEventArgs e)
        {
            CalcOperator = 2;
            OperatorLabel.Content = "*";
        }

        private void RadioDiv_Checked(object sender, RoutedEventArgs e)
        {
            CalcOperator = 3;
            OperatorLabel.Content = "/";
        }

        private void CalculateButton_Click(object sender, RoutedEventArgs e)
        {
            Calculate();
        }

        private void Value1Box_LostFocus(object sender, RoutedEventArgs e)
        {
            if (NonRomanRgx.IsMatch(Value1Box.Text))
            {
                MessageBox.Show("Please input a valid roman numeral!");
                Value1Box.Text = "";
            }
        }

        private void Value2Box_LostFocus(object sender, RoutedEventArgs e)
        {
            if (NonRomanRgx.IsMatch(Value2Box.Text))
            {
                MessageBox.Show("Please input a valid roman numeral!");
                Value2Box.Text = "";
            }
        }
    }
}
