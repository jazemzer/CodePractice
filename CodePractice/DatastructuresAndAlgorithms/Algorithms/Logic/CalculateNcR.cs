using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logic
{
    public class CalculateNcR
    {
        public static void Implementation()
        {
            var input = new int[] {1, 2, 3, 4, 5};
            int n = input.Length;
            int r = 2;
            var output = new int[r];
            Recursive(input, 0, 0, n, r, output);
            Console.ReadLine();
        }

        private static void Recursive(int[] input, int level, int index, int n, int r, int[] output)
        {
            if (level == r)
            {
                for (int i = 0; i < level; i++)
                {
                    Console.Write(output[i]);
                }
                Console.WriteLine();
                return;
            }

            if (index >= n)
            {
                return;
            }
            output[level] = input[index];
            Recursive(input, level + 1, index + 1, n ,r, output);
            Recursive(input, level, index + 1, n, r, output);
        }

    }
}
