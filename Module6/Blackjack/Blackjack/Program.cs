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
            Game game = new Game();

            game.ComputerMove();
            game.ComputerMove();
            if (PrintStatusAndReturnWhetherGameHasEnded(game))
                return;

            game.UserMove();
            game.UserMove();
            if (PrintStatusAndReturnWhetherGameHasEnded(game))
                return;

            while (true)
            {
                Console.Write("Would you like to draw another card? (Y/N) ");
                string input = Console.ReadLine();
                if (input == "Y")
                {
                    game.UserMove();
                    if (PrintStatusAndReturnWhetherGameHasEnded(game))
                        return;
                }

                if (game.ComputerScore > game.UserScore)
                {
                    Console.WriteLine("Computer won :-(");
                    return;
                }
                game.ComputerMove();
                if (PrintStatusAndReturnWhetherGameHasEnded(game))
                    return;
            }

            //TestCardClass();
            //TestDeckClass();
            //TestGameClass();
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
            PrintStatusAndReturnWhetherGameHasEnded(game);
            game.UserMove();
            PrintStatusAndReturnWhetherGameHasEnded(game);
            game.ComputerMove();
            PrintStatusAndReturnWhetherGameHasEnded(game);
            game.UserMove();
            PrintStatusAndReturnWhetherGameHasEnded(game);
            game.ComputerMove();
            PrintStatusAndReturnWhetherGameHasEnded(game);
            game.UserMove();
            PrintStatusAndReturnWhetherGameHasEnded(game);
            game.ComputerMove();
            PrintStatusAndReturnWhetherGameHasEnded(game);
            game.ComputerMove();
            PrintStatusAndReturnWhetherGameHasEnded(game);
        }

        private static bool PrintStatusAndReturnWhetherGameHasEnded(Game game)
        {
            if (game.ComputerWon)
            {
                Console.WriteLine("Computer won :-(");
                return true;
            }
            else if (game.UserWon)
            {
                Console.WriteLine("You won :-))))");
                return true;
            }
            return false;
        }
    }
}
