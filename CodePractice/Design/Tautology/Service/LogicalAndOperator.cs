using CodePractice.Design.Tautology.Contracts;
using CodePractice.Design.Tautology.Model;
using CodePractice.Design.Tautology.Utilities;
using System;
using System.Collections.Generic;
using System.Diagnostics.Contracts;
using System.Linq;
using System.Text;

namespace CodePractice.Design.Tautology.Service
{
    public class LogicalAndOperator : ITautologyOperator
    {
        public void AttemptToSimplify(IPositionalStatement statement)
        {
            Contract.Requires(statement != null, "Positional Statement cannot be null");

            var left = statement.Left;
            var right = statement.Right;

            // a & a , !a & !a
            var bothSidesAlike = (left.ToString() == right.ToString() && left.IsNegated == right.IsNegated);

            // !b & b, b & !b
            var sidesComplementing = (left.ToString() == right.ToString() && left.IsNegated != right.IsNegated);

            // a & True
            var rightSideTrued = right.PositionalVariable == Constants.PositionalTrue;

            // True & a
            var leftSideTrued = left.PositionalVariable == Constants.PositionalTrue;

            // a & False, False & a
            var anySideFalsed = (left.PositionalVariable == Constants.PositionalFalse
                || right.PositionalVariable == Constants.PositionalFalse);





            if (bothSidesAlike || rightSideTrued)
                statement.CopyFrom(left); 
            
            if (leftSideTrued)        
                statement.CopyFrom(right);
            
            if (anySideFalsed || sidesComplementing)       
                statement.CopyFrom(new PositionalStatement() { PositionalVariable = Constants.PositionalFalse, IsNegated = statement.IsNegated });

        }
    }
}
