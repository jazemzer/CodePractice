using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CodePractice.Codility
{
    class FindCubeRoots
    {
        public int solution(int A, int B)
        {
            int result = 0;
            int boundary = Convert.ToInt32(Math.Pow(int.MaxValue, (double)1 / 3));

            int cube = 0;
            for (int i = -boundary; i <= boundary; i++)
            {
                cube = i * i * i;
                if (cube >= A && cube <= B)
                {
                    result++;
                }

                if (cube > B)
                    break;
            }

            return result;
        }
    }
}
