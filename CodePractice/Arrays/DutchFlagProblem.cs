using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CodePractice.Arrays
{
    class DutchFlagProblem
    {

        public static void Implementation()
        {

            var input = new int[] { 23, 5, 6, 78, 94, 13, 78, 43, 89, 13, 8, 4, 22, 45, 77, 33, 23, 67, 32, 12, 57, 78 };
            int m = 3;


            int N = input.Length;

            int smaller = 0;
            int equal = 0;
            int larger = N - 1;

            int pivot = input[m];
            while(equal <= larger)
            {
                if(input[equal] < pivot )
                {
                    Swap(input, smaller++, equal++);
                }
                else if(input[equal] == pivot)
                {
                    equal++;
                }
                else 
                {
                    Swap(input, equal, larger--);
                }
            }
        }

        private static void Swap(int[] input, int i, int j)
        {
            var temp = input[i];
            input[i] = input[j];
            input[j] = temp;
        }
                
    }
}
