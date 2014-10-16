using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HackerRank.Algorithms
{
    public class InsertionSort
    {

        public static void Code()
        {
            //int T = Convert.ToInt32(Console.ReadLine());
            int T = 1;
            while (T > 0)
            {
                //int N = Convert.ToInt32(Console.ReadLine());
                //var input = Array.ConvertAll(Console.ReadLine().Split(' '), Convert.ToInt32);


                var input = Array.ConvertAll("2 1 3 1 2".Split(' '), Convert.ToInt32);
                int N = input.Length;

                Sort(input);

                Console.WriteLine(swapsRequired);
                swapsRequired = 0;

                T--;
            }

            Console.ReadLine();
        }

        private static int swapsRequired = 0;
        private static void Sort(int[] input)
        {            
            int n = input.Length;

            //1 or 0 elements
            if (n < 2)
            {
                return;
            }

            int halfSize = n/2;

            var left = new int[halfSize];
            var right = new int[n%2 == 0 ? halfSize : halfSize + 1];

            for (int i = 0; i < n; i++)
            {
                if (i < halfSize)
                {
                    left[i] = input[i];
                }
                else
                {
                    right[i - halfSize] = input[i];
                }
            }

            Sort(left);
            Sort(right);

            Merge(input, left, right);
        }

        private static void Merge(int[] input, int[] left, int[] right)
        {
            int i = 0, j = 0, k = 0;
            int m = left.Length;
            int n = right.Length;

            while (i < m && j < n)
            {
                if (left[i] <= right[j])
                {
                    input[k] = left[i];
                    i++;
                    k++;
                }
                else
                {
                    swapsRequired += (m - i);

                    input[k] = right[j];
                    j++;
                    k++;

                }
            }

            while (i < m)
            {
                input[k] = left[i];
                i++;
                k++;
            }

            while (j < n)
            {
                input[k] = right[j];
                j++;
                k++;
            }
        }
                
    }
}
