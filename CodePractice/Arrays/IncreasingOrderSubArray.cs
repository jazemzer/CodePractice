using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CodePractice.Arrays
{
    class IncreasingOrderSubArray
    {

        public static void Implementation()
        {
            var input = new int[] { 1, 2, 4, 7, 5, 6, 3, 2 };

            FindSubArrays(input);
        }

        private static void FindSubArrays(int[] input)
        {
            int prev = int.MaxValue;


            for(int i = 0; i <input.Length; i++)
            {
                if(input[i] < prev)
                {                    
                    Console.WriteLine();                    
                }
                Console.Write(input[i] + " ");
                prev = input[i];
            }
        }
                
    }
}
