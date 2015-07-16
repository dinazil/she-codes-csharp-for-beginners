using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Blackjack
{
    class Game
    {
        public bool UserWon { get; set; }
        public bool ComputerWon { get; set; }
        public int UserScore { get; set; }
        public int ComputerScore { get; set; }
        public Deck Deck { get; set; }

        public Game()
        {
            UserWon = false;
            ComputerWon = false;
            UserScore = 0;
            ComputerScore = 0;
            Deck = new Deck();
        }

        public Card ComputerMove()
        {
            Card card = Deck.DrawCard();
            ComputerScore += card.GetValue();
            if (ComputerScore == 21)
            {
                ComputerWon = true;
            }
            if (ComputerScore > 21)
            {
                UserWon = true;
            }
            return card;
        }
        public Card UserMove()
        {
            Card card = Deck.DrawCard();
            UserScore += card.GetValue();
            if (UserScore == 21)
            {
                UserWon = true;
            }
            if (UserScore > 21)
            {
                ComputerWon = true;
            }
            return card;
        }
    }
}
