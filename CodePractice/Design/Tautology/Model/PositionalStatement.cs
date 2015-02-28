using CodePractice.Design.Tautology.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CodePractice.Design.Tautology.Model
{
    public class PositionalStatement : IPositionalStatement
    {
        public IPositionalStatement Left { get; set; }
        public IPositionalStatement Right { get; set; }

        public bool IsNegated { get; set; }
        public char PositionalVariable { get; set; }
        public char Operator { get; set; }

        public string ReducedEquivalent { get; set; }

        public override string ToString()
        {
            if (Left != null && Right != null)
            {
                return Left.ToString() + Operator + Right.ToString();
            }
            return IsNegated ? "!" + PositionalVariable.ToString() : PositionalVariable.ToString();
        }

        public void CopyFrom(IPositionalStatement statement)
        {
            this.Left = statement.Left;
            this.Right = statement.Right;
            this.IsNegated = statement.IsNegated;
            this.PositionalVariable = statement.PositionalVariable;
            this.Operator = statement.Operator;
            this.ReducedEquivalent = statement.ReducedEquivalent;
        }
    }
}
