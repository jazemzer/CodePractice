﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CodePractice.DatastructuresAndAlgorithms.Problems.Arrays
{
    class PrintSubArrayWithGivenSum
    {
        private static void Code(int[] a, int k)
        {
            // represents <sum fromstart uptpthat index, index> 
            var hashMap = new Dictionary<int, int>();
            hashMap.Add(0, -1);

            int currSum = 0;

            for (int i = 0; i < a.Length; i++)
            {
                currSum += a[i];

                if (hashMap.ContainsKey(currSum - k))
                {
                    var index = hashMap[currSum - k];
                    Console.WriteLine(" Sub array that sums upto {0} start from index {1} and ends at index {2}", k, index + 1, i);
                    break;
                }
                if (!hashMap.ContainsKey(currSum))
                    hashMap.Add(currSum, i);
            }
        }
    }
}