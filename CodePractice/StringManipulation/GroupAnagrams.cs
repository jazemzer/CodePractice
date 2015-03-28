using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

//pear
//amleth
//dormitory
//tinsel
//dirty room
//hamlet
//listen
//silent
//reap

namespace CodePractice.StringManipulation
{
    class GroupAnagrams
    {
        public static void Implementation()
        {
            var input = new List<string>();
            while (true)
            {
                var temp = Console.ReadLine();
                if (string.IsNullOrEmpty(temp))
                {
                    break;
                }

                input.Add(temp);
            }

            var anagrams = new Dictionary<string, List<string>>();

            foreach (var word in input)
            {
                var temp = word.Replace(" ", "").ToCharArray();
                Array.Sort(temp);

                var key = new String(temp);

                if (anagrams.ContainsKey(key))
                {
                    anagrams[key].Add(word);
                }
                else
                {
                    anagrams.Add(key, new List<string>() { word });
                }
            }

            var output = new List<string>();

            foreach (var kvPair in anagrams)
            {
                kvPair.Value.Sort();
                output.Add(String.Join(",", kvPair.Value));
            }

            output.Sort();

            foreach (var words in output)
            {
                Console.WriteLine(words);
            }


        }
                
    }
}
