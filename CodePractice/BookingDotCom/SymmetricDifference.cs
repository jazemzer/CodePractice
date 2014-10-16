using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CodePractice.BookingDotCom
{
    class SymmetricDifference
    {
        private static void Code()
        {
            int[] setA = new int[] { 1, 2, 3, 4, 5 };
            int[] setB = new int[] { 4, 5, 6, 6 };

            HashSet<int> output = new HashSet<int>();
            Dictionary<int, int> freqCount = new Dictionary<int, int>();

            for (int i = 0; i < setA.Length; i++)
            {
                if (!freqCount.ContainsKey(setA[i]))
                {
                    freqCount.Add(setA[i], 1);
                }
            }

            for (int i = 0; i < setB.Length; i++)
            {
                if (freqCount.ContainsKey(setB[i]))
                {
                    freqCount[setB[i]] += 1;
                }
                else
                {
                    output.Add(setB[i]);
                }
            }

            var itemsFromSetA = freqCount.Where(x => x.Value == 1).Select(x => x.Key).ToList();
            foreach (var item in itemsFromSetA)
            {
                output.Add(item);
            }

            foreach (var item in output)
            {
                Console.Write(item + " ");
            }

            Console.WriteLine();
        }
    }
}
