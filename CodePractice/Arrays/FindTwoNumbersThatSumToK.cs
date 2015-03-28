using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CodePractice.Arrays
{
    class FindTwoNumbersThatSumToK
    {
        public static void Implementation()
        {
            var input = new int[] { -1, -2, -2, 0, 4, 5, 3};
            var K = 3;
            var hashMap = new Dictionary<int, int>();

            int diff = 0;
            for(int i = 0; i < input.Length; i++)
            {
                diff = K - input[i];
                if (hashMap.ContainsKey(diff))
                {
                    Console.WriteLine(input[i] + "," + (K - input[i]));
                }
                
                if(!hashMap.ContainsKey(input[i]))
                    hashMap.Add(input[i], 1);
            }


        }

        static int pairs(int[] a, int k)
        {
            var hashmap = new Dictionary<int, int>();
            int diff = 0;

            int counter = 0;
            for (int i = 0; i < a.Length; i++)
            {
                diff = k - a[i];
                if (hashmap.ContainsKey(diff) || hashmap.ContainsKey(-diff))
                    counter++;

                if (!hashmap.ContainsKey(a[i]))
                    hashmap.Add(a[i], 1);
            }
            return 0;
        }
                
    }
}
