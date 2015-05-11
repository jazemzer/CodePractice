using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CodePractice.Arrays
{
    public class LongestIncreasingSubSequence
    {
        static int lis(int[] arr, int n)
        {
            int i, j, max = 0;

            var lis = new int[n];

            /* Initialize LIS values for all indexes */
            for (i = 0; i < n; i++)
                lis[i] = 1;

            /* Compute optimized LIS values in bottom up manner */
            for (i = 1; i < n; i++)
            {
                for (j = 0; j < i; j++)
                {
                    Console.WriteLine(j + " " + i);
                    if (arr[i] > arr[j] && lis[i] < lis[j] + 1)
                        lis[i] = lis[j] + 1;
                }
            }

            /* Pick maximum of all LIS values */
            for (i = 0; i < n; i++)
                if (max < lis[i])
                    max = lis[i];


            return max;
        }


        public static void Implementation()
        {
            var arr = new int[] { 10, 22, 9, 33, 21, 50, 41, 60 };
            Console.WriteLine("Length of LIS " + lis(arr, arr.Length));
        }

    }
}