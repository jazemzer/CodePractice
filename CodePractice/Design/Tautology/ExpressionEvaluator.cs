using CodePractice.Design.Tautology.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CodePractice.Design.Tautology
{
    public class ExpressionEvaluator : IExpressionEvaluator
    {
        public bool EvaluatePostFixExpression(string postFixNotation)
        {
            var temp = new Stack<bool>();
            foreach (var character in postFixNotation)
            {
                if (Char.IsNumber(character))
                {
                    // Converting 1's to True and 0's to False
                    temp.Push(character == '1' ? true : false);
                }
                else
                {
                    //Not having any sophisticated patterns as the number of operators is less
                    switch (character)
                    {
                        case '!':
                            {
                                temp.Push(!temp.Pop());
                                break;
                            }
                        case '|':
                            {
                                temp.Push(temp.Pop() | temp.Pop());
                                break;
                            }
                        case '&':
                            {
                                temp.Push(temp.Pop() & temp.Pop());
                                break;
                            }
                    }

                }
            }
            return temp.Pop();
        }
    }
}
