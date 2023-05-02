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
using MahApps.Metro;
using MahApps.Metro.Controls;

namespace Tic_Tac_Toe
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : MetroWindow
    {

        private string Human_Player = "";
        private string AI_Player = "";
        private StateClass MainState = new StateClass();
        private Label[][] LabelData = new Label[3][];
        private bool[][] IsFirstTimeClick = new bool[3][];
        private PositionClass Choice = new PositionClass();
        private bool GameFinished = false;

        public MainWindow()
        {
            InitializeComponent();
            Preparation();
        }

        private void Preparation()
        {
            try
            {
                for (int i = 0; i < 3; i++)
                {
                    IsFirstTimeClick[i] = new bool[3];
                    for (int j = 0; j < 3; j++)
                        IsFirstTimeClick[i][j] = true;
                }

                for (int i = 0; i < 3; i++)
                {
                    LabelData[i] = new Label[3];
                    for (int j = 0; j < 3; j++)
                        LabelData[i][j] = new Label();
                }

                LabelData[0][0] = Home1;
                LabelData[0][1] = Home2;
                LabelData[0][2] = Home3;
                LabelData[1][0] = Home4;
                LabelData[1][1] = Home5;
                LabelData[1][2] = Home6;
                LabelData[2][0] = Home7;
                LabelData[2][1] = Home8;
                LabelData[2][2] = Home9;
            }
            catch { }
        }

        private void StartButton_Click(object sender, RoutedEventArgs e)
        {
            StartGrid.Visibility = System.Windows.Visibility.Hidden;
            BoardWrapPanel.Visibility = System.Windows.Visibility.Visible;
            MenuGrid.Visibility = System.Windows.Visibility.Visible;

            if (XPlayerRadioButton.IsChecked == true)
            {
                Human_Player = "X";
                AI_Player = "O";
            }
            else
            {
                Human_Player = "O";
                AI_Player = "X";
            }

            YouLabel2.Content = Human_Player;
            ComputerLabel2.Content = AI_Player;
        }

        private void Home1_MouseUp(object sender, MouseButtonEventArgs e)
        {
            SolutionTicTacToe(1);
        }
        private void Home2_MouseUp(object sender, MouseButtonEventArgs e)
        {
            SolutionTicTacToe(2);
        }
        private void Home3_MouseUp(object sender, MouseButtonEventArgs e)
        {
            SolutionTicTacToe(3);
        }
        private void Home4_MouseUp(object sender, MouseButtonEventArgs e)
        {
            SolutionTicTacToe(4);
        }
        private void Home5_MouseUp(object sender, MouseButtonEventArgs e)
        {
            SolutionTicTacToe(5);
        }
        private void Home6_MouseUp(object sender, MouseButtonEventArgs e)
        {
            SolutionTicTacToe(6);
        }
        private void Home7_MouseUp(object sender, MouseButtonEventArgs e)
        {
            SolutionTicTacToe(7);
        }
        private void Home8_MouseUp(object sender, MouseButtonEventArgs e)
        {
            SolutionTicTacToe(8);
        }
        private void Home9_MouseUp(object sender, MouseButtonEventArgs e)
        {
            SolutionTicTacToe(9);
        }

        
        private void SolutionTicTacToe(int HomeNumber)
        {
            if (!GameFinished)
            {
                bool IsNewClick = false;
                switch (HomeNumber)
                {
                    case 1:
                        if (IsFirstTimeClick[0][0] == true)
                        {
                            Home1.Content = Human_Player;
                            MainState.Data[0][0] = Human_Player;
                            IsFirstTimeClick[0][0] = false;
                            IsNewClick = true;
                        }
                        break;
                    case 2:
                        if (IsFirstTimeClick[0][1] == true)
                        {
                            Home2.Content = Human_Player;
                            MainState.Data[0][1] = Human_Player;
                            IsFirstTimeClick[0][1] = false;
                            IsNewClick = true;
                        }
                        break;
                    case 3:
                        if (IsFirstTimeClick[0][2] == true)
                        {
                            Home3.Content = Human_Player;
                            MainState.Data[0][2] = Human_Player;
                            IsFirstTimeClick[0][2] = false;
                            IsNewClick = true;
                        }
                        break;
                    case 4:
                        if (IsFirstTimeClick[1][0] == true)
                        {
                            Home4.Content = Human_Player;
                            MainState.Data[1][0] = Human_Player;
                            IsFirstTimeClick[1][0] = false;
                            IsNewClick = true;
                        }
                        break;
                    case 5:
                        if (IsFirstTimeClick[1][1] == true)
                        {
                            Home5.Content = Human_Player;
                            MainState.Data[1][1] = Human_Player;
                            IsFirstTimeClick[1][1] = false;
                            IsNewClick = true;
                        }
                        break;
                    case 6:
                        if (IsFirstTimeClick[1][2] == true)
                        {
                            Home6.Content = Human_Player;
                            MainState.Data[1][2] = Human_Player;
                            IsFirstTimeClick[1][2] = false;
                            IsNewClick = true;
                        }
                        break;
                    case 7:
                        if (IsFirstTimeClick[2][0] == true)
                        {
                            Home7.Content = Human_Player;
                            MainState.Data[2][0] = Human_Player;
                            IsFirstTimeClick[2][0] = false;
                            IsNewClick = true;
                        }
                        break;
                    case 8:
                        if (IsFirstTimeClick[2][1] == true)
                        {
                            Home8.Content = Human_Player;
                            MainState.Data[2][1] = Human_Player;
                            IsFirstTimeClick[2][1] = false;
                            IsNewClick = true;
                        }
                        break;
                    case 9:
                        if (IsFirstTimeClick[2][2] == true)
                        {
                            Home9.Content = Human_Player;
                            MainState.Data[2][2] = Human_Player;
                            IsFirstTimeClick[2][2] = false;
                            IsNewClick = true;
                        }
                        break;
                }//end of switch

                if (IsNewClick)
                {
                    int result = Minimax(MainState, "AI");

                    MainState.Data[Choice.Row][Choice.Column] = AI_Player;
                    UpdateFirstTime(Choice);
                    UpdateBoard();

                    if (MainState.CalculateScore(MainState, Human_Player, AI_Player) != 0 || MainState.IsFinish())
                    {
                        switch (MainState.CalculateScore(MainState, Human_Player, AI_Player))
                        {
                            case 10:
                                GameFinished = true;
                                ResultLabel.Content = "You Win.";
                                break;
                            case -10:
                                ResultLabel.Content = "You Lost!";
                                GameFinished = true;
                                break;
                            case 0:
                                if (MainState.IsFinish())
                                {
                                    ResultLabel.Content = "The Game is Draw.";
                                    GameFinished = true;
                                }
                                break;
                        }
                    }
                }
            }
        }        

        private int Minimax(StateClass game, string player)
        {
            if (game.CalculateScore(game, Human_Player, AI_Player) != 0 || game.IsFinish())
                return game.CalculateScore(game, Human_Player, AI_Player);

            List<int> Scores = new List<int>();
            List<PositionClass> Moves = new List<PositionClass>();

            Moves = game.CreateMoves();

            if (player == "Human")
            {           
                for (int i = 0; i < Moves.Count; i++)
                {
                    StateClass PosibleGame = new StateClass();
                    PosibleGame = game.GetNewState(Moves[i], Human_Player);
                    Scores.Add(Minimax(PosibleGame,"AI"));
                }

                int Max_Store_Score = Scores.IndexOf(Scores.Max());
                Choice = Moves[Max_Store_Score];
                return Scores[Max_Store_Score];
            }
            else
            {                
                for (int i = 0; i < Moves.Count; i++)
                {
                    StateClass PosibleGame = new StateClass();
                    PosibleGame = game.GetNewState(Moves[i], AI_Player);
                    Scores.Add(Minimax(PosibleGame, "Human"));
                }

                int Min_Store_Score = Scores.IndexOf(Scores.Min());
                Choice = Moves[Min_Store_Score];
                return Scores[Min_Store_Score];
            }
        }

        private void UpdateBoard()
        {
            for (int i = 0; i < 3; i++)
                for (int j = 0; j < 3; j++)
                    LabelData[i][j].Content = MainState.Data[i][j];
        }

        private void PlayAgainButton_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                GameFinished = false;
                MainState = new StateClass();
                LabelData = new Label[3][];
                IsFirstTimeClick = new bool[3][];
                Preparation();
                UpdateBoard();
                ResultLabel.Content = "";
            }
            catch { }
        }

        private void UpdateFirstTime(PositionClass choice)
        {
            IsFirstTimeClick[choice.Row][choice.Column] = false;    
        }
    }
}
