using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CodePractice.Utilities
{
    public class CosineSimilarity    
    {

        public string[] GetWords(string input)
        {
            var words = new List<string>();
            var characters = new List<char>();

            //var input = new StreamReader(filename).ReadToEnd();
            if (!string.IsNullOrEmpty(input))
            {
                var seperators = Constants.SEPARATOR;
                //seperators.AddRange(Environment.NewLine);
                foreach (var word in input.Split(seperators.ToArray(), StringSplitOptions.RemoveEmptyEntries))
                {
                    foreach (var character in word.ToCharArray())
                    {
                        if (char.IsLetter(character)) characters.Add(character);
                    }

                    if (characters.Count > 0)
                    {
                        words.Add(new string(characters.ToArray())); // string.Join("", characters).ToLowerInvariant());
                        characters.Clear();
                    }
                }
            }

            return words.ToArray();
        }

        public double ComputeDistance(Dictionary<string, int> first, Dictionary<string, int> second)
        {
            var numerator = ComputeInnerProduct(first, second);

            var denominator = Math.Sqrt(ComputeInnerProduct(first, first) * ComputeInnerProduct(second, second));

            if (denominator == 0.0)
                return -1;
            return numerator / denominator;
        }

        public int ComputeInnerProduct(Dictionary<string, int> first, Dictionary<string, int> second)
        {
            var sum = 0;
            foreach (var key in first.Keys)
            {
                if (second.ContainsKey(key)) sum += first[key] * second[key];
            }

            return sum;
        }

        public Dictionary<string, int> ComputeFrequency(string text)
        {

            var result = new Dictionary<string, int>();

            string[] input = GetWords(text.ToLowerInvariant());

            for (var i = 0; i < input.Length; i++)
            {
                if (result.ContainsKey(input[i]))
                {
                    result[input[i]]++;
                }
                else
                {
                    result.Add(input[i], 1);
                }
            }

            return result;
        }
    }
}
