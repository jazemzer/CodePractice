using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CodePractice.DatastructuresAndAlgorithms.Problems.Arrays
{
    class FindConsecutiveNumbersThatAddToN
    {
        static void Code()
        {
            //int[] input = new[] { 5, 0, 9, 2, 5, 5, 5 };
            //int[] input = new[] { 10};
            //int[] input = new[] { -20, 0, 30, 0, 5};
            //int[] input = new[] { -20, -7, 35, 0, 2, 0, 5};
            //int[] input = new[] { 5, 5, -6, 6, 0, 0 };
            int[] input = new[] { 5, 2, -6, 0, 12, -2 };

            int sum = 0;
            int expectedSum = 10;
            int start = 0;
            int end = -1;
            int firstItem = 0;

            for (int i = 0; i < input.Length; i++)
            {
                sum += input[i];

                if (sum > expectedSum
                    && end == -1)
                {
                    do
                    {
                        firstItem = input[start];
                        sum -= firstItem;
                        start++;
                    } while (sum > expectedSum);
                }
                if (sum == expectedSum)
                {
                    end = i;
                }
            }
            if (end != -1)
            {
                var result = input.Skip(start).Take(end + 1 - start);
                Console.WriteLine("First Matching Series " + string.Join(",", result));
            }
        }
    }
}
