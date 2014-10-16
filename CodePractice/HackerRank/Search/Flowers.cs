using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HackerRank.Search
{
    public class Flowers
    {

        public static void Code()
        {
            var NandK = "3 2".Split(' ');
            var n = Convert.ToInt32(NandK[0]);
            var k = Convert.ToInt32(NandK[1]);

            var c = Array.ConvertAll("2 5 6".Split(' '), Convert.ToInt32);

            Array.Sort(c);

            int iter = 0;
            int personCounter = 0;
            int sum = 0;
            for (int i = c.Length - 1; i >= 0; i--)
            {
                personCounter = (personCounter+ 1)%k;
                sum += (iter + 1)*c[i];

                if (personCounter == 0)
                {
                    iter++;
                }
            }

            Console.WriteLine(sum);


            Console.ReadLine();
        }
                
    }
}
