using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CodePractice.Arrays
{

    //http://www.geeksforgeeks.org/given-a-sorted-and-rotated-array-find-if-there-is-a-pair-with-a-given-sum/
    class FindTwoNumbersThatSumToKinSortedRotatedArray
    {
        public static void Implementation()
        {
            var input = new int[] {11, 15, 6, 8, 9, 10};
            var K = 16;

            UsingHashMap(input, K);
            UsingPointers(input, K);

        }

        static void UsingPointers(int[] input, int K)
        {
            //Find left pointer
            var temp = input[0];
            var left = 0;

            var N = input.Length;

            for (int i = 1; i < N; i++)
            {
                if (input[i] < temp)
                {
                    temp = input[i];
                    left = i;
                    break;
                }
            }

            //Special condition. array rotated by n
            int right = left == 0 ? N - 1 : left - 1;

            while(left != right)
            {
                temp = input[left] + input[right];
                if (temp == K)
                {
                    Console.WriteLine(input[left] + "," + input[right]);
                    left = (left + 1) % N;
                    right = (right - 1 + N) % N;
                }
                else if (temp < K)
                    left = (left + 1) %N;
                else
                    right = (right - 1 + N) %N;

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
