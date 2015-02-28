using CodePractice.Design.Tautology.Contracts;
using CodePractice.Design.Tautology.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CodePractice.Design.Tautology
{
    public class OptimizedPropositionalEngine : IPropositionalEngine
    {
        private IExpressionConvertor convertor;

        //Will be replaced with DI 
        public OptimizedPropositionalEngine()
            : this(new ShuntingYardConvertor())
        {

        }

        public OptimizedPropositionalEngine(IExpressionConvertor convertor)
        {
            this.convertor = convertor;
        }



        public bool CheckTautology(string positionalStatement)
        {
            //Brute force way
            //return CheckTautology_BruteForce(positionalStatement);

            //Optimized way
            var postFixNotation = convertor.ConvertInfixToPostFix(positionalStatement);
            var statementTree = ConstructParserTree(postFixNotation);
            RecursiveDescent(ref statementTree);
            return statementTree.PositionalVariable == '1' ? true : false;
        }

        private void RecursiveDescent(ref PositionalStatement statement)
        {
            //End condition
            if (statement.Operator == '\0')
            {
                return;
            }

            var left = statement.Left;
            var right = statement.Right;

            if (left != null)
                RecursiveDescent(ref  left);

            if (right != null)
                RecursiveDescent(ref right);


            //TODO: This is just to showcase potential. Will have to strategize the switch statement to isolate responsibilities
            switch (statement.Operator)
            {
                case '&':
                    {
                        //Example: a & a , !a & !a
                        if (left.ToString() == right.ToString())
                        {
                            statement = left;
                        }
                        else if (right.PositionalVariable == '1')       // a & True
                        {
                            statement = left;
                        }
                        else if (left.PositionalVariable == '1')        // True & a
                        {
                            statement = right;
                        }
                        else if (left.PositionalVariable == '0'
                            || right.PositionalVariable == '0')       // a & False, False & a
                        {
                            statement = new PositionalStatement() { PositionalVariable = '0' };
                        }

                        break;
                    }
                case '|':
                    {
                        if (left.PositionalVariable == right.PositionalVariable)
                        {
                            //Example: b | b , !b | !b
                            if (left.IsNegated == right.IsNegated)
                            {
                                statement = left;
                            }
                            else
                            {
                                //Example: !b | b 
                                statement = new PositionalStatement() { PositionalVariable = '1'};
                            }
                        }
                        else if (right.PositionalVariable == '0')       // a | False
                        {
                            statement = left;
                        }
                        else if (left.PositionalVariable == '0')        // False |  a
                        {
                            statement = right;
                        }
                        else if (right.PositionalVariable == '1'
                            || left.PositionalVariable == '1')      // a | True, True | b
                        {
                            statement = new PositionalStatement() { PositionalVariable = '1' };
                        }

                        break;
                    }
            }



        }

        private PositionalStatement ConstructParserTree(string postFixNotation)
        {
            var temp = new Stack<PositionalStatement>();
            PositionalStatement operand = null;
            foreach (var character in postFixNotation)
            {
                if (Char.IsLetter(character))
                {
                    operand = new PositionalStatement();
                    operand.PositionalVariable = character;

                    temp.Push(operand);
                }
                else
                {
                    switch (character)
                    {
                        case '!':
                            {
                                operand = temp.Pop();
                                operand.IsNegated = true;
                                temp.Push(operand);
                                break;
                            }
                        case '|':
                        case '&':
                            {
                                operand = new PositionalStatement();
                                operand.Right = temp.Pop();
                                operand.Left = temp.Pop();
                                operand.Operator = character;
                                temp.Push(operand);
                                break;
                            }
                    }

                }
            }
            return temp.Pop();
        }



    }
}