using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CodePractice.Codility
{
    public class ConvertRadix
    {

        public static void Implementation()
        {
            Console.WriteLine(new ConvertRadix().solution(17, 7));
        }
                

        public string solution(int V, int R)
        {
            string digits = "0123456789abcdefghijklmnopqrstuvwxyz";

            Stack<char> result = new Stack<char>();

            if (V == 0)
            {
                result.Push('0');
            }
            else
            {
                while (V > 0)
                {
                    var remainder = V % R;
                    result.Push(digits[(int)remainder]);
                    V = (V - remainder) / R;
                }
            }

            return new string(result.ToArray());
        }
    }
}
