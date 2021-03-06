﻿using CodePractice.Design.Tautology.Contracts;
using CodePractice.Design.Tautology.Model;
using CodePractice.Design.Tautology.Utilities;
using System;
using System.Collections.Generic;
using System.Diagnostics.Contracts;
using System.Linq;
using System.Text;

namespace CodePractice.Design.Tautology.Service
{
    public class PositionalTreeBuilder : IPositionalTreeBuilder
    {
        //I'm choosing data sharing using class variables, but if the logic grows beyond simple methods, they'll have to be polymorphed into classes 
        private Stack<PositionalStatement> storage;
        private CharEnumerator tokenEnumerator;
     
        private Dictionary<char, Action> builders;

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
            operand.IsNegated = !operand.IsNegated;
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
            Contract.Requires(!string.IsNullOrEmpty(postFixNotation), "Postfix notation cannot be null/empty");

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
