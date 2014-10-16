using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sorting
{
    class MergeSort
    {
        public static void Implementation()
        {
            int[] input = new[] { 1, 4, 5, 6, 8, 3, 46, 2, 4, };
            Sort(input);
        }

        static void Sort(int[] input)
        {
            int n = input.Length;
            if (n < 2)
                return;
            int halfSize = n/2; 
            int[] left = new int[halfSize];
            int[] right = new int[n%2 == 0? halfSize : halfSize + 1];

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

       static void Merge(int[] input, int[] a, int[] b)
        {
            int i = 0;
            int j = 0;
            int index = 0;

            int m = a.Length;
            int n = b.Length;

            while (i < m && j < n)
            {
                if (a[i] <= b[j])
                {
                    input[index] = a[i];
                    i++;
                    index++;
                }
                else
                {
                    input[index] = b[j];
                    j++;
                    index++;
                }
            }
            while (i < m)
            {
                input[index] = a[i];
                i++;
                index++;
            }
            while (j < n)
            {
                input[index] = b[j];
                j++;
                index++;
            }
        }
    }
}
