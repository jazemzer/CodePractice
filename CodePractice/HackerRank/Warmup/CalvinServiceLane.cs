using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HackerRank.Warmup
{
    public class CalvinServiceLane
    {
        public static void Code()
        {
            //https://www.hackerrank.com/challenges/service-lane

            var NandT = Console.ReadLine();
            var split = NandT.Split(' ');
             int N = Convert.ToInt32(split[0]); 
             int T = Convert.ToInt32(split[1]);

            var Width = Array.ConvertAll(Console.ReadLine().Split(' '),Convert.ToInt32);


            while (T > 0)
            {
                var iAndj = Console.ReadLine();
                split = NandT.Split(' ');
                int i = Convert.ToInt32(split[0]);
                int j = Convert.ToInt32(split[1]);

                int[] counter = new int[3]; //car,bike,truck

                int pos = 0;
                for (int loop = i; loop <= j; loop++)
                {
                    pos = Width[loop] - 1;
                    counter[pos] += 1;
                }

                if (counter[0] > 0)
                {
                    Console.WriteLine(1);
                }
                else if (counter[1] > 0)
                {
                    Console.WriteLine(2);                    
                }
                else if (counter[2] > 0)
                {
                    Console.WriteLine(3);
                }
                T--;
            }


            Console.ReadLine();
        }
    }
}
