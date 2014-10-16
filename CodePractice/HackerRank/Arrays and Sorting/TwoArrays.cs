using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HackerRank.Algorithms
{
    public class TwoArrays
    {

        public static void Code()
        {
            int T = Convert.ToInt32(Console.ReadLine());
            while (T > 0)
            {
                var NAndK = Console.ReadLine().Split(' ');
                var N = Convert.ToInt64(NAndK[0]);
                var K = Convert.ToInt64(NAndK[1]);

                var A = Array.ConvertAll(Console.ReadLine().Split(' '), Convert.ToInt64);
                var B = Array.ConvertAll(Console.ReadLine().Split(' '), Convert.ToInt64);

                Array.Sort(A);
                Array.Sort(B);

                bool flag = false;
                for (int i = 0; i < N; i++)
                {
                    if (A[i] + B[N - 1 - i] <= K)
                    {
                        flag = true;
                        break;
                    }
                }

                if (flag)
                {
                    Console.WriteLine("NO");
                }
                else
                {
                    Console.WriteLine("YES");
                }

                T--;
            }

            Console.ReadLine();
        }
                
    }
}
