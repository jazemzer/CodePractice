using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HackerRank.Warmup
{
    public class SherlocakAndSquares
    {

        public static void Code()
        {
            int T = Convert.ToInt32(Console.ReadLine());
            while (T > 0)
            {
                var AandB = Console.ReadLine().Split(' ');
                var A = Convert.ToInt32(AandB[0]);
                var B = Convert.ToInt32(AandB[1]);

                var counter = 0;
                for (int i = 1; i <= B; i++)
                {
                    var square = i*i;
                    if (square > B)
                    {
                        break;
                    }
                    else if (square >= A && square <= B)
                    {
                        counter++;
                    }
                }

                Console.WriteLine(counter);
                T--;
            }

            Console.ReadLine();
        }
                
    }
}
