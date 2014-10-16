using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HackerRank.Algorithms
{
    public class QuickSort2
    {

        public static void Code()
        {
            //int N = Convert.ToInt32(Console.ReadLine());
            //var input = Array.ConvertAll(Console.ReadLine().Split(' '), Convert.ToInt32);

            var input = new int[] { 5 ,8, 1, 3, 7, 9, 2 };
            int N = 7;
            Sort(input, 0, N - 1);

            Console.ReadLine();
        }

        private static void Sort(int[] input, int start, int end)
        {
            int pivotIndex = Partition(input, start, end);
            if (start < pivotIndex - 1)
            {
                Sort(input, start, pivotIndex - 1);
            }
            if (pivotIndex + 1 < end)
            {
                Sort(input, pivotIndex + 1, end);
            }
            for (int i = start; i <= end; i++)
            {
                Console.Write(input[i] + " ");
            }
            Console.WriteLine();
        }

        private static int Partition(int[] input, int start, int end)
        {
            #region Stable Partition
            int pivotIndex = start;
            int pivotValue = input[start];
            start++;
            while (start <= end)
            {
                if (input[start] < pivotValue)
                {
                    int temp = input[start];
                    for (int i = start; i > pivotIndex; i--)
                    {
                        input[i] = input[i - 1];
                    }
                    input[pivotIndex] = temp;
                    pivotIndex++;
                }

                //foreach (var item in input)
                //{
                //    Console.Write(item);
                //}
                //Console.WriteLine();
                start++;
            }

            #endregion
            #region Keeping element to the left of Array
            //int pivotIndex = end;
            //int pivotValue = input[start];
            //while (end > start)
            //{
            //    if (input[end] > pivotValue)
            //    {
            //        Swap(input, end, pivotIndex);
            //        pivotIndex--;
            //    }
            //    end--;
            //    foreach (var item in input)
            //    {
            //        Console.Write(item);
            //    }
            //    Console.WriteLine();
            //}

            //Swap(input, start, pivotIndex);
            #endregion


            //#region Keeping Pivot at the end of Array
            //int pivotIndex = start;
            //int pivotValue = input[pivotIndex];

            //// Moving pivot to end of the array
            //Swap(input, pivotIndex, end);

            ////Reusng PivotIndex to point to final Pivot position
            //pivotIndex = start;

            //for (int i = start; i < end; i++)
            //{
            //    if (input[i] < pivotValue)
            //    {
            //        Swap(input, pivotIndex, i);
            //        pivotIndex++;
            //    }

            //        foreach (var item in input)
            //        {
            //            Console.Write(item);
            //        }
            //        Console.WriteLine();
            //}

            

            ////Move pivot back to its right position
            //Swap(input, pivotIndex, end);

            //#endregion

            return pivotIndex;
        }

        static void Swap(int[] array, int from, int to)
        {
            int temp = array[from];
            array[from] = array[to];
            array[to] = temp;
        }
                
    }
}
