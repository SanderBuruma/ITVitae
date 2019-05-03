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

namespace _1Calculator
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private string Val1 { get; set; }
        private string Val2 { get; set; }
        private string ValMem { get; set; }
        private bool DecimalsBeingInput { get; set; }
        private int CalcOperator { get; set; }
        public MainWindow()
        {
            InitializeComponent();
            Val1 = "0";
            Val2 = "0";
            ValMem = "0";
            DecimalsBeingInput = false;
            CalcOperator = (int)Operator.add;
        }

        private void Button_0_Click(object sender, RoutedEventArgs e)
        {
            AddNumber("0");
        }
        private void Button_1_Click(object sender, RoutedEventArgs e)
        {
            AddNumber("1");
        }

        private void Button_2_Click(object sender, RoutedEventArgs e)
        {
            AddNumber("2");
        }

        private void Button_3_Click(object sender, RoutedEventArgs e)
        {
            AddNumber("3");
        }

        private void Button_4_Click(object sender, RoutedEventArgs e)
        {
            AddNumber("4");
        }

        private void Button_5_Click(object sender, RoutedEventArgs e)
        {
            AddNumber("5");
        }

        private void Button_6_Click(object sender, RoutedEventArgs e)
        {
            AddNumber("6");
        }

        private void Button_7_Click(object sender, RoutedEventArgs e)
        {
            AddNumber("7");
        }

        private void Button_8_Click(object sender, RoutedEventArgs e)
        {
            AddNumber("8");
        }

        private void Button_9_Click(object sender, RoutedEventArgs e)
        {
            AddNumber("9");
        }

        private void Button_MemoryOut_Click(object sender, RoutedEventArgs e)
        {
            //todo
        }

        private void Button_MemoryIn_Click(object sender, RoutedEventArgs e)
        {
            //todo
        }

        private void Button_Multiply_Click(object sender, RoutedEventArgs e)
        {
            CalcOperator = (int)Operator.multiply;
            MoveVals();
        }

        private void Button_Divide_Click(object sender, RoutedEventArgs e)
        {
            CalcOperator = (int)Operator.divide;
            MoveVals();
        }

        private void Button_Plus_Click(object sender, RoutedEventArgs e)
        {
            CalcOperator = (int)Operator.add;
            MoveVals();
        }

        private void Button_Minus_Click(object sender, RoutedEventArgs e)
        {
            CalcOperator = (int)Operator.subtract;
            MoveVals();
        }

        private void Button_Dot_Click(object sender, RoutedEventArgs e)
        {
            if (DecimalsBeingInput)
            {
                DecimalsBeingInput = false;
            }
            else
            {
                DecimalsBeingInput = true;
            }
        }

        private void Button_Calculate_Click(object sender, RoutedEventArgs e)
        {
            Calculate();
        }
        private void Button_Clear_Click(object sender, RoutedEventArgs e)
        {
            Val1 = "0";
            Val2 = "0";
            CalcOperator = (int)Operator.add;
            UpdateOutputBox();
        }

        private void AddNumber (string x)
        {
            string[] splitVal;
            if (Val1.IndexOf(".") > 0)
            {
                splitVal = Val1.Split('.');
            }
            else
            {
                splitVal = new string[] { Val1, "" };
            }


            if (DecimalsBeingInput)
            {
                splitVal[1] += x;
            }
            else
            {
                if (x == "0" && 
                    splitVal[0].Substring(0, 1) == "0")
                    return;
                splitVal[0] += x;
            }

            //remove leading zero
            if (splitVal[0].Length > 1)
                if (splitVal[0].Substring(0, 1) == "0")
                    splitVal[0] = splitVal[0].Substring(1);

            if (splitVal[1].Length > 0)
                Val1 = splitVal[0] + "." + splitVal[1];
            else
                Val1 = splitVal[0];

            UpdateOutputBox();
        }

        private void UpdateOutputBox()
        {
            BoxOutput.Text = Val1;
        }

        private void MoveVals()
        {
            Val2 = Val1;
            Val1 = "0";
            DecimalsBeingInput = false;
            UpdateOutputBox();
        }

        private void Calculate()
        {
            float v1 = float.Parse(Val1);
            float v2 = float.Parse(Val2);
            switch (CalcOperator)
            {
                case (int)Operator.add:
                    v2 += v1;
                    break;
                case (int)Operator.subtract:
                    v2 -= v1;
                    break;
                case (int)Operator.multiply:
                    v2 *= v1;
                    break;
                case (int)Operator.divide:
                    v2 /= v1;
                    break;
                default:
                    break;
            }

            BoxOutput.Text = v2.ToString();
            Val1 = v2.ToString();
            Val2 = "0";
            CalcOperator = (int)Operator.add;
        }

        enum Operator
        {
            add,
            subtract,
            multiply,
            divide
        }

    }
}
