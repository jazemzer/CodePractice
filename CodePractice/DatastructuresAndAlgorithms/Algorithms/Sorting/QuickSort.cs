using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sorting
{
    public class QuickSort
    {

        public static void Implementation()
        {
            int[] input = new[] {1, 4, 5, 6, 8, 3, 46, 2, 4,};
            Sort(input, 0,  input.Length - 1);
        }

        static void Sort(int[] array, int left, int right)
        {
            int pivot = Partition(array, left, right);
            if(left < pivot -1 )
                Sort(array, left, pivot - 1);
            if(pivot + 1 < right)
                Sort(array, pivot + 1, right);
        }

        static int Partition(int[] array, int left, int right)
        {
            //Choosing a pivot
            int pivotIndex = (right + left)/2;


            int pivotValue = array[pivotIndex];

            // Moving pivot to end of the array
            Swap(array,pivotIndex,right);

            //Reusng PivotIndex to point to final Pivot position
            pivotIndex = left;

            for (int i = left; i < right; i++)
            {
                if (array[i] < pivotValue)
                {
                    Swap(array, pivotIndex, i);
                    pivotIndex ++;
                }
            }

            //Move pivot back to its right position
            Swap(array, pivotIndex, right);

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
