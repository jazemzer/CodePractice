using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HackerRank.Algorithms
{
    public class InsertionSortPart1
    {
        public static void Code()
        {
            //int N = Convert.ToInt32(Console.ReadLine());
            //var input = Array.ConvertAll(Console.ReadLine().Split(' '), Convert.ToInt32);

            var input = new int[] { 2,4,6,8,3 };
            int N = 7;
            Sort(input);

            Console.ReadLine();
        }

        private static void Sort(int[] input)
        {
            int value = input[input.Length - 1];
            int j = input.Length - 1;

            while (j >= 0
                   && input[j] > value)
            {
                input[j + 1] = input[j];
                foreach (var item in input)
                {
                    Console.Write(item + " ");
                }
                Console.WriteLine();
                j--;
            }
            input[j + 1] = value;

            foreach (var item in input)
            {
                Console.Write(item + " ");
            }
            Console.WriteLine();

        }

    }
    
}
