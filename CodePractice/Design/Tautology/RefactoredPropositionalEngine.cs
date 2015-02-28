using CodePractice.Design.Tautology.Contracts;
using CodePractice.Design.Tautology.Model;
using CodePractice.Design.Tautology.Service;
using CodePractice.Design.Tautology.Utilities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CodePractice.Design.Tautology
{
    public class RefactoredPropositionalEngine : IPropositionalEngine
    {
        private IExpressionConvertor convertor;
        private IPositionalTreeBuilder treeBuilder;
        //Will be replaced with DI 
        public RefactoredPropositionalEngine()
            : this(new EBNFConvertor(), new PositionalTreeBuilder())
        {

        }

        private Dictionary<char, ITautologyOperator> solvers = null;
        public RefactoredPropositionalEngine(IExpressionConvertor convertor, IPositionalTreeBuilder treeBuilder)
        {
            this.convertor = convertor;
            this.treeBuilder = treeBuilder;

            //  This could be moved to Factory implementation when needed. 
            //  We could have also had Object Types and used Activator.CreateInstance with reflection
            solvers = new Dictionary<char, ITautologyOperator>();
            solvers.Add(Constants.LogicalAnd, new LogicalAndOperator());
            solvers.Add(Constants.LogicalOr, new LogicalOrOperator());
        }


        public bool CheckTautology(string positionalStatement)
        {
            var postFixNotation = convertor.ConvertInfixToPostFix(positionalStatement);
            var statementTree = treeBuilder.ConstructTreeFrom(postFixNotation);
            RecursiveDescent(statementTree);
            return statementTree.PositionalVariable == Constants.PositionalTrue ? true : false;
        }

        private void RecursiveDescent(IPositionalStatement statement)
        {
            //End condition
            if (statement.Operator == Constants.DefaultToken)
                return;

            var left = statement.Left;
            var right = statement.Right;

            if (left != null)
                RecursiveDescent( left);

            if (right != null)
                RecursiveDescent(right);

            // ContainsKey check is absent as the problem assumes synctactic validity
            solvers[statement.Operator].AttemptToSimplify(statement);

        }

        



    }
}
