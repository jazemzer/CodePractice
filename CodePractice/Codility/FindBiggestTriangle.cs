using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CodePractice.Codility
{
    class FindBiggestTriangle
    {
        public int solution(int[] A)
        {
            if (A == null
                || A.Length < 3)
            {
                return -1;
            }

            Array.Sort(A);

            long sum = -1;


            for (int i = 0; i < A.Length - 2; i++)
            {
                long temp = A[i] + A[i + 1];
                if (temp > A[i + 2])
                {
                    temp = temp + A[i + 2];
                    sum = temp > sum ? temp : sum;
                }
            }

            return Convert.ToInt32(sum);
        }
    }
}
