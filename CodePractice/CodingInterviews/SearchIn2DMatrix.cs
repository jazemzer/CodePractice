using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CodePractice.CodingInterviews
{
    public class SearchIn2DMatrix
    {
        public static void Code()
        {
            var input = new int[3, 3]
            {
               { 1, 3, 5},
               {7, 9, 11}, 
               {13, 15, 17}
            };

            searchFor(5, input);
        }

        private static int searchFor(int n, int[,] matrix)
        {
            int rows = matrix.Length;
            var start = 0;
            var end = rows;

            return -1;
        }
    }
}
