using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HackerRank.Search
{
    public class IceCreamParlour
    {

        public static void Code()
        {
            int T = Convert.ToInt32(Console.ReadLine());
            while (T > 0)
            {
                int M = Convert.ToInt32(Console.ReadLine());
                int N = Convert.ToInt32(Console.ReadLine());
                var C = Array.ConvertAll(Console.ReadLine().Split(' '), Convert.ToInt32);

                bool found = false;
                for (int i = 0; i < N; i++)
                {
                    for (int j = i+1; j < N; j++)
                    {
                        if (C[i] + C[j] == M)
                        {
                            Console.WriteLine(string.Format("{0} {1}",i+1,j+1));
                            found = true;
                            break;
                        }
                    }
                    if (found)
                        break;
                }
                T--;
            }

            Console.ReadLine();
        }
                
    }
}
