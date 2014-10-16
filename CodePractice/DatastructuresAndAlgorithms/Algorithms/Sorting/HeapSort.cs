using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sorting
{
    public class HeapSort
    {
        public static void Implementation()
        {
            var input = new int[] {6, 7, 2, 4, 5, 4, 3, 2, 1};
            Sort(input);
            Console.ReadLine();
        }

        public static void Sort(int[] input)
        {
            Heapify(input, input.Length);

            for (int i = input.Length - 1; i > 0; i--)
            {
                Swap(input, i, 0);
                SiftDown(input, 0, i-1);
            }
        }

        private static void Heapify(int[] input, int n)
        {

            //Find Last Parent Node
            //N/2 - 1
            var parent = (n - 2)/2;
            while (parent >= 0)
            {
                SiftDown(input, parent, n-1);
                //After finding last parent node, every node before it is a parent
                parent -= 1;
            }
        }

        private static void SiftDown(int[] input, int parent, int last)
        {
            int child = 2*parent + 1; //Left child
            while (child <= last)
            {
                if (child + 1 <= last
                    && input[child + 1] > input[child])
                {
                    child++;
                }

                if (input[child] > input[parent])
                {
                    Swap(input, child, parent);
                }
                //else
                //{
                //    break;
                //}

                parent = child;
                child = 2*parent;
            }
        }

        private static void Swap(int[] input, int from, int to)
        {
            int temp = input[from];
            input[from] = input[to];
            input[to] = temp;
        }
    }
}