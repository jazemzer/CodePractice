using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace HackerRank.Contests.Week11
{
    public class SherlockAndSquares
    {

        public static void Code()
        {
            int T = Convert.ToInt32(Console.ReadLine());
            while (T > 0)
            {
                T--;
                int n = Convert.ToInt32(Console.ReadLine());
                Console.WriteLine(BigInteger.ModPow(2, n, 1000000007));
            }

            Console.ReadLine();
        }
                
    }
}
