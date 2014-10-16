using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HackerRank.Algorithms
{
    public class CountingSort3
    {

        public static void Code()
        {
            int N = Convert.ToInt32(Console.ReadLine());
            var inputKeys = new int[N];
            var inputValues = new string[N];

            for(int i = 0; i <N; i++)
            {
                var KvPair = Console.ReadLine().Split(' ');
                inputKeys[i] = Convert.ToInt32(KvPair[0]);
                inputValues[i] = KvPair[1];
            }


            var freq = new int[100];

            foreach (var item in inputKeys)
            {
                freq[item] += 1;
            }

            for(int i = 1; i < freq.Length; i++)
            {
                freq[i] += freq[i-1];
            }

            for (int i = 0; i < freq.Length; i++ )
            {
                Console.Write(freq[i] + " ");
            }
            Console.WriteLine();

            Console.ReadLine();
        }
                
    }
}
