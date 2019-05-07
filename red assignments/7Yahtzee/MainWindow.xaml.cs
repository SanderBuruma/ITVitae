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
        private bool ScoringPossible { get; set; }
        private bool CanRoll { get; set; }
        private bool GameOver { get; set; }
        private int?[] Scores { get; set; }
        public List<int> DiceValues { get; set; }
        private Random Rng { get; set; }
        private Image[] Dice { get; set; }
        private CheckBox[] DiceCheckboxes { get; set; }
        private Label[] ScoreableLabels { get; set; }
        private int[] ScoreablePoints { get; set; }

        public MainWindow()
        {
            InitializeComponent();
            Initiate();
        }

        public void Initiate()
        {
            // the first 13 are player 1's scores, the next player 2's scores
            Scores = new int?[26]
            {
                    null,null,null,null,null,null,null,null,null,null,null,null,null,null,null,null,null,null,null,null,null,null,null,null,null,null
            };
            ScoreablePoints = new int[13]
            {
                0,0,0,0,0,0,0,0,0,0,0,0,0
            };

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
            ScoreableLabels = new Label[26]{
                OnesP1ValueLabel,
                TwosP1ValueLabel,
                ThreesP1ValueLabel,
                FoursP1ValueLabel,
                FivesP1ValueLabel,
                SixesP1ValueLabel,
                ThreeOfAKindP1Label,
                FourOfAKindP1Label,
                FullHouseP1Label,
                SmallStraightP1Label,
                LargeStraightP1Label,
                ChanceP1Label,
                YahtzeeP1Label,
                OnesP2ValueLabel,
                TwosP2ValueLabel,
                ThreesP2ValueLabel,
                FoursP2ValueLabel,
                FivesP2ValueLabel,
                SixesP2ValueLabel,
                ThreeOfAKindP2Label,
                FourOfAKindP2Label,
                FullHouseP2Label,
                SmallStraightP2Label,
                LargeStraightP2Label,
                ChanceP2Label,
                YahtzeeP2Label
            };

            Rng = new Random();

            Reset();
        }
        public void Reset()
        {
            ScoringPossible = false;
            CanRoll = true;
            GameOver = false;
            Round = 0;
            for (int i = 0; i < 26; i++)
            {
                Scores[i] = null;
            }
            Message1();
            Message2();

            SumP1Label.Content = "";
            SumP2Label.Content = "";
            BonusP1Label.Content = "";
            BonusP2Label.Content = "";
            GrandTotalP1Label.Content = "";
            GrandTotalP2Label.Content = "";
        }

        private void RollDice()
        {
            if (!CanRoll)
            {
                MessageBox.Show("You can't roll right now");
                return;
            }

            if (GameOver)
            {
                MessageBox.Show("It's game over, please start a new game!");
                return;
            }

            if (Round % 3 == 1)
                CanRoll = false;
            else
                CanRoll = true;

            if (ScoringPossible)
                Round++;
            ScoringPossible = true;

            Message1();
            Message2();

            for (int i = 0; i < 5; i++)
                if (Round % 3 == 0 || DiceCheckboxes[i].IsChecked != true)
                {
                    DiceValues[i] = Rng.Next(1, 7);
                    var uri = new Uri(@"/7Yahtzee;component/Resources/Dice/" + DiceValues[i] + ".png", UriKind.Relative);
                    Dice[i].Source = new BitmapImage(uri);
                }

            int[] DiceCounts = new int[6];
            //count the types of dice
            for (int i = 0; i < 5; i++)
                DiceCounts[DiceValues[i] - 1]++;

            //calculate scoreable points
            int count = 1;
            int PointsSum = 0;
            int StraightLength = 0;
            ScoreablePoints = new int[13];
            foreach (int i in DiceCounts)
            {
                if (i > 0)
                    StraightLength++;
                else
                    StraightLength = 0;

                //small straight
                if (StraightLength > 3)
                    ScoreablePoints[9] = 30;
                //large straight
                if (StraightLength > 4)
                    ScoreablePoints[10] = 40;

                ScoreablePoints[count - 1] = count * i;
                PointsSum += count * i;

                count++;
            }
            ScoreablePoints[11] = PointsSum;

            foreach (int i in DiceCounts)
            {
                if (i > 2)
                { 
                    //three of a kind
                    ScoreablePoints[6] = PointsSum;

                        
                    foreach (int j in DiceCounts)
                        if (j == 2)
                            //full house
                            ScoreablePoints[8] = 25;
                }

                if (i > 3)
                {
                    //four of a kind
                    ScoreablePoints[7] = PointsSum;

                }
                if (i > 4)
                {
                    //Yahtzee
                    ScoreablePoints[12] = 50;
                    bool b = false;
                    if (Round < 3 && Scores[12] != null)
                    {
                        b = true;
                        Scores[12] += 100;
                        YahtzeeP1Label.Content = Scores[12].ToString();
                    }
                    else if (Round > 2 && Scores[25] != null)
                    {
                        b = true;
                        Scores[25] += 100;
                        YahtzeeP1Label.Content = Scores[25].ToString();
                    }
                    if (!b)
                        break;
                    for (int j = 0; j < 13; j++)
                    {
                        if (j < 6)
                            ScoreablePoints[j] = (j + 1) * 5;
                        else if (j == 6 || j == 7 || j == 11)
                            ScoreablePoints[j] = PointsSum;
                        else if (j == 8)
                            ScoreablePoints[j] = 25;
                        else if (j == 9)
                            ScoreablePoints[j] = 30;
                        else if (j == 10)
                            ScoreablePoints[j] = 40;
                    }
                }
            }

            //chance
            ScoreablePoints[11] = PointsSum;

            count = 0;
            //display possible scores
            for (int i = 0; i<26; i++)
            {
                if (Scores[i] == null)
                {
                    ScoreableLabels[i].Content = "";
                }
                ScoreableLabels[i].Opacity = 1;
            }

            //this value determines which side displays the possible scores.
            int coefficient;

            if (Round < 3)
                coefficient = 0;
            else
                coefficient = 13;

            for (int i = coefficient; i < 13 + coefficient; i++)
            {
                if (Scores[i] == null && ScoreablePoints[i%13] > 0)
                {
                    ScoreableLabels[i].Content = ScoreablePoints[i%13].ToString();
                    ScoreableLabels[i].Opacity = 0.5;
                }
                count++;
            }
        }

        public void Message1(string str = "")
        {
            if (str.Length > 0)
                MessageToPlayerLabel1.Content = str;
            else
            {
                if (Round < 3)
                    MessageToPlayerLabel1.Content = Player1NameBox.Text + "'s turn";
                else
                    MessageToPlayerLabel1.Content = Player2NameBox.Text + "'s turn";
            }
        }
        public void Message2(string str = "")
        {
            if (str.Length > 0)
                MessageToPlayerLabel2.Content = str;
            else
            {
                if (!ScoringPossible)
                    MessageToPlayerLabel2.Content = "Roll Dice!";
                else
                    MessageToPlayerLabel2.Content = "Round: " + (Round % 3 + 1).ToString();
            }
        }

        private void ScoreSomething(int key)
        {
            if (!ScoringPossible && !GameOver)
            {
                MessageBox.Show("You can't currently score. Please roll the dice or start a new game.");
                return;
            }
            if (Scores[key] != null)
            {
                MessageBox.Show("This score field is already filled, please choose another one.");
                return;
            }
            if (Round < 3 && key > 12)
            {
                MessageBox.Show("Please choose a score field of the other player!");
                return;
            }
            if (Round > 2 && key < 13)
            {
                MessageBox.Show("Please choose a score field of the other player!");
                return;
            }

            foreach (CheckBox cb in DiceCheckboxes)
                cb.IsChecked = false;

            if (Round > 2)
                Round = 0;
            else
                Round = 3;

            Scores[key] = ScoreablePoints[key%13];
            ScoringPossible = false;
            CanRoll = true;
            UpdateScoreBoard();

            //upper total update & potential upper bonus update
            if (key%13 < 6)
            {
                bool[] b = new bool[2] { true, true };
                int[] sum = new int[2];
                for (int i = 0; i<6; i++)
                {
                    sum[0] += (int)Scores[i];
                    if (Scores[i] == null)
                        b[0] = false;
                    sum[1] += (int)Scores[i + 13];
                    if (Scores[i + 13] == null)
                        b[1] = false;
                }
                if (b[0])
                {
                    SumP1Label.Content = sum[0];
                    if (sum[0] > 62)
                        BonusP1Label.Content = "35";
                }
                if (b[1])
                {
                    SumP2Label.Content = sum[1];
                    if (sum[1] > 62)
                        BonusP2Label.Content = "35";
                }
            }

            //game over check
            bool ScoresContainNull = false;
            foreach (int? i in Scores)
            {
                if (i == null)
                {
                    ScoresContainNull = true;
                    break;
                }
            }
            if (!ScoresContainNull)
            {
                GameOver = true;
                GameOverMethod();
                return;
            }

            Message1();
            Message2();
        }

        private void GameOverMethod()
        {
            int[] sum = new int[2];
            Label[] bonusLabels = new Label[2]
            {
                BonusP1Label,
                BonusP2Label
            };
            Label[] upperTotals = new Label[2]
            {
                SumP1Label,
                SumP2Label
            };
            Label[] grandTotals = new Label[2]
            {
                GrandTotalP1Label,
                GrandTotalP2Label
            };

            for (int i = 0; i < Scores.Length; i++)
            {
                int playerNr = i / 13;

                sum[playerNr] += (int)Scores[i];
                if (i % 13 == 5)
                {
                    if (sum[playerNr] > 62)
                    {
                        sum[playerNr] += 35;
                        bonusLabels[playerNr].Content = 35;
                    }
                    upperTotals[playerNr].Content = sum[playerNr];
                }
                if (i == 12 || i == 25)
                    grandTotals[playerNr].Content = sum[playerNr];
            }

            if (sum[0] > sum[1])
                Message1(Player1NameBox.Text + " wins!");
            else if (sum[0] < sum[1])
                Message1(Player2NameBox.Text + " wins!");
            else
                Message1("Draw, nobody wins...");

            Message2("Game Over!");
        }

        private void UpdateScoreBoard()
        {
            int count = 0;
            foreach (Label l in ScoreableLabels)
            {
                if (Scores[count] != null)
                {
                    l.Content = Scores[count].ToString();
                    l.Opacity = 1;
                }
                else
                    l.Content = "";
                count++;
            }
        }

        private void RollDiceButton_Click(object sender, RoutedEventArgs e)
        {
            RollDice();
        }
        private void NewGameButton_Click(object sender, RoutedEventArgs e)
        {
            Reset();
            UpdateScoreBoard();
        }

        private void OnesP1ValueLabel_MouseDown(object sender, MouseButtonEventArgs e)
        {
            ScoreSomething(0);
        }

        private void TwosP1ValueLabel_MouseDown(object sender, MouseButtonEventArgs e)
        {
            ScoreSomething(1);
        }

        private void ThreesP1ValueLabel_MouseDown(object sender, MouseButtonEventArgs e)
        {
            ScoreSomething(2);
        }

        private void FourP1ValueLabel_MouseDown(object sender, MouseButtonEventArgs e)
        {
            ScoreSomething(3);
        }

        private void FivesP1ValueLabel_MouseDown(object sender, MouseButtonEventArgs e)
        {
            ScoreSomething(4);
        }

        private void SixesP1ValueLabel_MouseDown(object sender, MouseButtonEventArgs e)
        {
            ScoreSomething(5);
        }

        private void ThreeOfAKindP1Label_MouseDown(object sender, MouseButtonEventArgs e)
        {
            ScoreSomething(6);
        }

        private void FourOfAKindP1Label_MouseDown(object sender, MouseButtonEventArgs e)
        {
            ScoreSomething(7);
        }

        private void FullHouseP1Label_Copy_MouseDown(object sender, MouseButtonEventArgs e)
        {
            ScoreSomething(8);
        }

        private void SmallStraightP1Label_MouseDown(object sender, MouseButtonEventArgs e)
        {
            ScoreSomething(9);
        }

        private void LargeStraightP1Label_MouseDown(object sender, MouseButtonEventArgs e)
        {
            ScoreSomething(10);
        }

        private void ChanceP1Label_MouseDown(object sender, MouseButtonEventArgs e)
        {
            ScoreSomething(11);
        }

        private void YahtzeeP1Label_MouseDown(object sender, MouseButtonEventArgs e)
        {
            ScoreSomething(12);
        }

        private void OnesP2ValueLabel_MouseDown(object sender, MouseButtonEventArgs e)
        {
            ScoreSomething(13);
        }

        private void TwosP2ValueLabel_MouseDown(object sender, MouseButtonEventArgs e)
        {
            ScoreSomething(14);
        }

        private void ThreesP2ValueLabel_MouseDown(object sender, MouseButtonEventArgs e)
        {
            ScoreSomething(15);
        }

        private void FourP2ValueLabel_MouseDown(object sender, MouseButtonEventArgs e)
        {
            ScoreSomething(16);
        }

        private void FivesP2ValueLabel_MouseDown(object sender, MouseButtonEventArgs e)
        {
            ScoreSomething(17);
        }

        private void SixesP2ValueLabel_MouseDown(object sender, MouseButtonEventArgs e)
        {
            ScoreSomething(18);
        }

        private void ThreeOfAKindP2Label_MouseDown(object sender, MouseButtonEventArgs e)
        {
            ScoreSomething(19);
        }

        private void FourOfAKindP2Label_MouseDown(object sender, MouseButtonEventArgs e)
        {
            ScoreSomething(20);
        }

        private void FullHouseP2Label_Copy_MouseDown(object sender, MouseButtonEventArgs e)
        {
            ScoreSomething(21);
        }

        private void SmallStraightP2Label_MouseDown(object sender, MouseButtonEventArgs e)
        {
            ScoreSomething(22);
        }

        private void LargeStraightP2Label_MouseDown(object sender, MouseButtonEventArgs e)
        {
            ScoreSomething(23);
        }

        private void ChanceP2Label_MouseDown(object sender, MouseButtonEventArgs e)
        {
            ScoreSomething(24);
        }

        private void YahtzeeP2Label_MouseDown(object sender, MouseButtonEventArgs e)
        {
            ScoreSomething(25);
        }

        private void Dice1_MouseDown(object sender, MouseButtonEventArgs e)
        {
            if (DiceCheckBox1.IsChecked == false)
                DiceCheckBox1.IsChecked = true;
            else
                DiceCheckBox1.IsChecked = false;
        }

        private void Dice2_MouseDown(object sender, MouseButtonEventArgs e)
        {
            if (DiceCheckBox2.IsChecked == false)
                DiceCheckBox2.IsChecked = true;
            else
                DiceCheckBox2.IsChecked = false;
        }

        private void Dice3_MouseDown(object sender, MouseButtonEventArgs e)
        {
            if (DiceCheckBox3.IsChecked == false)
                DiceCheckBox3.IsChecked = true;
            else
                DiceCheckBox3.IsChecked = false;
        }

        private void Dice4_MouseDown(object sender, MouseButtonEventArgs e)
        {
            if (DiceCheckBox4.IsChecked == false)
                DiceCheckBox4.IsChecked = true;
            else
                DiceCheckBox4.IsChecked = false;
        }

        private void Dice5_MouseDown(object sender, MouseButtonEventArgs e)
        {
            if (DiceCheckBox5.IsChecked == false)
                DiceCheckBox5.IsChecked = true;
            else
                DiceCheckBox5.IsChecked = false;
        }

        private void Window_KeyDown(object sender, KeyEventArgs e)
        {
            string key = e.Key.ToString();
            if ("Return" == key)
                RollDice();

            MessageBox.Show(key);
        }
    }

}
