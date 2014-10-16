using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HackerRank.Algorithms
{
    public class MakeitAnagram
    {
        public static void Code()
        {
            var str1 = Console.ReadLine();
            var str2 = Console.ReadLine();

            var freq = new int[26];

            foreach (var c1 in str1)
            {
                freq[c1 - 97] += 1;
            }

            int num = 0;
            foreach (var c2 in str2)
            {                
                freq[c2 - 97] -= 1;
            }

            num = 0; 
            for (int i = 0; i < freq.Length; i++)
            {
                num += freq[i] < 0 ? freq[i]*-1 : freq[i];
            }

            Console.WriteLine(num);
        }
    }
}
