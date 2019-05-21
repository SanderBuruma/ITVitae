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

namespace _10TowerOfHanoi
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private Label[] SliceImages = new Label[8];
        private string[] SliceStacks;
        //for drag info capturing purposes
        private int MouseDownI;
        private int MouseUpI;
        private int Moves;

        public MainWindow()
        {
            InitializeComponent();

            List<SolidColorBrush> Brshs = new List<SolidColorBrush>
            {
                Brushes.Black,
                Brushes.Purple,
                Brushes.Blue,
                Brushes.Green,
                Brushes.Yellow,
                Brushes.Orange,
                Brushes.Red,
                Brushes.Black,
            };

            //create slices
            for (int i = 0; i < 8; i++)
            {
                SliceImages[i] = new Label {
                    Height = 20,
                    Content = "",
                    Width = 30 + 15 * i,
                    Background = Brshs[i%Brshs.Count],
                    BorderThickness = new Thickness(1),
                    HorizontalAlignment = HorizontalAlignment.Left,
                    VerticalAlignment = VerticalAlignment.Bottom,
                };
                MainGrid.Children.Add(SliceImages[i]);
            }

            Reset();
            MoveSlices();
        }

        private void Reset()
        {
            Moves = 0;
            MouseDownI = 0;
            MouseUpI = 0;
            SliceStacks = new string[] {
                "76543210", //first character represents the bottom of the stack and the widest slice
                "",
                ""
            };
        }

        /*
         * invoke when slices are moved
         */
        private void MoveSlices()
        {
            for (int i = SliceImages.Length-1; i>=0; i--)
            {
                for (int j = 0; j < SliceStacks.Length; j++)
                {
                    int indexOf = SliceStacks[j].IndexOf(i.ToString());
                    if (indexOf > -1)
                    {
                        SliceImages[i].Margin = new Thickness(70 - 7.5 * i + 175 * j, 0, 0, 10 + indexOf * 22);
                    }
                }
            }
        }

        private void MoveSlice()
        {
            if (MouseUpI == MouseDownI)
                return;
            if (MouseDownI >= SliceStacks.Length || MouseDownI < 0)
                return;
            if (MouseUpI >= SliceStacks.Length || MouseUpI < 0)
                return;
            if (SliceStacks[MouseDownI].Length == 0)
                return;

            char[] FromStackChars = SliceStacks[MouseDownI].ToCharArray();
            char[] ToStackChars = SliceStacks[MouseUpI].ToCharArray();

            if (SliceStacks[MouseUpI].Length != 0 &&
                !(FromStackChars[FromStackChars.Count() - 1] < ToStackChars[ToStackChars.Count() - 1]))
                return;

            SliceStacks[MouseUpI] += FromStackChars[FromStackChars.Count() - 1].ToString();
            SliceStacks[MouseDownI] = SliceStacks[MouseDownI].Substring(0, SliceStacks[MouseDownI].Length - 1);
            Moves++;
            MoveSlices();
            CheckGameOver();
        }

        private void CheckGameOver()
        {
            if (SliceStacks[SliceStacks.Length-1] == "76543210")
            {
                MessageBox.Show("Congratlations! You moved the tower of Hanoi to its new home! And you did it in only " + Moves.ToString() + " moves!");
                Reset();
                MoveSlices();
            }
        }

        private void MainWindow1_MouseDown(object sender, MouseButtonEventArgs e)
        {
            Point point = e.GetPosition(this.MainGrid);
            MouseDownI = (int)Math.Floor(point.X / 175);
        }

        private void MainWindow1_MouseUp(object sender, MouseButtonEventArgs e)
        {
            Point point = e.GetPosition(this.MainGrid);
            MouseUpI = (int)Math.Floor(point.X / 175);
            MoveSlice();
        }

        private void HelpButton_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("The classic Tower of Hanoi game. Move all the slices 1 at a time to the far right. Bigger slices may never be placed on top of smaller ones, good luck!");
        }
    }
}
