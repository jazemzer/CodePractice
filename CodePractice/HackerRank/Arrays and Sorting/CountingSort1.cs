using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HackerRank.Algorithms
{
    public class CountingSort1
    {

        public static void Code()
        {
            int N = Convert.ToInt32(Console.ReadLine());
            var input = Array.ConvertAll(Console.ReadLine().Split(' '), Convert.ToInt32);

            var freq = new int[100];

            foreach (var item in input)
            {
                freq[item] += 1;
            }

            foreach (var item in freq)
            {
                Console.WriteLine(item + " ");
            }
            Console.WriteLine();

            Console.ReadLine();
        }
                
    }
}
