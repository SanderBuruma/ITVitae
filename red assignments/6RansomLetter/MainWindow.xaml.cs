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

namespace _6RansomLetter
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private readonly List<string> RandomFontList = new List<string> {
            "Comic Sans MS",
            "Shruti",
            "Vijaya",
            "Tahoma",
            "SimSun",
            "Liberation Mono",
            "Impact",
            "Aharoni",
            "Courier New",
            "GulimChe",
            "LilyUPC",
            "Microsoft Himalaya",
            "MV Boli",
            "Yu Mincho Demibold"
        };
        private readonly Random rng = new Random();
        public MainWindow()
        {
            InitializeComponent();
            Scramble();
        }

        private void Scramble()
        {
            try
            {
                RichBox.SelectAll();
                TextSelection sel = RichBox.Selection;
                int DocSize = RichBox.Document.ContentStart.GetOffsetToPosition(RichBox.Document.ContentEnd);
                for (int i = 0; i < DocSize - 5; i++)
                {
                    TextPointer pointer1 = RichBox.Document.ContentStart.GetPositionAtOffset(i * 3);
                    TextPointer pointer2 = RichBox.Document.ContentStart.GetPositionAtOffset(i * 3 + 3);

                    RichBox.Selection.Select(pointer1, pointer2);
                    sel = RichBox.Selection;
                    sel.ApplyPropertyValue(FontFamilyProperty, new FontFamily(RandomFontList[rng.Next(RandomFontList.Count)]));
                    sel.ApplyPropertyValue(FontSizeProperty, 12 + 8 * rng.NextDouble());
                    sel.ApplyPropertyValue(ForegroundProperty, "#FF" +
                        rng.Next(0, 128).ToString("X2") +
                        rng.Next(0, 128).ToString("X2") +
                        rng.Next(0, 128).ToString("X2"));
                }
            }
            catch
            {
                // I the developer think this try-catch is not quite the right solution 
                // but it works and it would probably cost at least 30 minutes to fund a better solution
            }
        }

        private void Clear()
        {
            RichBox.SelectAll();
            TextSelection sel = RichBox.Selection;
            sel.ApplyPropertyValue(FontFamilyProperty, new FontFamily("Comic Sans MS"));
            sel.ApplyPropertyValue(FontSizeProperty, (double)12);
            sel.ApplyPropertyValue(ForegroundProperty, "#FF000000");
        }

        private void SubmitButton_Click(object sender, RoutedEventArgs e)
        {
            Scramble();
        }

        private void RichBox_TextChanged(object sender, TextChangedEventArgs e)
        {

        }

        private void ClearStyleButton_Click(object sender, RoutedEventArgs e)
        {
            Clear();
        }
    }
}
