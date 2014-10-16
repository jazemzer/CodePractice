using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HackerRank.Warmup
{
    public class HalloweenParty
    {
        public static void Code()
        {
            int T = Convert.ToInt32(Console.ReadLine());

            while (T > 0)
            {
                int K = Convert.ToInt32(Console.ReadLine());

                long a = K/2;
                long b = K - a;

                Console.WriteLine(a * b);
                T--;
            }
        }
    }
}
