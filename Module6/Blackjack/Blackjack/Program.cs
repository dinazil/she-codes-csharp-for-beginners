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
    }
}
