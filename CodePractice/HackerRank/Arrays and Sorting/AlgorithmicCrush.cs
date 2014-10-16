using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HackerRank.Algorithms
{
    public class AlgorithmicCrush
    {

        public static void Code()
        {
            var NandM = Console.ReadLine().Split(' ');
            var N = Convert.ToInt32(NandM[0]);
            var M = Convert.ToInt32(NandM[1]);

            var array = new Int64[N +2];
            while (M > 0)
            {
                var ABK = Console.ReadLine().Split(' ');
                var a = Convert.ToInt32(ABK[0]);
                var b = Convert.ToInt32(ABK[1]);
                var k = Convert.ToInt32(ABK[2]);

                array[a] += k;
                array[b + 1] -= k;

                M--;
            }

            long cumulative = 0;
            long max = 0;
            for (int i = 1; i <= N; i++)
            {
                cumulative += array[i];
                if (cumulative > max)
                {
                    max = cumulative;
                }
            }

            Console.WriteLine(max);

            Console.ReadLine();
        }
                
    }
}
