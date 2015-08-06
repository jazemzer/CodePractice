using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CodePractice.Arrays
{
    /// <summary>
    /// http://www.geeksforgeeks.org/find-subarray-with-given-sum/
    /// </summary>
    class PrintSubArrayWithGivenSum
    {

        public static void Implementation()
        {
            var input = new int[] { 1, 2, -1, 4, 3, -5, 2, 4 };
            Code(input, 3);
        }
                
        private static void Code(int[] a, int k)
        {
            // represents <sum from start upto index, index> 
            var hashMap = new Dictionary<int, int>();
            hashMap.Add(0, -1);

            int currSum = 0;

            for (int i = 0; i < a.Length; i++)
            {
                currSum += a[i];

                if (hashMap.ContainsKey(currSum - k))
                {
                    var index = hashMap[currSum - k];
                    Console.WriteLine(" Sub array that sums to {0}, starts from index {1} and ends at index {2}", k, index + 1, i);
                    break;
                }
                if (!hashMap.ContainsKey(currSum))
                    hashMap.Add(currSum, i);
            }
        }
    }
}
