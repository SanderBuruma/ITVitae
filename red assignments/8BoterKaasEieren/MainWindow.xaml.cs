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

namespace _8BoterKaasEieren
{
    public partial class MainWindow : Window
    {
        private int FieldHeight;
        private int FieldWidth;
        private int?[,] TheField;
        private Label[] FieldLabels;
        private readonly char[] PlayerChar = new char[2] { '0', 'X' };
        private int PlayerTurn = 0;
        private readonly int fieldLabelWidthHeight = 80;

        public MainWindow()
        {
            InitializeComponent();
            Reset();
        }

        private void Reset()
        {
            PlayerTurn = 0;
            UpdateMessage(PlayerChar[PlayerTurn] + "'s turn");

            FieldWidth = int.Parse(FieldWidthTextBox.Text);
            FieldHeight = int.Parse(FieldHeightTextBox.Text);

            MainWindow1.Height = 200 + fieldLabelWidthHeight * FieldHeight;
            MainWindow1.Width = Math.Max(100 + fieldLabelWidthHeight * FieldWidth, 300);

            //generate 2D field array
            TheField = new int?[FieldWidth, FieldHeight];

            //generate field labels
            if (FieldLabels != null)
            {
                for (int i = 0; i < FieldLabels.Count(); i++)
                {
                    MainGrid.Children.Remove(FieldLabels[i]);
                    FieldLabels[i] = null;
                }
            }
            FieldLabels = new Label[FieldHeight * FieldWidth];
            for (int i = 0; i < FieldHeight * FieldWidth; i++)
                FieldLabels[i] = AddFieldLabel(i);

        }

        private Label AddFieldLabel(int i)
        {
            int r, t;
            if (i % FieldWidth < FieldWidth - 1)
                r = 2;
            else
                r = 0;

            if (i / FieldWidth < FieldHeight - 1)
                t = 2;
            else
                t = 0;

            Label lbl = new Label
            {
                Padding = new Thickness(0, 0, 0, 4),
                Name = "Field" + i,
                Uid = i.ToString(),
                BorderThickness = new Thickness(0, t, r, 0),
                BorderBrush = Brushes.Black,
                Background = Brushes.White,
                FontSize = fieldLabelWidthHeight*.4,
                Width = fieldLabelWidthHeight,
                Height = fieldLabelWidthHeight,
                HorizontalContentAlignment = HorizontalAlignment.Center,
                VerticalContentAlignment = VerticalAlignment.Center,
                HorizontalAlignment = HorizontalAlignment.Center,
                VerticalAlignment = VerticalAlignment.Bottom,
                Margin = new Thickness(
                    i % FieldWidth * fieldLabelWidthHeight*2 - fieldLabelWidthHeight * (FieldWidth - 1), 
                    0,
                    0,
                    i / FieldWidth * fieldLabelWidthHeight + fieldLabelWidthHeight/5),
            };
            MainGrid.Children.Add(lbl);
            return lbl;
        }

        private void HandleFieldLabelClick(int i)
        {
            if (TheField[i % FieldWidth, i / FieldWidth] == null)
            {
                TheField[i % FieldWidth, i / FieldWidth] = PlayerTurn;
                FieldLabels[i].Content = PlayerChar[PlayerTurn];
                PlayerTurn++;
                PlayerTurn %= 2;
                UpdateMessage(PlayerChar[PlayerTurn] + "'s turn");
                CheckForGameOver();
            }
            else
                MessageBox.Show("Field " + i.ToString() + " is already occupied");
        }

