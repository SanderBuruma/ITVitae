using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
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

namespace _2Flags
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private List<string> FlagStrings { get; set; }
        private List<int> FlagNrs { get; set; }
        private int CorrectAnswer { get; set; }
        private int Score { get; set; }
        public MainWindow()
        {
            InitializeComponent();

            string resource_data = Properties.Resources.flaglist;
            List<string> strings = resource_data.Split(new[] { Environment.NewLine }, StringSplitOptions.RemoveEmptyEntries).ToList();
            FlagStrings = new List<string> { };
            foreach (string s in strings)
            {
                FlagStrings.Add(s);
            }

            FlagNrs = new List<int> { };
            for (int i = 0; i < FlagStrings.Count(); i++)
            {
                FlagNrs.Add(i);
            }

            Reset();
        }

        private void Reset()
        {
            ChangeScore(0);
            ChangeFlagAndAnswers();
        }

        private void ChangeScore(int i)
        {
            Score = i;
            ScoreLabel.Content = "Score: " + Score;
        }

        private void ChangeFlagAndAnswers()
        {
            FlagNrs = FlagNrs.OrderBy(a => Guid.NewGuid()).ToList();
            Random rng = new Random();
            CorrectAnswer = rng.Next(4);
            string answerFlagPath = FlagStrings[FlagNrs[CorrectAnswer]].Split('%')[0];

            var uriSource = new Uri(@"/2Flags;component/Resources/Flags/" + answerFlagPath, UriKind.Relative);
            FlagImage.Source = new BitmapImage(uriSource);

            Radio1.Content = FlagStrings[FlagNrs[0]].Split('%')[1];
            Radio2.Content = FlagStrings[FlagNrs[1]].Split('%')[1];
            Radio3.Content = FlagStrings[FlagNrs[2]].Split('%')[1];
            Radio4.Content = FlagStrings[FlagNrs[3]].Split('%')[1];

        }

        private void Radio1_Checked(object sender, RoutedEventArgs e)
        {
            Radio1.IsChecked = false;
            MakeGuess(0);
        }

        private void Radio2_Checked(object sender, RoutedEventArgs e)
        {
            Radio2.IsChecked = false;
            MakeGuess(1);
        }

        private void Radio3_Checked(object sender, RoutedEventArgs e)
        {
            Radio3.IsChecked = false;
            MakeGuess(2);
        }

        private void Radio4_Checked(object sender, RoutedEventArgs e)
        {
            Radio4.IsChecked = false;
            MakeGuess(3);
        }

        private void MakeGuess(int guess)
        {
            if (CorrectAnswer != guess)
            {
                MessageBox.Show("Your guess was wrong! The correct answer was " + FlagStrings[FlagNrs[CorrectAnswer]].Split('%')[1]
                    + "\n\nYour final score is " + Score.ToString());
                ChangeScore(0);
            }
            else
            {
                ChangeScore(Score+10);
            }
            ChangeFlagAndAnswers();

        }
    }
}
