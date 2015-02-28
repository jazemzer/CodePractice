using CodePractice.Design.Tautology.Contracts;
using CodePractice.Design.Tautology.Model;
using CodePractice.Design.Tautology.Utilities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CodePractice.Design.Tautology.Service
{
    public class PositionalTreeBuilder : IPositionalTreeBuilder
    {
        private Stack<PositionalStatement> storage;
     
        private Dictionary<char, Action> builders;
        private CharEnumerator tokenEnumerator;

        public PositionalTreeBuilder()
        {
            PrepareBuilderComponents();
        }

        private void PrepareBuilderComponents()
        {
            builders = new Dictionary<char, Action>();

            // For letters 
            for(char i = 'A'; i <= 'Z'; i++)
            {
                builders.Add(i, LetterBuilder);
            }
            for (char i = 'a'; i <= 'z'; i++)
            {
                builders.Add(i, LetterBuilder);
            }

            builders.Add(Constants.UnaryNot, NotBuilder);
            builders.Add(Constants.LogicalAnd, AndOrBuilder);
            builders.Add(Constants.LogicalOr, AndOrBuilder);

        }

        private void LetterBuilder()
        {
            char character = tokenEnumerator.Current;
            var operand = new PositionalStatement();
            operand.PositionalVariable = character;
            storage.Push(operand);
        }

        private void NotBuilder()
        {
            var operand = storage.Pop();
            operand.IsNegated = true;
            storage.Push(operand);
        }

        private void AndOrBuilder()
        {
            char character = tokenEnumerator.Current;
            var operand = new PositionalStatement();
            operand.Right = storage.Pop();
            operand.Left = storage.Pop();
            operand.Operator = character;
            storage.Push(operand);
        }

        public IPositionalStatement ConstructTreeFrom(string postFixNotation)
        {
            storage = new Stack<PositionalStatement>();
            tokenEnumerator = postFixNotation.GetEnumerator();

            while(tokenEnumerator.MoveNext())
            {
                builders[tokenEnumerator.Current].Invoke();
            }
            return storage.Pop();
        }
    }
}
