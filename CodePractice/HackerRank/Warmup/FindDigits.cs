using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HackerRank.Warmup
{
    public class FindDigits
    {

        public static void Code()
        {
            int T = Convert.ToInt32(Console.ReadLine());
            while (T > 0)
            {
                var input = Console.ReadLine();
                var N = Convert.ToDouble(input);

                double counter = 0;
                foreach (var digit in input)
                {
                    if (digit != '0')
                    {
                        if (Math.Abs(N % Char.GetNumericValue(digit)) < 0.1)
                        {
                            counter++;
                        }
                    }
                }

                Console.WriteLine(Math.Round(counter,0));
                T--;
            }

            Console.ReadLine();
        }
                
    }
}
