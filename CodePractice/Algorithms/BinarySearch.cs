using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CodePractice.Algorithms
{
    public class BinarySearch
    {

        public static void Implementation()
        {


        }

        //Nonrecursive approach
        private static int FindRank(int search, int[] input)
        {
            int rank = -1;

            int lo = 0;
            int hi = input.Length - 1;

            int mid = -1;
            while (lo <= hi)
            {
                mid = lo + (hi - lo) / 2;
                if (search == input[mid])
                {
                    rank = mid;
                    break;
                }
                else if (rank < mid)
                {
                    hi = mid - 1;
                }
                else
                {
                    lo = mid + 1;
                }
            }

            return rank;
        }


                
    }
}
