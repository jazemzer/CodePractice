using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CodePractice.BookingDotCom
{
    class ChainingNames
    {
        static void Code()
        {
            String[] input = { "Luis", "Hector", "Selena", "Emmanuel", "Amish" };

            Dictionary<char, List<int>> startingLetter = new Dictionary<char, List<int>>();
            Dictionary<char, List<int>> endingLetter = new Dictionary<char, List<int>>();


            for (int i = 0; i < input.Length; i++)
            {
                var temp = input[i].ToLower();
                var startChar = temp[0];
                var endChar = temp[temp.Length - 1];

                #region Create a adjacency list for starting characters
                if (startingLetter.ContainsKey(startChar))
                {
                    var list = startingLetter[startChar];
                    list.Add(i);
                    startingLetter[startChar] = list;
                }
                else
                {
                    startingLetter.Add(startChar, new List<int>() { i });
                }
                #endregion

                #region Create a adjacency list for ending characters
                if (endingLetter.ContainsKey(endChar))
                {
                    var list = endingLetter[endChar];
                    list.Add(i);
                    endingLetter[endChar] = list;
                }
                else
                {
                    endingLetter.Add(endChar, new List<int>() { i });
                }
                #endregion
            }

            #region Find if its a valid input

            var possibleStarts = new Dictionary<char, int>();
            var possibleEnds = new Dictionary<char, int>();


            for (int i = 97; i < 123; i++)
            {
                var startCount = 0;
                var endCount = 0;

                var currentAlphabet = Convert.ToChar(i);
                if (startingLetter.ContainsKey(currentAlphabet))
                {
                    startCount = startingLetter[currentAlphabet].Count;
                }

                if (endingLetter.ContainsKey(currentAlphabet))
                {
                    endCount = endingLetter[currentAlphabet].Count;
                }

                var diff = startCount - endCount;
                if (diff < 0)
                {
                    possibleEnds.Add(currentAlphabet, -diff);
                }
                else if (diff > 0)
                {
                    possibleStarts.Add(currentAlphabet, diff);
                }
            }

            var startSum = possibleStarts.Sum(x => x.Value);
            var endSum = possibleEnds.Sum(x => x.Value);


            if (startSum > 1 || endSum > 1)
            {
                Console.WriteLine("Invalid Input");
                return;
            }

            #endregion

            var startingChar = possibleStarts.Keys.First();



        }
    }
}
