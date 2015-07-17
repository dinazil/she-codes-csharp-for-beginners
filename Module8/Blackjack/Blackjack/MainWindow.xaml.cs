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

namespace Blackjack
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private Game _game;
        enum GameStatus
        {
            Continue,
            Exit,
            Restart
        }
        public MainWindow()
        {
            InitializeComponent();
        }
        private string GetImageFileNameForCard(Card card)
        {
            int col = -1;
            switch (card.Suit)
            {
                case "Spades":
                    col = 0;
                    break;
                case "Clubs":
                    col = 1;
                    break;
                case "Hearts":
                    col = 2;
                    break;
                case "Diamonds":
                    col = 3;
                    break;
            }

            int row = -1;
            
            if (card.Rank == "Ace")
            {
                row = 0;
            }
            else
            {
                row = 14 - card.GetValue();
            }

            return "Images/" + (row * 4 + col + 1).ToString() + ".png";
        }
        private Image GetImageForCard(Card card)
        {
            Image image = new Image();
            image.Source = new BitmapImage(new Uri(GetImageFileNameForCard(card), UriKind.Relative));
            return image;
        }
        private void StartGame()
        {
            ClearTheBoard();

            _game = new Game();

            ComputerMove();
            ComputerMove();

            switch (CheckGameStatus())
            {
                case GameStatus.Exit:
                    Environment.Exit(0);
                    break;
                case GameStatus.Restart:
                    ClearTheBoard();
                    return;
            }

            MyMove();
            MyMove();

            switch (CheckGameStatus())
            {
                case GameStatus.Exit:
                    Environment.Exit(0);
                    break;
                case GameStatus.Restart:
                    ClearTheBoard();
                    return;
            }
        }
        private void ClearTheBoard()
        {
            ComputerCards.Children.Clear();
            MyCards.Children.Clear();
            ComputerScore.Content = "";
            MyScore.Content = "";
        }
        private void ComputerMove()
        {
            ComputerCards.Children.Add(GetImageForCard(_game.ComputerMove()));
            ComputerScore.Content = _game.ComputerScore;  
        }
        private void MyMove()
        {
            MyCards.Children.Add(GetImageForCard(_game.UserMove()));
            MyScore.Content = _game.UserScore;
        }
        private GameStatus CheckGameStatus()
        {
            string message = null;
            if (_game.ComputerWon)
            {
                message = "Computer won :-(\nDo you want to continue playing?";
            }
            else if (_game.UserWon)
            {
                message = "You won :-))))\nDo you want to continue playing?";
            }

            if (message != null)
            {
                MessageBoxResult userAnswer = MessageBox.Show(message, "Game Over", MessageBoxButton.YesNo);
                if (userAnswer == MessageBoxResult.No)
                {
                    return GameStatus.Exit;
                }
                else
                {
                    return GameStatus.Restart;
                }
            }

            return GameStatus.Continue;
        }

        private void ButtonHitMe_Click(object sender, RoutedEventArgs e)
        {
            MyMove();

            switch (CheckGameStatus())
            {
                case GameStatus.Exit:
                    Environment.Exit(0);
                    break;
                case GameStatus.Restart:
                    ClearTheBoard();
                    return;
            }

            ComputerMove();

            switch (CheckGameStatus())
            {
                case GameStatus.Exit:
                    Environment.Exit(0);
                    break;
                case GameStatus.Restart:
                    ClearTheBoard();
                    return;
            }
        }

        private void ButtonRestart_Click(object sender, RoutedEventArgs e)
        {
            StartGame();
        }

        private void ButtonPass_Click(object sender, RoutedEventArgs e)
        {
            if (_game.ComputerScore > _game.UserScore)
            {
                return; // if the computer has more points then it passes its turn
            }
            ComputerMove();

            switch (CheckGameStatus())
            {
                case GameStatus.Exit:
                    Environment.Exit(0);
                    break;
                case GameStatus.Restart:
                    ClearTheBoard();
                    return;
            }
        }
    }
}
