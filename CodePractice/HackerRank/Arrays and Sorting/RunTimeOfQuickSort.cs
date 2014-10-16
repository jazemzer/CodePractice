using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HackerRank.Algorithms
{
    public class RunTimeOfQuickSort
    {
        public static void Code()
        {
            //int N = Convert.ToInt32(Console.ReadLine());
            //var input = Array.ConvertAll(Console.ReadLine().Split(' '), Convert.ToInt32);

            int N = 7;
            var input = Array.ConvertAll("1 3 9 8 2 7 5".Split(' '), Convert.ToInt32);
            int[] input1 = new int[N];

            Array.Copy(input, 0, input1, 0, N);
            QuickSort(input, 0, N - 1);
            var D = InsertionSort(input1) - quickSortCounter;
            Console.WriteLine(D);
        }

        private static int InsertionSort(int[] input)
        {
            int temp = -1, j = -1;
            int counter = 0;
            for (int i = 1; i < input.Length; i++)
            {
                temp = input[i];
                j = i - 1;
                while (j >= 0
                    && temp < input[j])
                {
                    input[j + 1] = input[j];
                    j--;
                    counter++;
                }
                input[j + 1] = temp;
            }

            return counter;
        }


        private static void QuickSort(int[] input, int start, int end)
        {
            int pivotIndex = Partition(input, start, end);
            if (start < pivotIndex - 1)
            {
                QuickSort(input, start, pivotIndex - 1);
            }
            if (pivotIndex + 1 < end)
            {
                QuickSort(input, pivotIndex + 1, end);
            }
        }

        private static int Partition(int[] input, int start, int end)
        {
            int pivotIndex = start;
            int pivotValue = input[end];

            for (int i = start; i < end; i++)
            {
                if (input[i] < pivotValue)
                {
                    Swap(input, pivotIndex, i);
                    pivotIndex++;
                }

            }

            //Move pivot back to its right position
            Swap(input, pivotIndex, end);

            return pivotIndex;
        }

        static int quickSortCounter = 0;
        static void Swap(int[] array, int from, int to)
        {
            int temp = array[from];
            array[from] = array[to];
            array[to] = temp;
            quickSortCounter++;
        }
    }
}
