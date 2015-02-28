using CodePractice.Design.Tautology.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CodePractice.Design.Tautology
{
        public class BruteForcePropositionalEngine : IPropositionalEngine 
    {
        private IExpressionConvertor convertor;
        private IExpressionEvaluator evaluator;

        //Will be replaced with DI 
        public BruteForcePropositionalEngine(): this(new ShuntingYardConvertor(), new ExpressionEvaluator())
        {

        }

        public BruteForcePropositionalEngine(IExpressionConvertor convertor, IExpressionEvaluator evaluator)
        {
            this.convertor = convertor;
            this.evaluator = evaluator;
        }


        public bool CheckTautology(string positionalStatement)
        {
            //Assumption:
            //    * The statement ONLY contains valid characters a-z, (,),&,|,! and spaces
            //    * The variables are single character 
            //    * Not including any validation logic as problem clearly says to assume 'All statements are synctactically valid'

            var postFixNotation = convertor.ConvertInfixToPostFix(positionalStatement);

            var positionalVariables = FindVariablesInStatement(positionalStatement);

            //Construct Truth table to verify if the statement is a tautology
            // Maximum combinations possible is 2 ^ 10 (maximum of 10 variables) which is well within Int range
            var twoPowerN = (int)Math.Pow(2, positionalVariables.Count);

            var result = true;

            // Its a bit of brute force but if the number of variables were high, we can introduce potential data parallelism with TPL Parallel.For            
            //  Other option could be to attempt caching common tautological/non-tautological patterns and thereby arrive at reject decision fairly quicker
            for (int i = 0; i < twoPowerN; i++)
            {
                var temp = i;
                var tempNotation = postFixNotation;
                foreach (var posVariable in positionalVariables)
                {
                    // We are using bit positions to construct the truth table variable combinations
                    var replaceWith = (temp & 1) == 0 ? '0' : '1';
                    tempNotation = tempNotation.Replace(posVariable, replaceWith);
                    temp = temp >> 1;
                }

                if (!evaluator.EvaluatePostFixExpression(tempNotation))
                {
                    result = false;
                    break;
                }
            }


            return result;


        }

        private HashSet<char> FindVariablesInStatement(string positionalStatement)
        {
            var result = new HashSet<char>();

            foreach (var character in positionalStatement)
            {
                if (Char.IsLetter(character))
                    result.Add(character);
            }

            return result;
        }

    }
}