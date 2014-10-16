using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CodePractice.BookingDotCom
{
    class FindRepeatingElementsInThreeArrays
    {
        private static void Code()
        {
            int[] setA = new int[] { 1, 2, 3, 4, 5, 6 };
            int[] setB = new int[] { 4, 5, 6, 6 };
            int[] setC = new int[] { 4, 5, 7, 7, 7 };

            Dictionary<int, Byte> freqCount = new Dictionary<int, Byte>();
            for (int i = 0; i < setA.Length; i++)
            {
                if (!freqCount.ContainsKey(setA[i]))
                    freqCount.Add(setA[i], 1);
            }
            for (int i = 0; i < setB.Length; i++)
            {
                if (!freqCount.ContainsKey(setB[i]))
                    freqCount.Add(setB[i], 2);
                else
                    freqCount[setB[i]] |= 2;
            }
            for (int i = 0; i < setC.Length; i++)
            {
                if (!freqCount.ContainsKey(setC[i]))
                    freqCount.Add(setC[i], 4);
                else
                    freqCount[setC[i]] |= 4;
            }

            foreach (var item in freqCount)
            {
                if (item.Value == 7)
                {
                    Console.Write(item.Key + " ");
                }
            }
            Console.WriteLine();
        }

    }
}
