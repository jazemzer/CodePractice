using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HackerRank.Warmup
{
    public  class GameOfThrones1
    {
        public static void Code()
        {
            var input = Console.ReadLine().ToCharArray();
            Array.Sort(input);

            char prevChar = input[0];
            int counter = 0;
            int elementsWithoutPair = 0;
            for (int i = 0; i < input.Length; i++)
            {
                if (input[i] == prevChar)
                {
                    counter++;
                }
                else
                {
                    if (counter%2 != 0)
                    {
                        elementsWithoutPair++;
                        if (elementsWithoutPair > 1)
                        {
                            Console.WriteLine("NO");
                            return;
                        }
                    }
                    prevChar = input[i];
                    counter = 1;
                }
            }

            Console.WriteLine("YES");


        }

        public static void Code1()
        {
            var input = Console.ReadLine();

            var freq = new Dictionary<char, int>();
            for (int i = 0; i < input.Length; i++)
            {
                if (freq.ContainsKey(input[i]))
                {
                    freq[input[i]] += 1;
                }
                else
                {
                    freq.Add(input[i], 1);
                }
            }

            var occuringWitoutAPair = freq.Where(kv => kv.Value%2 != 0);
            if (occuringWitoutAPair.Any()
                && occuringWitoutAPair.Count() > 1)
            {
                Console.WriteLine("NO");
            }
            else
            {
                Console.WriteLine("YES");
            }

        }
    }
}
