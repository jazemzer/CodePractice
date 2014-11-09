using System;
using System.Collections.Generic;
using System.Data.SqlTypes;
using System.IO;
using System.Linq;
using System.Text;

namespace CodePractice.DatastructuresAndAlgorithms.Algorithms.Logic
{
    public class DocumentDistance
    {

        public static void Implementation()
        {
            var program = new DocumentDistance();
            //var first = program.GetWords("108211458 Ascorbic Acid 500mg/5ml Syrup");
            var first = @" Albuterol Hfa Inhalation Or    ";
            var second = @"Albuterol Sulfate HFA";

            var firstFrequencies = program.ComputeFrequency(first);
            var secondFrequencies = program.ComputeFrequency(second);

            var distance = program.ComputeDistance(firstFrequencies, secondFrequencies);

            Console.WriteLine("The distance is: {0}", distance);

            SqlDouble trial = distance;
        }

        public string[] GetWords(string input)
        {
            var words = new List<string>();
            var characters = new List<char>();

            //var input = new StreamReader(filename).ReadToEnd();
            var seperators = new List<char> { ' ', '/','*' };
            seperators.AddRange(Environment.NewLine);
            foreach (var word in input.Split(seperators.ToArray()))
            {
                foreach (var character in word.ToCharArray())
                {
                    if (char.IsLetter(character)) characters.Add(character);
                }

                if (characters.Count > 0)
                {
                    words.Add(string.Join("", characters).ToLowerInvariant());
                    characters.Clear();
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
            return Math.Acos(numerator / denominator);
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

            string[] input = GetWords(text);

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
