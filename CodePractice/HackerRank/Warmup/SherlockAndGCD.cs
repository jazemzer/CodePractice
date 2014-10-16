using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HackerRank.Warmup
{
    public class SherlockAndGCD
    {

        public static void Code()
        {
            int T = Convert.ToInt32(Console.ReadLine());
            while (T > 0)
            {
                int N = Convert.ToInt32(Console.ReadLine());
                var A = Array.ConvertAll(Console.ReadLine().Split(' '), Convert.ToInt32);

                int prevGCD = A[0];
                for (int i = 1; i < N; i++)
                {
                    prevGCD = GCD(prevGCD, A[i]);
                }

                if (prevGCD == 1)
                {
                    Console.WriteLine("YES");
                }
                else
                {
                    Console.WriteLine("NO");                    
                }
                T--;
            }


            Console.ReadLine();
        }


        private static int GCD(int a, int b, int d = 1)
        {
            if (a%2 == 0)
            {
                if (b%2 == 0)
                {
                    // a and b are even
                    d += d;
                    return GCD(a/2, b/2, d);
                }
                else
                {
                    // a is even , b is odd
                    return GCD(a/2, b, d);
                }
            }
            else
            {
                if (b%2 == 0)
                {
                    // a is odd, b is even
                    return GCD(a, b/2, d);
                }
                else
                {
                    // Both a and b are odd
                    int max = a > b ? a : b;
                    int min = a < b ? a : b;
                    int c = (max - min)/2;

                    if (c == 0)
                    {
                        return min * d;
                    }
                    return GCD(min, c, d);
                }
            }
        }
                
    }
}
