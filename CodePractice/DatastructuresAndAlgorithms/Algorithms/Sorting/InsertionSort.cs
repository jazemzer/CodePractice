using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sorting
{
    public class InsertionSort
    {
        public static void Implementation()
        {
            var input = new int[] {5, 4, 3, 2, 1};
            Sort(input);
            Console.ReadLine();
        }

        private static void Sort(int[] input)
        {
            int temp = -1, j = -1;
            for (int i = 1; i < input.Length; i++)
            {
                temp = input[i];
                j = i - 1;
                while (j >= 0
                    && temp < input[j])
                {
                    input[j + 1] = input[j];
                    j--;
                }
                input[j+1] = temp;
            }
        }
    }
}
