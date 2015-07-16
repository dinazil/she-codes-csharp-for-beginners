using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PracticeQuestions
{
    class Program
    {
        static void PrintMessage(DayOfWeek dayOfWeek)
        {
            switch (dayOfWeek)
            {
                case DayOfWeek.Friday:
                case DayOfWeek.Saturday:
                    Console.WriteLine("Yay! It's the weekend!");
                    break;
                default:
                    Console.WriteLine("Just another day...");
                    break;
            }
        }

        static void CheckFriend(List<string> friends)
        {
            Console.Write("Enter a name: ");
            string name = Console.ReadLine();
            Console.WriteLine("{0} is your friend = {1}", name, friends.Contains(name));
        }

        static void OldestAndYoungestFriends(Dictionary<string, int> friendAges)
        {
            string oldestFriend = "", youngestFriend = "";
            int oldestAge = -1, youngestAge = -1;
            foreach (var friendAndAge in friendAges)
            {
                if (oldestAge == -1)
                {
                    oldestAge = friendAndAge.Value;
                    youngestAge = friendAndAge.Value;
                    oldestFriend = friendAndAge.Key;
                    youngestFriend = friendAndAge.Key;
                }
                else
                {
                    if (friendAndAge.Value > oldestAge)
                    {
                        oldestAge = friendAndAge.Value;
                        oldestFriend = friendAndAge.Key;
                    }
                    if (friendAndAge.Value < youngestAge)
                    {
                        youngestAge = friendAndAge.Value;
                        youngestFriend = friendAndAge.Key;
                    }
                }
            }
            Console.WriteLine("Your oldest friend is {0} who is {1} years old", oldestFriend, oldestAge);
            Console.WriteLine("Your youngest friend is {0} who is {1} years old", youngestFriend, youngestAge);
        }

        static void Main(string[] args)
        {
            PrintMessage(DayOfWeek.Friday);

            List<string> friends = new List<string>();
            friends.Add("Dina");
            friends.Add("Dana");
            friends.Add("Mina");
            CheckFriend(friends);

            Dictionary<string, int> friendAges = new Dictionary<string, int>();
            friendAges.Add("Michael", 31);
            friendAges.Add("Dana", 24);
            friendAges.Add("Don", 54);
            friendAges.Add("Reut", 18);
            OldestAndYoungestFriends(friendAges);
        }
    }
}
