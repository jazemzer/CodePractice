using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HackerRank.Warmup
{
    public class CombinationTree
    {

        public static void Code()
        {
            int[] input = new[] {1, 2, 3, 4};
            //Recursive(input,0,-1,0,input.Length - 1);

            RecursivelyPrint(new List<int>(), new List<int>(input) );
        }

        private static void PrintSubset(int[] input, int start, int end)
        {
            for (int i = start; i <= end; i++)
            {
                Console.Write(input[i]);
            }
            Console.WriteLine();
        }

        private static void Recursive(int[] input, int leftStart, int leftEnd, int rightStart, int rightEnd)
        {
            if (rightStart > rightEnd)
            {
                PrintSubset(input, leftStart, leftEnd);
                return;
            }
            for (int i = rightStart; i <= rightEnd; i++)
            {
                Recursive(input, leftStart, leftEnd++, rightStart++, rightEnd);
                leftStart++;
            }
            PrintSubset(input, leftStart, leftEnd);
        }

        private static void RecursivelyPrint(List<int> A, List<int> B)
        {
            if (B.Count == 0)
            {
                A.ForEach(Console.Write);
                Console.WriteLine();
                return;
            }

            for (var i = 0; i < B.Count; i++)
            {
                List<int> tmp = new List<int>(A);
                tmp.Add(B[i]);

                List<int> tmp2 = new List<int>();
                for (var j = i + 1; j < B.Count; j++)
                {
                    tmp2.Add(B[j]);
                }
                RecursivelyPrint(tmp, tmp2);
            }

            A.ForEach(Console.Write);
            Console.WriteLine();
        }
    }
}
