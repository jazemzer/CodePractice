using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HackerRank.Warmup
{
    public class SherlockAndQueries
    {
        public static void Code()
        {
            var NandM = Console.ReadLine().Split(' ');
            int N = Convert.ToInt32(NandM[0]);
            int M = Convert.ToInt32(NandM[1]);

            var A = Array.ConvertAll(Console.ReadLine().Split(' '), Convert.ToInt64);
            var B = Array.ConvertAll(Console.ReadLine().Split(' '), Convert.ToInt64);
            var C = Array.ConvertAll(Console.ReadLine().Split(' '), Convert.ToInt64);
            /*int N = 4;
            int M = 3;
            var A = new long[] { 1, 2, 3, 4 };
            var B = new long[] { 1, 2, 3 };
            var C = new long[] { 13, 29, 71 };
*/
            var counter = Enumerable.Repeat(-1L, N).ToArray();
            var prime = (long) Math.Pow(10, 9) + 7;

            for (int i = 0; i < M; i++)
            {
                var temp = counter[ B[i] - 1];
                if (temp == -1)
                {
                    counter[B[i] - 1] = C[i]%prime;
                }
                else
                {
                    counter[B[i] - 1] = (temp * (C[i] % prime)) % prime;
                }
            }

            for (int i = 1; i <= N; i++)
            {

                for (int j = 1; j <= N/i; j++)
                {
                    if (counter[i - 1] != -1)
                    {
                        A[(j*i) - 1] =  ((A[(j*i) - 1]%prime)*counter[i - 1])%prime;
                    }
                }
            }

            foreach (var item in A)
            {
                Console.Write(item + " ");
            }



            Console.ReadLine();
        }

        /// <summary>
        /// Brute force
        /// </summary>
        public static void Code1()
        {
            var NandM = Console.ReadLine().Split(' ');
            int N = Convert.ToInt32(NandM[0]);
            int M = Convert.ToInt32(NandM[1]);

            var A = Array.ConvertAll(Console.ReadLine().Split(' '), Convert.ToDouble);
            var B = Array.ConvertAll(Console.ReadLine().Split(' '), Convert.ToDouble);
            var C = Array.ConvertAll(Console.ReadLine().Split(' '), Convert.ToDouble);

            var prime = Math.Pow(10, 9) + 7;

            for (int x = 0; x < N; x++)
            {
                A[x] = A[x]%prime;
            }

            for (int x = 0; x < M; x++)
            {
                C[x] = C[x] % prime;
            }

            for (int i = 1; i <= M; i++)
            {
                for (int j = 1; j <= N; j++)
                {
                    if (j%B[i - 1] == 0)
                    {
                        A[j - 1] = (int) (  (A[j - 1] * C[i - 1]) % prime);
                    }
                }
            }

            foreach (var item in A)
            {
                Console.Write(item +" ");
            }



            Console.ReadLine();
        }
                
    }
}
