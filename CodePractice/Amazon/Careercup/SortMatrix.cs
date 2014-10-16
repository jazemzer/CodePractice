using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodePractice.Amazon.Careercup
{
    public class SortMatrix
    {
        public static int[,] Alternative1(int[] arr)
        {

            int dem = (int) Math.Ceiling(Math.Sqrt(arr.Length));
            int[,] res = new int[dem ,dem];

            Array.Sort(arr);
            int p = 0;
            for (int row = 0; row < dem; ++row)
            {
                for (int c = 0, r = row; r >= 0 && c < dem; --r, ++c)
                {
                    res[r,c] = arr[p++];
                }
            }
            for (int col = 1; col < dem; ++col)
            {
                for (int r = dem - 1, c = col; r >= 0 && c < dem; --r, ++c)
                {
                    res[r,c] = arr[p++];
                }
            }
            return res;
        }

        /// <summary>
        /// We are given an unsorted array of n^2 arbitrary numbers, 
        /// and we must output an n x n matrix of all the inputs such that all the rows and columns are sorted. 
        /// For example, suppose n=3, n^2=9, and the 9 numbers are just the integers {1,2,...,9} 
        /// Possible ouputs include:
        /// 1 4 7       1 3 5
        /// 2 5 8       2 4 6
        /// 3 6 9       7 8 9
        /// Show how to sort this array with a Ω(n^2log n) lower bound.
        /// http://www.careercup.com/question?id=5742801656479744
        /// </summary>
        public static void Code()
        {
            /*int R = Convert.ToInt32(Console.ReadLine());
            int C = Convert.ToInt32(Console.ReadLine());
             */

            int R = 3, C = 3;
            var matrix = new int[R, C];

            var input = new int[R * C];
            input = new[] { 1, 2, 3, 4, 5, 6, 7, 8, 9 };
            
           /* for (int i = 0; i < R; i++)
            {
                for (int j = 0; j < C; j++)
                {
                    input[R*i + j] = Convert.ToInt32(Console.ReadLine());
                }
            }*/

            var test = Alternative1(input);

            Array.Sort(input);

            int highestRow = 0;
            int highestColumn = 0;

            int counter = 0;
            int x = 0, y = 0;
            while (x < R && counter < input.Length)
            {
                matrix[x,y] = input[counter];

                if (y == C - 1)
                {
                    x = highestRow;
                    highestColumn += 1;
                    y = highestColumn;
                } 
                else if (x == 0)
                {
                    x += highestRow + 1;
                    highestRow = x;
                    y = 0;

                }
                else
                {
                    x -= 1;
                    y += 1;
                }
                counter++;
            }

            Console.ReadLine();
        }
                 
    }
}
