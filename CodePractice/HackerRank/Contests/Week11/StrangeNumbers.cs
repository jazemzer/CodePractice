using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HackerRank.Contests.Week11
{
    public class StrangeNumbers
    {

        private static int FindExactOrNext(List<long> strangeNumbers, long numberToFind)
        {
            int low = 0, middle = -1;
            int high = strangeNumbers.Count - 1;

            while (low <= high)
            {
                middle = low + ((high - low) >> 1);
                var result = numberToFind.CompareTo(strangeNumbers[middle]);
                if (result == 0)
                {
                    return middle;
                }
                else if (result < 0)
                {
                    high = middle - 1;
                }
                else
                {
                    low = middle + 1;
                }
            }
            return middle;
        }

        public static void Code()
        {
            

            var output = new List<long>();

            //Adding non-negative numbers
            for (int i = 0; i < 10; i++)
            {
                output.Add(i);
            }
            

            for (int digit = 2; digit <= 18; digit++)
            {
                var start = (long) Math.Pow(10, digit - 1);
                var boundary =(long) Math.Pow(10, digit);
                var firstNumber = start/(digit);

                var strangeIndex = FindExactOrNext(output, firstNumber);

                while (strangeIndex < output.Count  && output[strangeIndex] < firstNumber)
                {
                    strangeIndex++;
                }
                while (true)
                {
                    var newNumber = output[strangeIndex] * digit;
                    if (newNumber < boundary)
                    {
                        output.Add(newNumber);
                        strangeIndex++;
                    }
                    else
                    {
                        break;
                    }
                }
            }

            //var file = File.CreateText("D:\\test1.txt");
            //file.Write(String.Join("\r\n", output));
            //file.Close();

            //output.Reverse();
            //foreach (var l in output)
            //{
            //    var digits = l.ToString().Length;
            //    var quotient = l/digits;                
            //    if (!output.Contains(l/digits))
            //    {
            //        Console.WriteLine(l);
            //    }
            //}

            //var lastNumber = (long)Math.Pow(10, 18);                        
            //var index = FindExactOrNext(output, lastNumber/19);
            //if (output[index]*19 == lastNumber)
            //{
            //    output.Add(lastNumber);
            //}         

            int T = Convert.ToInt32(Console.ReadLine());
            while (T > 0)
            {
                T--;
                var LandR = Console.ReadLine().Split(' ');
                var L = Convert.ToInt64(LandR[0]);
                var R = Convert.ToInt64(LandR[1]);

                var startIndex = FindExactOrNext(output, L);
                var counter = 0;
                while (output[startIndex] < L)
                {
                    startIndex++;
                }

                for (int i = startIndex; i < output.Count; i++)
                {
                    if(output[i] <= R)
                    {
                        counter++;
                    }
                }
              

                Console.WriteLine(counter);
            }

            Console.ReadLine();
        }
                
    }
}
