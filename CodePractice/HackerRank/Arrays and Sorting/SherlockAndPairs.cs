using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HackerRank.Algorithms
{
    public class SherlockAndPairs
    {

        public static void Code()
        {
            int T = Convert.ToInt32(Console.ReadLine());
            while (T > 0)
            {
                int N = Convert.ToInt32(Console.ReadLine());
                var input = Array.ConvertAll(Console.ReadLine().Split(' '), Convert.ToInt32);

                var freq = new long[1000001];

                foreach (var item in input)
                {
                    freq[item]++;
                }

                double counter = 0; 
                for (int i = 1; i < 1000001; i++)
                {
                    counter += (freq[i]*(freq[i] - 1));
                }

                Console.WriteLine(counter);
                T--;
            }

            Console.ReadLine();
        }
                
    }
}
