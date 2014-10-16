using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HackerRank.Algorithms
{
    class CountingSort4
    {

        public static void Code()
        {
            int N = Convert.ToInt32(Console.ReadLine());
            var inputKeys = new int[N];
            var inputValues = new string[N];

            var itemstoSkip = N / 2;

            for (int i = 0; i < N; i++)
            {
                var KvPair = Console.ReadLine().Split(' ');
                inputKeys[i] = Convert.ToInt32(KvPair[0]);
                if (itemstoSkip > 0)
                {
                    inputValues[i] = "-";
                    itemstoSkip--;
                }
                else
                {
                    inputValues[i] = KvPair[1];
                }
            }


            var freq = new StringBuilder[100];
            for (int i = 0; i < 100; i++)
            {
                freq[i] = new StringBuilder();
            }
            for (int i = 0; i < N; i++)
            {
                freq[inputKeys[i]].Append(inputValues[i]).Append(" ");
            }

            StringBuilder sb = new StringBuilder();

            foreach (var s in freq)
            {
                sb.Append(s);
            }

            Console.WriteLine(sb.ToString());

            Console.ReadLine();
        }
                
    }
}
