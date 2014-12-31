using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CodePractice.Codility
{
    public class Equillibrium
    {

        public static void Implementation()
        {
            int[] input = Enumerable.Range(0, 4).ToArray();
            //var result = new Equillibrium().solution(200000000, 36);
            //var result = new Equillibrium().solution(new int[] {1, 5, 6, 11 });
            var result = new Equillibrium().solution(input);
        }
      
        public int solution(int[] A)
        {
            // write your code in C# 5.0 with .NET 4.5 (Mono)
            var sum = A.Sum();

            int leftSum = 0;
            int rightSum = sum;
            for (int i = 0; i < A.Length; i++)
            {
                leftSum += A[i];
                rightSum -= A[i];

                if (leftSum - A[i] == rightSum)
                {
                    return i; //break at first match
                }


            }

            return -1;
        }
    }
}
