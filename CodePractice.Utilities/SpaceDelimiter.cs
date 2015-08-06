using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CodePractice.Utilities
{
    class SpaceDelimiter
    {
        private int LENGTH_OF_LONGEST_TOKEN = 0;
        private Dictionary<string, double> WORD_COST = null;

        private string FindSpaces(string stringToDecipher)
        {
            string result = string.Empty;

            List<double> cost = new List<double>();
            cost.Add(0);

            Func<int, Tuple<double, int>> best_Match = new Func<int, Tuple<double, int>>((i) =>
            {
                int firstItem = Math.Max(0, i - LENGTH_OF_LONGEST_TOKEN);

                var candidates = cost.GetRange(firstItem, i - firstItem);
                candidates.Reverse();

                List<Tuple<double, int>> matchCostLengthPairList = new List<Tuple<double, int>>();
                foreach (var iter in candidates.Select((Value, Index) => new { Value, Index }))
                {
                    int startPos = i - iter.Index - 1;
                    string subStringToDecipher =
                        new string(stringToDecipher.ToList().GetRange(startPos, i - startPos).ToArray());
                    double matchCost = double.PositiveInfinity;

                    if (WORD_COST.ContainsKey(subStringToDecipher))
                    {
                        matchCost = iter.Value + WORD_COST[subStringToDecipher];
                    }
                    matchCostLengthPairList.Add(Tuple.Create(matchCost, iter.Index + 1));
                }

                return matchCostLengthPairList.Min();

            });


            foreach (int i in Enumerable.Range(1, stringToDecipher.Length))
            {
                Tuple<double, int> matchCostLengthPair = best_Match(i);
                cost.Add(matchCostLengthPair.Item1);
            }

            List<string> splitOutput = new List<string>();
            int Loopindex = stringToDecipher.Length;

            while (Loopindex > 0)
            {
                Tuple<double, int> matchCostLengthPair = best_Match(Loopindex);
                int startpos = Loopindex - matchCostLengthPair.Item2;
                splitOutput.Add(
                    new string(stringToDecipher.ToList().GetRange(startpos, Loopindex - startpos).ToArray()));
                Loopindex = Loopindex - matchCostLengthPair.Item2;

            }

            splitOutput.Reverse();

            var inputLength = stringToDecipher.Length;
            var noOfWords = splitOutput.Count();

            if (noOfWords <= inputLength / 2) // 4 is random decider
            {
                result = string.Join(" ", splitOutput);
            }

            //TODO: Implement a trie and find out words

            return result;

        }

        private List<TokenCorrection> FindAbbreviations(string word, List<TokenCorrection> tokens)
        {
            var wordList = new List<TokenCorrection>();

            foreach (var token in tokens)
            {
                var filteredWord = token.CorrectedText;
                int abbrvLen = word.Length - 1;
                int filterLen = filteredWord.Length - 1;
                int i = 0;
                int j = 0;
                bool foundWord = false;
                bool reachEnd = false;

                do
                {
                    if (word[i] == filteredWord[j])
                    {
                        i++;
                    }
                    j++;

                    if (i > abbrvLen)
                    {
                        foundWord = true;
                    }
                    if (j > filterLen)
                    {
                        reachEnd = true;
                    }
                } while (!foundWord && !reachEnd);

                if (foundWord)
                {
                    wordList.Add(token);
                }
            }

            return wordList;
        }

        internal class TokenCorrection
        {
            public string CorrectedText { get; set; }
            public double Score { get; set; }
        }

    }
}
