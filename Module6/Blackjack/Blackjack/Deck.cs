using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Blackjack
{
    class Deck
    {
        public Card[] Cards { get; set; }
        public Random RandomGenerator { get; set; }

        public Deck()
        {
            Cards = new Card[52];
            int index = 0;
            foreach (string rank in Card.ValidRanks())
            {
                foreach (string suit in Card.ValidSuits())
                {
                    Cards[index] = new Card(suit, rank);
                    index = index + 1;
                }
            }

            RandomGenerator = new Random();
        }

        public Card DrawCard()
        {
            int randomNumber = RandomGenerator.Next(0, 52);
            while (Cards[randomNumber] == null)
            {
                randomNumber = RandomGenerator.Next(0, 52);
            }

            Card drawnCard = Cards[randomNumber];
            Cards[randomNumber] = null;
            return drawnCard;
        }
    }
}
