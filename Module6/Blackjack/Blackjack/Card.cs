using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Blackjack
{
    class Card
    {
        static string[] _validSuits = new string[] { "Hearts", "Spades", "Diamonds", "Clubs" };
        static string[] _validRanks = new string[] { "Ace", 
                                                       "2", "3", "4", "5", "6", "7", "8", "9", "10",
                                                       "Jack", "Queen", "King" };

        public static string[] ValidSuits()
        {
            return _validSuits;
        }

        public static string[] ValidRanks()
        {
            return _validRanks;
        }

        public string Suit { get; set; }
        public string Rank { get; set; }

        public Card(string suit, string rank)
        {
            if (!_validSuits.Contains(suit) || _validRanks.Contains(rank))
            {
                Console.WriteLine("The card details are invalid!");
                Environment.Exit(1);
            }
            else
            {
                Suit = suit;
                Rank = rank;
            }
        }

        public int GetValue()
        {
            if (Rank == "Ace")
            {
                return 1;
            }
            else if (Rank == "Jack")
            {
                return 11;
            }
            else if (Rank == "Queen")
            {
                return 12;
            }
            else if (Rank == "King")
            {
                return 13;
            }
            else
            {
                return int.Parse(Rank);
            }
        }

        public string GetFace()
        {
            return Rank + " of " + Suit;

            //TODO: bonus ASCII art :-)
        }
    }
}
