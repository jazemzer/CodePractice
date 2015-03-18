using CodePractice.Design.Tautology.Contracts;
using CodePractice.Design.Tautology.Utilities;
using System;
using System.Collections.Generic;
using System.Diagnostics.Contracts;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;

namespace CodePractice.Design.Tautology.Utilities
{
    /// <summary>
    /// The syntax used can be summarized in EBNF as below
    ///         Expression      = Binary
    ///         Binary          = Unary ("|"|"&") Unary 
    ///         Unary           = ("!") Primary 
    ///         Primary         = Variable | "(" Expression ")" 
    /// </summary>
    public class EBNFConvertor : IExpressionConvertor
    {

        public string ConvertInfixToPostFix(string inFix)
        {
            Contract.Requires(inFix != null, "Infix notation cannot be null");
            
            //string syntax = @"([a-z]+|[A-Z]+|[!|&()])";
            //var tokens = Regex.Matches(input, syntax, RegexOptions.Compiled)
            //    .Cast<Match>().Select(t => t.Groups[1].Value).GetEnumerator();

            //Could have used Regex to remove unwanted characters, but chose string Replace for simplicity
            inFix = (inFix.Replace(" ", string.Empty));

            _tokens = inFix.GetTokenEnumerator();

            _reversePolishNotation = new StringBuilder();

            GetNextToken();

            ParseExpression();
            return _reversePolishNotation.ToString();
        }


        private TokenEnumerator _tokens;    //Wrote a custom Enumerator as CharEnumerator was throwing exceptions at out of bounds
        private StringBuilder _reversePolishNotation;
        
        private bool GetNextToken()
        {
            return _tokens.MoveNext();
        }

        private char CurrentToken
        {
            get { return _tokens.Current; }
        }

        private bool IsLetter
        {
            get { return char.IsLetter(CurrentToken); }
        }

        private char CheckCurrentOperatorAndFetchNextToken(params char[] operators)
        {
            var currentOperator = operators.Contains(CurrentToken) ? CurrentToken : Constants.DefaultToken;
            
            if(currentOperator != Constants.DefaultToken)
                GetNextToken();

            return currentOperator;
        }

        private void ParseExpression()
        {
            ParseLogical();            
        }

        private void ParseLogical()
        {
            ParseBinary(ParseNegation, Constants.LogicalAnd, Constants.LogicalOr);
        }

        private void ParseNegation()
        {
            ParseUnary(ParsePrimary, Constants.UnaryNot);
        }
        

        private void ParseUnary(Action parseFunc, params char[] operators)
        {
            char currentOperator = CheckCurrentOperatorAndFetchNextToken(operators);
            parseFunc();
            if (currentOperator != Constants.DefaultToken)
            {
                _reversePolishNotation.Append(currentOperator);
            }
        }

        private void ParseBinary(Action parseFunc, params char[] operators)
        {
            parseFunc();
            char currentOperator;
            while ((currentOperator = CheckCurrentOperatorAndFetchNextToken(operators)) != Constants.DefaultToken)
            {
                parseFunc();
                _reversePolishNotation.Append(currentOperator);
            }
        }

        private void ParsePrimary()
        {
            if (IsLetter)
                ParseLetter();
            else
                ParseNesting();
        }

        private void ParseLetter()
        {
            _reversePolishNotation.Append(CurrentToken);
            GetNextToken();
        }

        private void ParseNesting()
        {
            GetNextToken();
            ParseExpression();
            GetNextToken();
        }
    }
}
