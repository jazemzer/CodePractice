using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CodePractice.BookingDotCom
{
    class FindUniqueItem
    {
        static void Code()
        {
            int[] input = new int[] { 1, 1, 2, 3, 56, 4, 7, 4, 3, 2, 56, 1000 };

            var freqTable = new Dictionary<int, int>();
            foreach (var i in input)
            {
                if (freqTable.ContainsKey(i))
                {
                    freqTable[i] += 1;
                }
                else
                {
                    freqTable.Add(i, 1);
                }
            }

            var result = freqTable.Where(x => x.Value == 1).Select(s => s.Key).ToList();

            Console.WriteLine(result.FirstOrDefault());

        }
    }
}
