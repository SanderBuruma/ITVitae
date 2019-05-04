using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace _3Encryption
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

        private void ButtonSelectFile_Click(object sender, RoutedEventArgs e)
        {
            OpenFileDialog dlg = new OpenFileDialog
            {
                DefaultExt = ".txt",
                Filter = "Text Files (*.txt)|*.txt"
            };

            Nullable<bool> result = dlg.ShowDialog();

            if (result == true)
            {
                FilepathBox.Text = dlg.FileName;
            }
        }

        private void ButtonRngKey_Click(object sender, RoutedEventArgs e)
        {
            Random rng = new Random();
            EncodeKeyBox.Text = rng.Next().ToString();
        }

        private void ButtonEncrypt_Click(object sender, RoutedEventArgs e)
        {
            if (FilepathBox.Text.Length == 0)
            {
                MessageBox.Show("Please select a file to encrypt");
                return;
            }
            if (!new Regex(@"\.txt$").IsMatch(FilepathBox.Text))
            {
                MessageBox.Show("Please select a *.txt file");
                return;
            }
            if (EncodeKeyBox.Text.Length == 0)
            {
                MessageBox.Show("Please input an integer key");
                return;
            }
            if (!Int32.TryParse(EncodeKeyBox.Text, out int seed))
            {
                MessageBox.Show("Please input an integer key");
                return;
            }

            Random rng = new Random(seed);
            string encryptString = "";
            char[] fileChars = File.ReadAllText(FilepathBox.Text).ToCharArray();

            for (int i = 0; i < fileChars.Length; i++)
            {
                int j = (fileChars[i] + rng.Next(0, 256)) % 256;
                encryptString += (char)j;
            }

            File.WriteAllText(FilepathBox.Text, encryptString);
            MessageBox.Show("File was successfully encrypted with integer key: " + seed + ". Please save it and use it in the future to decrypt the file.");

        }

        private void ButtonDeEncrypt_Click(object sender, RoutedEventArgs e)
        {
            if (FilepathBox.Text.Length == 0)
            {
                MessageBox.Show("Please select a file to decrypt");
                return;
            }
            if (!new Regex(@"\.txt$").IsMatch(FilepathBox.Text))
            {
                MessageBox.Show("Please select a *.txt file");
                return;
            }
            if (EncodeKeyBox.Text.Length == 0)
            {
                MessageBox.Show("Please input an integer key");
                return;
            }
            if (!Int32.TryParse(EncodeKeyBox.Text, out int seed))
            {
                MessageBox.Show("Please input an integer key");
                return;
            }

            Random rng = new Random(seed);
            string decryptString = "";
            char[] fileChars = File.ReadAllText(FilepathBox.Text).ToCharArray();

            for (int i = 0; i < fileChars.Length; i++)
            {
                int j = (fileChars[i] + (256 - rng.Next(0, 256))) % 256;
                decryptString += (char)j;
            }

            File.WriteAllText(FilepathBox.Text, decryptString);
            MessageBox.Show("File was successfully decrypted. Please check its content to see whether or not you used the correct decryption key.");
        }
    }
}
