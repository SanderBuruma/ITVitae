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

namespace _7Yahtzee
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>

    public partial class MainWindow : Window
    {
        public int Round { get; set; }
        private List<int> Scores { get; set; }
        public List<int> DiceValues { get; set; }
        private Random Rng { get; set; }
        private Image[] Dice { get; set; }
        private CheckBox[] DiceCheckboxes { get; set; }

        public MainWindow()
        {
            InitializeComponent();
            Initiate();
        }

        public void Initiate()
        {
            // the first 13 are player 1's score, the next player 2
            Scores = new List<int>();
            for (int i = 0; i < 26; i++)
            {
                Scores.Add(0);
            }

            Round = 0;

            DiceValues = new List<int>();
            for (int i = 0; i < 5; i++)
            {
                DiceValues.Add(0);
            }

            Dice = new Image[5] {
                Dice1,
                Dice2,
                Dice3,
                Dice4,
                Dice5
            };
            DiceCheckboxes = new CheckBox[5] {
                DiceCheckBox1,
                DiceCheckBox2,
                DiceCheckBox3,
                DiceCheckBox4,
                DiceCheckBox5
            };

            Rng = new Random();

            Reset();
        }
        public void Reset()
        {
            Round = 0;
            for (int i = 0; i < 26; i++)
            {
                Scores[i] = 0;
            }
        }

        public void RollDice()
        {
            for (int i = 0; i < 5; i++)
            {

                // if this is NOT the first dice roll of a player's round and they're not fixed in place
                if (Round % 3 == 0 || DiceCheckboxes[i].IsChecked != true)
                {
                    DiceValues[i] = Rng.Next(1, 7);
                    var uri = new Uri(@"/7Yahtzee;component/Resources/Dice/" + DiceValues[i] + ".png", UriKind.Relative);
                    Dice[i].Source = new BitmapImage(uri);
                }
            }



            Round++;
            Round %= 6;

            if (Round < 3)
                Message1(Player1NameBox + "'s turn");
            else
                Message1(Player2NameBox + "'s turn");
            Message2("Turn: " + Round.ToString());
        }

        public void Message1(string msg)
        {
            MessageToPlayerLabel1.Content = msg;
        }
        public void Message2(string msg)
        {
            MessageToPlayerLabel2.Content = msg;
        }

        private void RollDiceButton_Click(object sender, RoutedEventArgs e)
        {
            RollDice();
        }
        enum ScoreableTypes
        {
            Ones,
            Twos,
            Threes,
            Fours,
            Fives,
            Sixes,
            ThreeOfAKind,
            FourOfAKind,
            FullHouse,
            SmallStraight,
            LargeStraight,
            Chance,
            Yahtzee
        }

    }

}
