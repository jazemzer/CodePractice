using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CodePractice.DatastructuresAndAlgorithms.Problems.Stack
{
    class BalancedBracesChecker
    {
        public static void Code()
        {
            #region Balanced Parameters Checker

            string sampleInput = "(()([{}]{}))"; //Valid Input
            Console.Write(AreAllParmetersBalanced(sampleInput));
            #endregion
        }
        private static bool AreAllParmetersBalanced(string input)
        {
            bool balanced = true;

            Stack<char> myStack = new Stack<char>();

            string possibleOpeningChars = "({[";
            string possibleClosingChars = ")}]";

            foreach (var character in input)
            {
                int charIndex = possibleClosingChars.IndexOf(character);
                if (charIndex > -1)
                {
                    if (myStack.Count == 0) //If Empty, avoid throwing exception while popping
                    {
                        balanced = false;
                        break;
                    }
                    else
                    {
                        var findOpening = myStack.Pop();
                        if (possibleOpeningChars[charIndex] != findOpening)
                        {
                            balanced = false;
                            break;
                        }
                    }
                }
                else
                {
                    myStack.Push(character);
                }
            }
            return balanced && myStack.Count == 0 ? true : false;

        }
    }
}
