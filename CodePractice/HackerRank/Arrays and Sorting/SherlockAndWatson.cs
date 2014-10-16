using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HackerRank.Algorithms
{
    public class SherlockAndWatson
    {

        public static void Code()
        {
            var NKQ = Console.ReadLine().Split(' ');
            var N = Convert.ToInt32(NKQ[0]);
            var K = Convert.ToInt32(NKQ[1]);
            var Q = Convert.ToInt32(NKQ[2]);

            var input = Array.ConvertAll(Console.ReadLine().Split(' '), Convert.ToInt32);
            K %= N;
            while (Q > 0)
            {
                var index = Convert.ToInt32(Console.ReadLine());
                    Console.WriteLine(input[(N-K +index)%N]);
                Q--;
            }

            Console.ReadLine();
        }
                
    }
}
