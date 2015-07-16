using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WordCount
{
    class Program
    {
        static List<string> AllWords(string filename)
        {
            List<string> words = new List<string>();
            foreach (string line in File.ReadAllLines(filename))
            {
                foreach (string word in line.Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries))
                {
                    words.Add(word.Trim(',', '.', '-', '!', '?', '\'', '"', ';', '(', ')', '[', ']').ToLower());
                }
            }
            return words;
        }

        static Dictionary<string, int> WordFrequencies(List<string> words)
        {
            Dictionary<string, int> frequencies = new Dictionary<string, int>();
            foreach (string word in words)
            {
                if (frequencies.ContainsKey(word))
                    frequencies[word] += 1;
                else
                    frequencies[word] = 1;
            }
            return frequencies;

            // Here is an alternative implementation, expressed as a LINQ query and the ToDictionary method:
            //return (from word in words
            //        group 1 by word into g
            //        select new { Word = g.Key, Freq = g.Count() }).ToDictionary(a => a.Word, a => a.Freq);
        }

        static void Main(string[] args)
        {
            foreach (var wordAndFrequency in
                (from wf in WordFrequencies(AllWords("pride-and-prejudice.txt")) orderby wf.Value descending select wf).Take(100))
            {
                Console.WriteLine("{0} appears {1} times", wordAndFrequency.Key, wordAndFrequency.Value);
            }
        }
    }
}