        /*
         * In this method I try to account for changeable field widths and heights
         */
        private void CheckForGameOver()
        {
            string VerticalString = "";
            string HorizontalString = "";
            for (int i = 0; i < FieldHeight * FieldWidth; i++)
            {
                if (i % FieldWidth == 0)
                    HorizontalString += ",";
                if (i % FieldHeight == 0)
                    VerticalString += ",";

                if (TheField[i % FieldWidth, i / FieldWidth] == null)
                    HorizontalString += " ";
                if (TheField[i / FieldHeight, i % FieldHeight] == null)
                    VerticalString += " ";
                if (TheField[i % FieldWidth, i / FieldWidth] == 0)
                    HorizontalString += "0";
                if (TheField[i / FieldHeight, i % FieldHeight] == 0)
                    VerticalString += "0";
                if (TheField[i % FieldWidth, i / FieldWidth] == 1)
                    HorizontalString += "1";
                if (TheField[i / FieldHeight, i % FieldHeight] == 1)
                    VerticalString += "1";
            }
            VerticalString += ",";
            HorizontalString += ",";

            Regex rgxSpace = new Regex("^[^ ]+$");
            Regex rgx0 = new Regex("(,0+,|0{5,})");
            Regex rgx1 = new Regex("(,1+,|1{5,})");
            if (rgx0.IsMatch(VerticalString) || rgx0.IsMatch(HorizontalString))
            {
                GameOver(0);
                return;
            }
            if (rgx1.IsMatch(VerticalString) || rgx1.IsMatch(HorizontalString))
            {
                GameOver(1);
                return;
            }
            //The game is a draw
            if (rgxSpace.IsMatch(VerticalString))
            {
                GameOver();
                return;
            }

            string[] DiagonalStrings = new string[2] {"", ""};
            if (FieldHeight <= FieldWidth)
            {
                for (int i = 0; i < FieldWidth - FieldHeight + 1; i++)
                {
                    for (int j = 0; j < FieldHeight; j++)
                    {
                        if (j == 0)
                        {
                            DiagonalStrings[0] += ",";
                            DiagonalStrings[1] += ",";
                        }
                        if (TheField[i + j, j] != null)
                            DiagonalStrings[0] += TheField[i + j, j];
                        else
                            DiagonalStrings[0] += " ";
                        if (TheField[i + j, FieldHeight - 1 - j] != null)
                            DiagonalStrings[1] += TheField[i + j, FieldHeight - 1 - j];
                        else
                            DiagonalStrings[1] += " ";
                    }
                }
                for (int k = 0; k < 2; k++)
                {
                    DiagonalStrings[k] += ",";
                    if (rgx0.IsMatch(DiagonalStrings[k]))
                    {
                        GameOver(0);
                        return;
                    }
                    if (rgx1.IsMatch(DiagonalStrings[k]))
                    {
                        GameOver(1);
                        return;
                    }
                }
            }
            else
                MessageBox.Show("Please message the developer and remind him or her to ensure that the field width is not less than field height");
        }

        private void GameOver()
        {
            MessageBox.Show("Draw :(, restarting game...");
            Reset();
        }
        private void GameOver(int playerNum)
        {
            MessageBox.Show("Player " + PlayerChar[playerNum] + " won!");
            Reset();
        }

        private void UpdateMessage(string msg)
        {
            MessageLabel1.Content = msg;
        }

        /*
         * the recursive calls should not be able to go more than 2 stacks deep
         */
        private void CheckFieldSizeParameterBox(TextBox field, bool b = false)
        {
            Regex rgx = new Regex("[^0-9]");
            if (rgx.IsMatch(field.Text))
            {
                if (!b) MessageBox.Show("This box only accepts integers");
                field.Text = "3";
                CheckFieldSizeParameterBox(field, true);
                return;
            }
            if (int.Parse(field.Text) < 3)
            {
                if (!b) MessageBox.Show("This box only accepts integers larger than 2");
                field.Text = "3";
                CheckFieldSizeParameterBox(field, true);
                return;
            }
            if (int.Parse(field.Text) > 15)
            {
                if (!b) MessageBox.Show("This box only accepts integers smaller than 16");
                field.Text = "3";
                CheckFieldSizeParameterBox(field, true);
                return;
            }
            if (int.Parse(FieldHeightTextBox.Text) > int.Parse(FieldWidthTextBox.Text))
            {
                if (!b) MessageBox.Show("Height may not be larger than width");
                FieldHeightTextBox.Text = FieldWidthTextBox.Text;
                return;
            }
        }

        private void MainGrid_MouseDown(object sender, MouseButtonEventArgs e)
        {
            foreach (Label lbl in FieldLabels)
            {
                //field label was clicked.
                if (e.Source.Equals(lbl))
                {
                    int i = int.Parse(lbl.Uid);
                    HandleFieldLabelClick(i);
                    break;
                }
            }
        }

        private void NewGameButton_Click(object sender, RoutedEventArgs e)
        {
            Reset();
        }

        private void FieldWidthTextBox_KeyUp(object sender, KeyEventArgs e)
        {
            CheckFieldSizeParameterBox(FieldWidthTextBox);
        }

        private void FieldHeightTextBox_KeyUp(object sender, KeyEventArgs e)
        {
            CheckFieldSizeParameterBox(FieldHeightTextBox);
        }

        private void InfoButton1_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("Place your X or O from one side to the other side horizontally, vertically or diagonally. Getting 5 in a row in any direction also scores you a win (if the field is big enough)");
        }
    }
}
