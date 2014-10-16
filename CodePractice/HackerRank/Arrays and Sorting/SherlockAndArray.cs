using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HackerRank.Algorithms
{
    public class SherlockAndArray
    {


        public static void Code()
        {
            int T = Convert.ToInt32(Console.ReadLine());
            while (T > 0)
            {
                var N = Convert.ToInt32(Console.ReadLine());
                var input = Array.ConvertAll(Console.ReadLine().Split(' '), Convert.ToInt32);


                int start = -1, end = N ;
                bool found = false;
                int sumleft = 0, sumRight = 0;
                while (start < end)
                {
                    if (sumleft == sumRight)
                    {
                        if (end - start == 2)
                        {
                            found = true;
                            break;
                        }
                        sumleft += input[++start];
                        sumRight += input[--end];
                    }
                    else if (sumleft > sumRight)
                    {
                        sumRight += input[--end];
                    }
                    else 
                    {
                        sumleft += input[++start];                        
                    }
                }

                if (found)
                {
                    Console.WriteLine("YES");
                }
                else
                {
                    Console.WriteLine("NO");                    
                }
                T--;
            }

            Console.ReadLine();
        }
                
                
    }
}
