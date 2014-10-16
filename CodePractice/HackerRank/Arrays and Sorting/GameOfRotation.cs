using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HackerRank.Algorithms
{
    public class GameOfRotation
    {

        public static void Code()
        {
            int N = Convert.ToInt32(Console.ReadLine());
            var input = Array.ConvertAll(Console.ReadLine().Split(' '), Convert.ToInt64);

            long curr_weight = 0;
            long sum = 0; 
            for (int i = 0; i < N; i++)
            {
                curr_weight += input[i]*(i + 1);
                sum += input[i];
            }
            long max_weight = 0;
            for (int i = 0; i < N -1; i++)
            {
                curr_weight = curr_weight - sum + (input[i]*N);

                if (curr_weight > max_weight)
                {
                    max_weight = curr_weight;
                }
            }

            Console.WriteLine(curr_weight);


            Console.ReadLine();
        }
                
    }
}
