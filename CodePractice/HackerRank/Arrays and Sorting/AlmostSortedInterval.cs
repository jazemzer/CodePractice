using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HackerRank.Algorithms
{
    public class AlmostSortedInterval
    {

        public static void Code()
        {
            //int N = Convert.ToInt32(Console.ReadLine());
            //var input = Array.ConvertAll(Console.ReadLine().Split(' '), Convert.ToInt32);

            int N = 5;
                    var input = Array.ConvertAll("1 4 2 5 3".Split(' '), Convert.ToInt32);
           
            long counter = 0;

            int prev = 0; //Largest number
            int interval = 0;
            for (int i = 0; i < N; i++)
            {
                if (input[i] < prev)
                {
                    counter += (interval*(interval + 1))/2;
                    interval = 1;
                }
                else
                {
                    interval += 1;
                }
                prev = input[i];
            }
            counter += (interval * (interval + 1)) / 2;

            Console.WriteLine(counter);

            Console.ReadLine();
        }
                
    }
}
