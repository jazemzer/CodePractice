using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HackerRank.Warmup
{
    public class UtopianTree
    {
        public static void Code()
        {
            int T = Convert.ToInt32(Console.ReadLine()); 

            while (T > 0)
            {
                int cycles = Convert.ToInt32(Console.ReadLine());

                int height = 1;

                bool isFirstCycle = true;

                for (int i = 0; i < cycles; i++)
                {
                    if (isFirstCycle)
                    {
                        height += height;
                        isFirstCycle = false;
                    }
                    else
                    {
                        height += 1;
                        isFirstCycle = true;
                    }
                }

                Console.WriteLine(height);

                T--;
            }

            Console.ReadLine();
        }
    }
}
