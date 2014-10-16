using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HackerRank.Algorithms
{
    public class CuttingBoard
    {

        public static void Code()
        {
            int T = Convert.ToInt32(Console.ReadLine());
            while (T > 0)
            {
                var MandN = Console.ReadLine().Split(' ');
                var M = Convert.ToInt32(MandN[0]);
                var N = Convert.ToInt32(MandN[1]);

                var prime = 1000000007;

                var y = Array.ConvertAll(Console.ReadLine().Split(' '), Convert.ToInt32);
                var x = Array.ConvertAll(Console.ReadLine().Split(' '), Convert.ToInt32);

                Array.Sort(x);
                Array.Sort(y);

                long sum = 0;

                int xIndex = N - 1;
                int yIndex = M - 1;

                int xPieces = 1;
                int yPieces = 1;
                while (xPieces < N || yPieces < M)
                {
                    var yCutEstimate = yIndex < 0? 0 : xPieces * y[yIndex];
                    var xCutEstimate = xIndex < 0? 0: yPieces * x[xIndex];

                    if (y[yIndex] >= x[xIndex])
                    {
                        sum += yCutEstimate;
                        sum %= prime;
                        yIndex --;
                        yPieces++;
                    }
                    else
                    {
                        sum += xCutEstimate;
                        sum %= prime;

                        xIndex--;
                        xPieces++;
                    }
                }

                Console.WriteLine(sum);
                T--;
            }

            Console.ReadLine();
        }
                
    }
}
