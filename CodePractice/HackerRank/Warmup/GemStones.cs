using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HackerRank.Warmup
{
    public class GemStones
    {
        //Amit's
        public static void Solution()
        {
            string num = Console.ReadLine();
            int N = int.Parse(num);

            int[] gems = new int[26];

            for (int i = 0; i < N; i++)
            {
                string composition = Console.ReadLine();
                for (int j = 0; j < composition.Length; j++)
                {
                    int index = composition[j] - 'a';
                    if (gems[index] == i)
                        gems[index]++;

                }
            }

            int count = 0;
            for (int i = 0; i < 26; i++)
            {
                if (gems[i] == N)
                    count++;
            }
            Console.WriteLine(count);
        }

        public static void Code()
        {
/*

            int N = Convert.ToInt32(Console.ReadLine()); //Number of rocks

            var rocks = new List<string>();
            
            while (N > 0)
            {
                rocks.Add(string.Join("",Console.ReadLine().ToCharArray().OrderBy(c => c).ToArray()));
                N--;
            }
*/
            int N = 100;
            var rocks = new List<string> (File.ReadAllLines("TC/GemStones1.txt"));

/*
            N = 3;
            rocks = new List<string>()
            {
                "abcdde",
                "baccd",
                "eeabg"
            };
*/

            rocks = rocks.Select(s => string.Join("", s.OrderBy(c => c).ToArray())).ToList();
            N = rocks.Count;
            var freq = new Dictionary<char, bool[]>();
            var minStoneCounts = new Dictionary<char, int>();

            for (int i = 0; i < rocks.Count; i++)
            {
                char prevStone = rocks[i][0];
                int stoneCount = 0;
                foreach (var stone in rocks[i])
                {
                    if (stone == prevStone)
                    {
                        stoneCount += 1;
                    }
                    else
                    {
                        if (minStoneCounts.ContainsKey(prevStone))
                        {
                            minStoneCounts[prevStone] = stoneCount < minStoneCounts[prevStone] 
                                ? stoneCount
                                : minStoneCounts[prevStone];
                        }
                        else
                        {
                            minStoneCounts.Add(prevStone, stoneCount);
                        }

                        prevStone = stone;
                        stoneCount = 1;
                    }


                    if (!freq.ContainsKey(stone))
                    {
                        freq.Add(stone, new bool[N]);
                    }
                    freq[stone][i] = true;

                }

                //Special case
                if (minStoneCounts.ContainsKey(prevStone))
                {
                    minStoneCounts[prevStone] = stoneCount < minStoneCounts[prevStone]
                        ? stoneCount
                        : minStoneCounts[prevStone];
                }
                else
                {
                    minStoneCounts.Add(prevStone, stoneCount);
                }
            }

           

            var stonesAppearingInAllRocks = freq.Where(kvpair => kvpair.Value.Where(c => c == true).Count() == N);
            Console.WriteLine(stonesAppearingInAllRocks.Sum(kv => minStoneCounts[kv.Key]));

            Console.Read();

        }

        private static int FindMaxOf3(int a, int b, int c)
        {
            if (a > b && a > c)
            {
                return a;
            }
            else if (b > a && b > c)
            {
                return b;
            }
            else
            {
                return c;
            }
        }
    }
}
