using CodePractice.Design.Tautology.Contracts;
using CodePractice.Design.Tautology.Model;
using CodePractice.Design.Tautology.Utilities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CodePractice.Design.Tautology.Service
{
   public class LogicalOrOperator : ITautologyOperator
    {
       public void AttemptToSimplify(IPositionalStatement statement)
       {
           //Have Replaced nested condition with guard classes

           var left = statement.Left;
           var right = statement.Right;

           // b | b , !b | !b
           var bothSidesAlike = (left.ToString() == right.ToString() && left.IsNegated == right.IsNegated);

           // !b | b, b | !b
           var sidesComplementing = (left.ToString() == right.ToString() && left.IsNegated != right.IsNegated);

           // a | False 
           var rightSideFalsed = right.PositionalVariable == Constants.PositionalFalse;

           // False | b
           var leftSideFalsed = left.PositionalVariable == Constants.PositionalFalse;

           // a | True, True | b
           var anySideTrued = (right.PositionalVariable == Constants.PositionalTrue
               || left.PositionalVariable == Constants.PositionalTrue);




           if (bothSidesAlike || rightSideFalsed)
               statement.CopyFrom(left);

           if (sidesComplementing || anySideTrued)
               statement.CopyFrom(new PositionalStatement() { PositionalVariable = Constants.PositionalTrue });

           if (leftSideFalsed)
               statement.CopyFrom(right);

       }
    }
}
