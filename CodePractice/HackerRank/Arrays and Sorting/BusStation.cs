using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HackerRank.Algorithms
{
    public class BusStation
    {

        public static void Code()
        {
            //int n = Convert.ToInt32(Console.ReadLine());
            //var input = Array.ConvertAll(Console.ReadLine().Split(' '), Convert.ToInt32);

            int n = 8; // Convert.ToInt32(Console.ReadLine());
            var input = Array.ConvertAll("1 2 1 1 1 2 1 3".Split(' '), Convert.ToInt32);

            var freq = new long[n];

            Array.Copy(input, freq, n);
            
            for (int i = 1; i < n; i++)
            {
                freq[i] += freq[i - 1];
            }

            long sum = freq[n - 1];

            var output = new List<long>();
            for (long i = 0; i< n; i++)
            {
                if (sum%freq[i] == 0 && freq[i] <= sum/2)
                {
                    var iter = 2;
                    while (iter*freq[i] <= sum)
                    {
                        if (Array.BinarySearch(freq, iter*freq[i]) > 0)
                        {
                            iter++;
                        }
                        else
                        {
                            break;
                        }
                    }

                    if (iter - 1 == sum/freq[i])
                    {
                        output.Add(freq[i]);
                    }
                }
            }

            output.Add(sum);

            
            Console.WriteLine(string.Join(" ",output));

            Console.ReadLine();
        }
                
    }
}
