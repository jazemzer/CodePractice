using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HackerRank.Algorithms
{
    public class RunTimeOfAlgorithms
    {

        public static void Code()
        {
           // int N = Convert.ToInt32(Console.ReadLine());
            //var input = Array.ConvertAll(Console.ReadLine().Split(' '), Convert.ToInt32);

            var input = new int[] { 2, 1, 3, 1, 2 };
            int N = 5;
            int temp = -1, j = -1;
            int counter = 0;
            for (int i = 1; i < input.Length; i++)
            {
                temp = input[i];
                j = i - 1;
                while (j >= 0
                    && temp < input[j])
                {
                    input[j + 1] = input[j];
                    j--;
                    counter++;
                }
                input[j + 1] = temp;
            }
            Console.WriteLine(counter);

            Console.ReadLine();
        }
                
    }
}
