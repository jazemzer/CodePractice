using CodePractice.Design.Tautology.Contracts;
using System;
using System.Collections.Generic;
using System.Diagnostics.Contracts;
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

        public override string ToString()
        {
            if (Left != null && Right != null)
            {
                return Left.ToString() + Operator + Right.ToString();
            }
            return PositionalVariable.ToString();
        }

        public void CopyFrom(IPositionalStatement statement)
        {
            Contract.Requires(statement != null, "Positional Statement to be copied from cannot be null");

            this.Left = statement.Left;
            this.Right = statement.Right;
            this.IsNegated = statement.IsNegated;
            this.PositionalVariable = statement.PositionalVariable;
            this.Operator = statement.Operator;
        }
    }
}
