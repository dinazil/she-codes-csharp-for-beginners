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
        public MainWindow()
        {
            InitializeComponent();

            string name;
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
    }
}
