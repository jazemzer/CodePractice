using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HackerRank.Algorithms
{
    public class CorrectnessAndLoopVariant
    {
        public static void Code()
        {
            //int N = Convert.ToInt32(Console.ReadLine());
            var input = Array.ConvertAll("1 4 3 5 6 2".Split(' '), Convert.ToInt32);

            int N = 6;
            Sort(input, N);


            Console.ReadLine();
        }

        private static void Sort(int[] input, int n)
        {
            for (int i = 1; i < n; i++)
            {
                int temp = input[i];
                int j = i - 1;

                while (j >= 0
                    && input[j] > temp)
                {
                    input[j + 1] = input[j];
                    j--;
                }
                input[j + 1] = temp;

            
            }
            foreach (var item in input)
            {
                Console.Write(item + " ");
            }
            Console.WriteLine();

        }
    }
}
