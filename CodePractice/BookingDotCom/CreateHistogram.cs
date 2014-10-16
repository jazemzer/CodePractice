using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CodePractice.BookingDotCom
{
    class CreateHistogram
    {
        private static void Code()
        {
            string[] input = new string[]
            {
                "abacus",
                "abaculus",
                "Abadite",
                "basic",
                "trial",
                "Killer"
            };

            Dictionary<char, int> freq = new Dictionary<char, int>();

            foreach (string s in input)
            {
                foreach (char c in s.ToLower())
                {
                    if (freq.ContainsKey(c))
                    {
                        freq[c] += 1;
                    }
                    else
                    {
                        freq.Add(c, 1);
                    }
                }
            }

            var sorted = freq.OrderBy(x => x.Key);
            foreach (var kvPair in sorted)
            {
                for (int i = 0; i < kvPair.Value; i++)
                {
                    Console.Write("*");
                }
                Console.Write(kvPair.Key);
                Console.WriteLine();

            }

            int max = freq.Max(x => x.Value);
            foreach (var kvPair in sorted)
            {
                int scaled = (kvPair.Value * 79) / max;
                for (int i = 0; i < scaled; i++)
                {
                    Console.Write("*");
                }
                Console.Write(kvPair.Key);
                Console.WriteLine();

            }

            Console.WriteLine();
        }
    }
}
