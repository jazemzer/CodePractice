using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HackerRank.Search
{
    public class LonelyInteger
    {

        public static void Code()
        {
            int N = Convert.ToInt32(Console.ReadLine());
            var input = Array.ConvertAll(Console.ReadLine().Split(' '), Convert.ToInt32);

            var XORSum = 0;
            foreach (var i in input)
            {
                XORSum ^= i;
            }

            Console.WriteLine(XORSum);

            Console.ReadLine();
        }
                
    }
}
