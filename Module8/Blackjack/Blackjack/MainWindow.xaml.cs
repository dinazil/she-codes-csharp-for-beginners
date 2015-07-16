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
        private Game game;
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
            ComputerCards.Children.Clear();
            MyCards.Children.Clear();
            ComputerScore.Content = 0;
            MyScore.Content = 0;

            game = new Game();

            ComputerMove();
            ComputerMove();

            MyMove();
            MyMove();
        }

        private void ComputerMove()
        {
            ComputerCards.Children.Add(GetImageForCard(game.ComputerMove()));
            ComputerScore.Content = game.ComputerScore;

            CheckGameStatusAndRestartIfNeeded();
        }
        private void MyMove()
        {
            MyCards.Children.Add(GetImageForCard(game.UserMove()));
            MyScore.Content = game.UserScore;
            
            CheckGameStatusAndRestartIfNeeded();
        }
        private void CheckGameStatusAndRestartIfNeeded()
        {
            string message = null;
            if (game.ComputerWon)
            {
                message = "Computer won :-(\nDo you want to restart?";
                
            }
            else if (game.UserWon)
            {
                message = "You won :-))))\nDo you want to restart?";
            }

            if (message != null)
            {
                MessageBoxResult userAnswer = MessageBox.Show(message, "Game Over", MessageBoxButton.YesNo);
                if (userAnswer == MessageBoxResult.Yes)
                {
                    StartGame();
                }
                else
                {
                    Environment.Exit(0);
                }
            }
        }

        private void ButtonHitMe_Click(object sender, RoutedEventArgs e)
        {
            MyMove();
        }

        private void ButtonRestart_Click(object sender, RoutedEventArgs e)
        {
            StartGame();
        }
    }
}
