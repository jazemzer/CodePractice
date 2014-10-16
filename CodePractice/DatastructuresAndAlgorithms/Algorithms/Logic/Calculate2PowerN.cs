using System;

namespace Logic
{
    public class Calculate2PowerN
    {
        public static void Code()
        {
            var input = new int[] { 1, 2, 3, 4, 5 };
            int n = input.Length;
            var output = new int[n];

            //Recursive(input, 0, 0, n, output);
            WithoutForLoop(input, 0, 0, n, output);
            Console.ReadLine();
        }

    

        private static void WithoutForLoop(int[] input, int level, int index, int n, int[] output)
        {
            if (index == n)
            {
                for (int i = 0; i < level; i++)
                {
                    Console.Write(output[i]);
                }

                Console.WriteLine();
                return;
            }
            output[level] = input[index];
            WithoutForLoop(input, level + 1, index + 1, n, output);
            WithoutForLoop(input, level, index + 1, n, output);
        }

        private static void Recursive(int[] input, int level, int index, int n, int[] output)
        {
            if (index == n)
            {
                return;
            }
            for (int i = index; i < n; i++)
            {
                output[level] = input[i];
                //Console.WriteLine("Level : " + level + " Index : " + i);
                PrintOutput(output, level);
                Recursive(input, level + 1, i + 1, n, output);
            }
        }

        private static void PrintOutput(int[] data, int end)
        {
            for (int i = 0; i <= end; i++)
            {
                Console.Write(data[i]);
            }

            Console.WriteLine();
        }

    }
}