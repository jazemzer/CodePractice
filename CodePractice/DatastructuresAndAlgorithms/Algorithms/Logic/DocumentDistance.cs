using System;
using System.Collections.Generic;
using System.Data.SqlTypes;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;

namespace CodePractice.DatastructuresAndAlgorithms.Algorithms.Logic
{
    public class DocumentDistance
    {
        public static string MakeGETRequest(string url)
        {
            var req = HttpWebRequest.Create(url);
            req.Method = "GET";
            string xmlResponse = string.Empty;
            try
            {
                using (HttpWebResponse resp = req.GetResponse() as HttpWebResponse)
                {
                    Encoding enc = System.Text.Encoding.GetEncoding(1252);
                    using (StreamReader loResponseStream = new StreamReader(resp.GetResponseStream(), enc))
                    {
                        xmlResponse = loResponseStream.ReadToEnd();
                    }
                }

                return xmlResponse;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }

            return null;
        }

        public static void Implementation()
        {
            string resp = MakeGETRequest("http://localhost:53169/cdm/parse");
            var program = new DocumentDistance();
            //var first = program.GetWords("108211458 Ascorbic Acid 500mg/5ml Syrup");
            var first = @"Acetaminophen 1605";
            var second = @"Acetaminophen Elixir 160 MG/5ML";

            var firstFrequencies = program.ComputeFrequency(first);
            var secondFrequencies = program.ComputeFrequency(second);

            var distance = program.ComputeDistance(firstFrequencies, secondFrequencies);

            Console.WriteLine("The distance is: {0}", distance);

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
            return (numerator / denominator);
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
