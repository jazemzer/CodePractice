using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HackerRank.Algorithms
{
    public class MarkAndToys
    {

        public static void Code()
        {
            var NAndK = Console.ReadLine().Split(' ');
            var N = Convert.ToInt64(NAndK[0]);
            var K = Convert.ToInt64(NAndK[1]);

            var prices = Array.ConvertAll(Console.ReadLine().Split(' '), Convert.ToInt64);

            //var N = 1;
            //var K = 5;
            //var prices = Array.ConvertAll("10".Split(' '), Convert.ToInt64);

            Array.Sort(prices);

            int counter = 0;
            long sum = 0;
            for (int i = 0; i < prices.Length; i++)
            {
                sum += prices[i];
                if (sum > K)
                {
                    break;
                }
                else
                {
                    counter++;
                }
            }

            Console.WriteLine(counter);

            Console.ReadLine();
        }
                
    }
}
