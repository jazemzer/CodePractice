using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HackerRank.Warmup
{
    public class FillingJars
    {

        public static void Code()
        {
            var test = Math.Pow(10, 6)*Math.Pow(10, 7)*Math.Pow(10, 6);
            var NandM = Console.ReadLine().Split(' ');
            int N = Convert.ToInt32(NandM[0]);
            int M = Convert.ToInt32(NandM[1]);


            double totalCandies = 0;
            while (M > 0)
            {
                var ABK = Console.ReadLine().Split(' ');
                var A = Convert.ToDouble(ABK[0]);
                var B = Convert.ToDouble(ABK[1]);
                var K = Convert.ToDouble(ABK[2]);

                totalCandies += (B - A + 1)*K;

                M--;
            }

            Console.WriteLine(Math.Round(Math.Floor(totalCandies/N), 0));

            Console.ReadLine();
        }
                
    }
}
