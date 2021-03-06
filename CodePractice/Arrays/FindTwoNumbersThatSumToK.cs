﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CodePractice.Arrays
{

    //http://www.geeksforgeeks.org/write-a-c-program-that-given-a-set-a-of-n-numbers-and-another-number-x-determines-whether-or-not-there-exist-two-elements-in-s-whose-sum-is-exactly-x/
    class FindTwoNumbersThatSumToK
    {
        public static void Implementation()
        {
            var input = new int[] { -1, -2, -2, 0, 4, 5, 3 };
            var K = 3;

            UsingHashMap(input, K);
            UsingPointers(input, K);

        }

        static void UsingPointers(int[] input, int K)
        {
            Array.Sort(input);

            int left = 0;
            int right = input.Length - 1;

            while(left < right)
            {
                var temp = input[left] + input[right];
                if (temp == K)
                {
                    Console.WriteLine(input[left] + "," + input[right]);
                    left++;
                    right--;
                }
                else if (temp < K)
                    left++;
                else
                    right--;
            }
        }

        static void UsingHashMap(int[] input, int K)
        {
            var hashMap = new Dictionary<int, int>();

            int diff = 0;
            for (int i = 0; i < input.Length; i++)
            {
                diff = K - input[i];
                if (hashMap.ContainsKey(diff))
                {
                    Console.WriteLine(input[i] + "," + (K - input[i]));
                }

                if (!hashMap.ContainsKey(input[i]))
                    hashMap.Add(input[i], 1);
            }
        }
                
    }
}
