using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.IO;
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

namespace _4CharCount
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }
        private void Button1_Click(object sender, RoutedEventArgs e)
        {
            OpenFileDialog dlg = new OpenFileDialog
            {
                DefaultExt = ".txt",
                Filter = "Text Files (*.txt)|*.txt"
            };

            Nullable<bool> result = dlg.ShowDialog();

            if (result == true)
            {
                string filename = dlg.FileName;
                textBox1.Text = filename;
                int[] charCount = new int[256];
                char[] contentChars = File.ReadAllText(filename).ToCharArray();
                
                TextboxMain.Text = "";
                foreach (char c in contentChars)
                {
                    if ((int)c < 256)
                    {
                        charCount[(int)c]++;
                    }
                }

                string tempString = "";
                for (int i = 20; i < charCount.Length; i++)
                {
                    if (charCount[i] > 0)
                    {
                        tempString += string.Format("\"{0,-1}\": {1,-5}", (char)i, charCount[i]);
                    }
                }

                TextboxMain.Text += tempString;
            }
        }
    }
}
