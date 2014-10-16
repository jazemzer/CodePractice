using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HackerRank.Warmup
{
    public class LoveLetterMystery
    {
        public static void Code()
        {
            //https://www.hackerrank.com/challenges/the-love-letter-mystery

            int T = Convert.ToInt32(Console.ReadLine());

            while (T > 0)
            {
                string input = Console.ReadLine();

                int i = 0;
                int j = input.Length - 1;

                int counter = 0;

                while (i <= j)
                {
                    int diff = Math.Abs(input[i] - input[j]);
                    counter += diff;

                    i++;
                    j--;
                }

                Console.WriteLine(counter);
                T--;
            }

            Console.ReadLine();
        }
    }
}
