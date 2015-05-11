using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CodePractice.StringManipulation
{
    class PatternMatchingRipper
    {

        public static void Implementation()
        {
            var dictionary = new List<string> { "cow", "car", "cat", "can" };
            var counts = new int[dictionary.Count];

            const string Input = "ccss3rgowcarsdcarcansasfcow";
            var wordCount = 0;
            var i = 0;
            var foundWords = new List<string>();

            while (i < Input.Length)
            {
                for (var j = 0; j < dictionary.Count; j++)
                {
                    if (counts[j] == dictionary[j].Count())
                    {
                        wordCount++;
                        counts[j] = 0;
                        foundWords.Add(dictionary[j]);

                        continue;
                    }

                    if (dictionary[j].ElementAt(counts[j]) == Input.ElementAt(i))
                    {
                        counts[j] = counts[j] + 1;
                    }
                    else if (dictionary[j].ElementAt(0) == Input.ElementAt(i))
                    {
                        counts[j] = 1;
                    }
                    else
                    {
                        counts[j] = 0;
                    }
                }

                i++;
            }

            for (var j = 0; j < counts.Count(); j++)
            {
                if (counts[j] == dictionary[j].Length)
                {
                    wordCount++;
                    foundWords.Add(dictionary[j]);
                }
            }

            Console.WriteLine(wordCount);

            foreach (var item in foundWords)
            {
                Console.WriteLine(item);
            }

        }
                
    }
}
