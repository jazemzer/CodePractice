using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HackerRank.Warmup
{
    public class IsFibo
    {
        /// <summary>
        /// http://www.geeksforgeeks.org/check-number-fibonacci-number/
        /// </summary>
        public static void Code()
        {
            int T = Convert.ToInt32(Console.ReadLine());
            var memCache = new List<double>();

            double FLast = 1, FLastButOne = 0;
            memCache.Add(FLastButOne);
            memCache.Add(FLast);
            while (T > 0)
            {
                double N = Convert.ToDouble(Console.ReadLine());
                bool found = false;
                if (N > FLast)
                {
                    while(N > FLast)
                    {
                        var temp = FLast;
                        FLast += FLastButOne;
                        memCache.Add(FLast);

                        FLastButOne = temp;

                        if (Math.Abs(N - FLast) < 0.01)
                        {
                            found = true;
                            break;
                        }                        
                    }
                   
                }
                else if (memCache.BinarySearch(N) > -1)
                {
                    found = true;
                }


                Console.WriteLine(found ? "IsFibo" : "IsNotFibo");

                T--;
            }

            Console.ReadLine();
        }

        
        public static void Code1()
        {
            int T = Convert.ToInt32(Console.ReadLine());
            while (T > 0)
            {
                double N = Convert.ToDouble(Console.ReadLine());

                
                var temp = 5 * N * N;
                if (temp == 0.0
                    || IsPerfectSquare(temp + 4)
                    || IsPerfectSquare(temp - 4))
                {
                    Console.WriteLine("IsFibo");
                }
                else
                {
                    Console.WriteLine("IsNotFibo");

                }
                T--;
            }

            Console.ReadLine();
        }
      

        private static bool IsPerfectSquare(double n)
        {
            var s = Math.Sqrt(n);
            var diff = Math.Abs(s*s - n);
            return diff == 0.0;
        }
    }
}
