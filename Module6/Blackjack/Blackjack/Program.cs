using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Blackjack
{
    class Program
    {
        static void Main(string[] args)
        {
            TestCardClass();
            TestDeckClass();
            TestGameClass();
        }

        static void TestCardClass()
        {
            Card aceOfSpades = new Card("Spades", "Ace");
            Console.WriteLine(aceOfSpades.GetFace() + " " + aceOfSpades.GetValue());

            Card sevenOfHearts = new Card("Hearts", "7");
            Console.WriteLine(sevenOfHearts.GetFace() + " " + sevenOfHearts.GetValue());

            Card jackOfDiamonds = new Card("Diamonds", "Jack");
            Console.WriteLine(jackOfDiamonds.GetFace() + " " + jackOfDiamonds.GetValue());
        }

        static void TestDeckClass()
        {
            Deck deck = new Deck();
            for (int i = 0; i < 52; ++i)
            {
                Console.WriteLine(deck.DrawCard().GetFace());
            }
        }
        private static void TestGameClass()
        {
            Game game = new Game();
            game.ComputerMove();
            PrintStatus(game);
            game.UserMove();
            PrintStatus(game);
            game.ComputerMove();
            PrintStatus(game);
            game.UserMove();
            PrintStatus(game);
            game.ComputerMove();
            PrintStatus(game);
            game.UserMove();
            PrintStatus(game);
            game.ComputerMove();
            PrintStatus(game);
            game.ComputerMove();
            PrintStatus(game);
        }

        private static void PrintStatus(Game game)
        {
            Console.Write("Game status - You: {0}, Computer: {1} ", game.UserScore, game.ComputerScore);
            if (game.ComputerWon)
            {
                Console.WriteLine("Computer won :-(");
            }
            else if (game.UserWon)
            {
                Console.WriteLine("You won :-))))");
            }
            else
            {
                Console.WriteLine();
            }
        }
    }
}
