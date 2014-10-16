using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HackerRank.Search
{
    public class Encryption
    {

        public static void Code()
        {
            //var message = Console.ReadLine();
            var message = "chillout";
            var N = message.Length;

            var sqrt = Math.Sqrt(N);
            var row = (int) Math.Floor(sqrt);
            var col = (int) Math.Ceiling(sqrt);

            if (row*col < N)
            {
                row++;
            }
            int index = 0;
            for (int i = 0; i < col; i++)
            {
                for (int j = 0; j < row; j++)
                {
                    index = (j*col) + i;
                    if (index >= N)
                    {
                        continue;
                    }

                    Console.Write(message[index]);
                }



                Console.Write(" ");

            }


            Console.ReadLine();
        }
                
    }
}
