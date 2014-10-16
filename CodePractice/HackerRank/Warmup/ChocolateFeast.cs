using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HackerRank.Warmup
{
    public class ChocolateFeast
    {
        public static void Code()
        {
            int T = Convert.ToInt32(Console.ReadLine());
            while (T > 0)
            {
                var NCM = Console.ReadLine().Split(' ');
                int N = Convert.ToInt32(NCM[0]);
                int C = Convert.ToInt32(NCM[1]);
                int M = Convert.ToInt32(NCM[2]);

                int noofChoc = N/C;
                int bonus = noofChoc/M;
                int rem = noofChoc%M;

                noofChoc += bonus;

                while ((bonus + rem) >= M)
                {
                    bonus = (bonus + rem)/M;
                    rem = bonus > M ? bonus%M : 0;

                    noofChoc += bonus;
                }

                Console.WriteLine(noofChoc);

                T--;
            }

            Console.ReadLine();
        }

        
    }
}
