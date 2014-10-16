using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HackerRank.Warmup
{
    public class MaximizingXOR
    {
        public static void Code()
        {
            int L = Convert.ToInt32(Console.ReadLine());
            int R = Convert.ToInt32(Console.ReadLine());

            int maxXOR = 0;
            int temp = 0;
            for (int i = L; i <= R; i++)
            {
                for (int j = i + 1; j <= R; j++)
                {
                    temp = i ^ j;
                    if (temp > maxXOR)
                    {
                        maxXOR = temp;
                    }
                }
            }

            Console.WriteLine(maxXOR);

        }
    }
}
