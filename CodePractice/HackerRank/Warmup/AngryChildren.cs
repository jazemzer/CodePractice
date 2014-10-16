using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HackerRank.Warmup
{
    public class AngryChildren
    {

        public static void Code()
        {
            int N = Convert.ToInt32(Console.ReadLine());
            int K = Convert.ToInt32(Console.ReadLine());

            var packets = new int[N];
            for (int i = 0; i < N; i++)
            {
                packets[i] = Convert.ToInt32(Console.ReadLine());
            }

            Array.Sort(packets);

            int start = 0, end = K - 1;



            var minRange = Int32.MaxValue;

            //Special Condition when K = 1. Give chocolate to only one person
            if (K == 1)
            {
                minRange = 0;
            }
            else
            {
                while (end < N)
                {
                    var temp = packets[end] - packets[start];
                    if (temp < minRange)
                    {
                        minRange = temp;
                    }
                    end++;
                    start++;
                }
            }

            Console. WriteLine(minRange);

            Console.ReadLine();
        }
                
    }
}
