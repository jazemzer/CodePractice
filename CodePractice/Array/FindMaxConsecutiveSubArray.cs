using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CodePractice.DatastructuresAndAlgorithms.Problems.Arrays
{
    class FindMaxConsecutiveSubArray
    {
        static void Code()
        {
            //var input = new[] {1, 2, -6, 4, -2, 8, -5};
            var input = new[] { -2, -3, 4, -1, -2, 1, 5, -3 };
            //var input = new[] {-1, -7, 5, 0, 9, -10, 5, 0,-20,0, 2, 5, 5, 5, 0, 0 };

            int tempSum = 0;
            int maxSum = 0;
            int start = 0;
            int end = -1;
            ;
            for (int i = 0; i < input.Length; i++)
            {
                tempSum += input[i];
                if (tempSum < 0)
                {
                    tempSum = 0;
                    start = i + 1;
                    end = -1;
                }
                else
                {
                    if (tempSum > maxSum)
                    {
                        maxSum = tempSum;
                        end = i;
                    }
                    else if (tempSum == maxSum)
                    {
                        end = i;
                    }

                }
            }

            if (end != -1)
            {
                var result = input.Skip(start).Take(end + 1 - start);
                Console.WriteLine("Max " + maxSum + " : " + string.Join(",", result));
            }

        }
    }
}
