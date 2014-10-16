using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HackerRank.Warmup
{
    public class SherlockAndBeast
    {

        private static void Print(int number, int times)
        {
            for (int i = 0; i < times; i++)
            {
                Console.Write(number);
            }
        }
        public static void Code()
        {
            int T = Convert.ToInt32(Console.ReadLine());
            while (T > 0)
            {
                int N = Convert.ToInt32(Console.ReadLine());

                if (N < 3)
                {
                    Console.Write(-1);
                }
                else if (N%3 == 0)
                {
                    Print(5, N);
                }
                else
                {
                    bool flag = false;
                    int loop = 5;
                    while (loop <= 10)
                    {
                        if ((N - loop)%3 == 0)
                        {
                            flag = true;
                            Print(5, N - loop);
                            Print(3, loop);
                        }

                        loop += 5;
                    }

                    if (!flag)
                    {
                        Console.Write(-1);
                    }

                }
                Console.WriteLine();

                T--;
            }

            Console.ReadLine();
        }

        public static void Code1()
        {
            int T = Convert.ToInt32(Console.ReadLine());
            while (T > 0)
            {
                int N = Convert.ToInt32(Console.ReadLine());

                var fiveQuot = N/3;

                while (fiveQuot >= 0)
                {
                    var fiveRem = N - fiveQuot*3;
                    if (fiveRem != 1 && fiveRem%5 == 0)
                    {
                        Console.WriteLine( fiveQuot * 3 + " : " + fiveRem);
                        for (int i = 0; i < fiveQuot * 3; i++)
                        {
                            Console.Write(5);
                        }
                        for (int i = 0; i < fiveRem; i++)
                        {
                            Console.Write(3);
                        }
                      
                       
                        Console.WriteLine();
                        break;
                    }
                    fiveQuot--;
                }

                if (fiveQuot < 0)
                {
                    Console.WriteLine(-1);
                }

                T--;
            }

            Console.ReadLine();
        }
                
    }
}
