using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HackerRank.Warmup
{
    public class CutTheSticks
    {
        public static void Code()
        {
            int N = Convert.ToInt32(Console.ReadLine());

            int[] sticks = Array.ConvertAll(Console.ReadLine().Split(' '), Convert.ToInt32);

            Array.Sort(sticks);

            int loop = 0;
            while (loop < N)
            {
                int lowest = sticks[loop];
                int counter = 0;
                for (int i = loop; i < N; i++)
                {
                    sticks[i] -= lowest;
                    if (sticks[i] == 0)
                    {
                        loop++;
                    }
                    counter++;
                }

                Console.WriteLine(counter);
            }

            Console.ReadLine();
        }
    }
}
