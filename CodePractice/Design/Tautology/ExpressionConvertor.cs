using CodePractice.Design.Tautology.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CodePractice.Design.Tautology
{
    public class ExpressionConvertor : IExpressionConvertor
    {
        public string ConvertInfixToPostFix(string inFixNotation)
        {
            StringBuilder postFixNotation = new StringBuilder();
            char stackTop;
            Stack<char> operatorStack = new Stack<char>();
            foreach (char character in inFixNotation.ToCharArray())
            {
                if (Char.IsWhiteSpace(character))
                {
                    // Given - Whitespace can appear anywhere in the statement.
                    // Ignore white spaces
                    continue;
                }
                else if (Char.IsLetter(character))
                {
                    // Given - All propositional variables will be single letter alphabets
                    //Operands go directly to the output
                    postFixNotation.Append(character);
                }
                else if (character == '(')
                {
                    // Given - You can expect sentences to be well bracketed in case of binary operations
                    //Push into operator stack to mark boundary
                    operatorStack.Push(character);
                }
                else if (character == ')')
                {
                    // Closing marks logical end. So pop and append every operator until you get an opening parenthesis
                    stackTop = operatorStack.Pop();
                    while (stackTop != '(')
                    {
                        postFixNotation.Append(stackTop);
                        stackTop = operatorStack.Pop();
                    }
                }
                else
                {
                    // Pop all operators that have higher or equal precedence than the one at hand

                    while (operatorStack.Any()
                        && CheckPrecedence(operatorStack.Peek(), character))
                    {
                        postFixNotation.Append(operatorStack.Pop());
                    }

                    // Push the new operator to stack when 
                    //      1. if Stack is empty 
                    //      2. When the operator has precedence than the one on stack

                    operatorStack.Push(character);
                }
            }

            // At the end of infix string, move all operators to output
            while (operatorStack.Count > 0)
            {
                stackTop = operatorStack.Pop();
                postFixNotation.Append(stackTop);
            }
            return postFixNotation.ToString();
        }

        private bool CheckPrecedence(char topCharacter, char incoming)
        {
            //Operator precedence reference - 
            //    http://introcs.cs.princeton.edu/java/11precedence/
            //    https://msdn.microsoft.com/en-us/library/aa691323(v=vs.71).aspx

            string possibleOperators = "(&|!";

            // Deliberately marking '(' with less preference so that it doesnt gets popped out by other operators but only when ')' is encountered
            int[] precedence = { 0, 1, 2, 3 };

            int i, j;

            i = possibleOperators.IndexOf(topCharacter);
            j = possibleOperators.IndexOf(incoming);

            // Operators of equal precendence are broken ties from left to right
            return (precedence[i] >= precedence[j]) ? true : false;
        }
    }
}
