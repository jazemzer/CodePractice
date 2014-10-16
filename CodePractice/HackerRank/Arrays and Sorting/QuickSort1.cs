using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HackerRank.Algorithms
{
    public class QuickSort1
    {

        public static void Code()
        {

            var input = Array.ConvertAll("4 5 3 7 2".Split(' '), Convert.ToInt32);

            Partition(input);
            Console.ReadLine();
        }
                
        private static void Partition(int[] input)
        {
            int start = 0;
            int end = input.Length;

            int pivotIndex = start;
            int pivotValue = input[start];

            start++;
            while (start < end)
            {
                int temp = input[start];

                if (temp < pivotValue)
                {
                    int j = start;
                    while (j > pivotIndex)
                    {
                        input[j] = input[j-1];
                        j--;
                    }
                    input[j] = temp;
                    pivotIndex++;
                }
                start++;
            }

        }
    }
}
