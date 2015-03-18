using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CodePractice.Arrays
{
    class CountContinuousSubArrayWithZeroSum
    {

        public static void Implementation()
        {

            int N = Convert.ToInt32(Console.ReadLine());

            var input = new int[N];

            var cumsumHist = new int[N + 1];

            var counter = 0;
            var cumsum = 0;

            for (var i = 0; i < N; i++)
            {
                input[i] = Convert.ToInt32(Console.ReadLine());

                cumsumHist[i + 1] = cumsum = cumsum + input[i];
            }

            var map = new Dictionary<int, int>();

            for (var i = 0; i <= N; i++)
            {
                if (map.ContainsKey(cumsumHist[i]))
                {
                    map[cumsumHist[i]]++;
                }
                else
                {
                    map.Add(cumsumHist[i], 1);
                }
            }

            foreach (var kvPair in map)
            {
                if (kvPair.Value > 1)
                {
                    counter = counter + (kvPair.Value * (kvPair.Value - 1) / 2);
                }
            }

            Console.WriteLine(counter);
        }
                
    }
}
