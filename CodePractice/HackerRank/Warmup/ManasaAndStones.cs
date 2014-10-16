using System;

namespace HackerRank.Warmup
{
    public class ManasaAndStones
    {
        public static void Code()
        {
            int No_Of_Test_Cases = Convert.ToInt32(Console.ReadLine());
            while (No_Of_Test_Cases > 0)
            {
                int No_Of_Stones = Convert.ToInt32(Console.ReadLine());
                int a = Convert.ToInt32(Console.ReadLine());
                int b = Convert.ToInt32(Console.ReadLine());

                int min = a < b ? a : b;
                int max = a > b ? a : b;
                int loop = No_Of_Stones - 1;

                long[] output;
                long minSum = min*(No_Of_Stones - 1);

                //The first stone is the last stone
                if (No_Of_Stones == 1)
                {
                    output = new long[1];
                    output[0] = 0;
                }
                else if (a == b)
                {
                    output = new long[1];
                    output[0] = minSum;
                }
                else
                {
                    output = new long[No_Of_Stones];
                    output[0] = minSum;
                    for (int i = 1; i < No_Of_Stones; i++)
                    {
                        minSum = minSum - min + max;
                        output[i] = minSum;
                    }
                }

                No_Of_Test_Cases--;
                Console.WriteLine(string.Join(" ",output));
            }

            Console.ReadLine();
        }
    }
}
