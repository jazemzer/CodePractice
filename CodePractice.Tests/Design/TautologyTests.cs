﻿using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using CodePractice.Design.Tautology;
using CodePractice.Design.Tautology.Service;
using CodePractice.Design.Tautology.Utilities;

namespace CodePractice.Tests.Design
{
    [TestClass]
    public class TautologyTests
    {
        [TestMethod]
        public void Test_Shunt_Yard_PostFix_Conversion()
        {
            var convertor = new ShuntingYardConvertor();
            string result;

            result = convertor.ConvertInfixToPostFix("!a&b");
            Assert.AreEqual(result, "a!b&");

            result = convertor.ConvertInfixToPostFix(" a ");
            Assert.AreEqual(result, "a");

            result = convertor.ConvertInfixToPostFix(" a & b");
            Assert.AreEqual(result, "ab&");

            result = convertor.ConvertInfixToPostFix("a & (b | c)");
            Assert.AreEqual(result, "abc|&");

            result = convertor.ConvertInfixToPostFix("!a & !b");
            Assert.AreEqual(result, "a!b!&");

            result = convertor.ConvertInfixToPostFix(" a & !a");
            Assert.AreEqual(result, "aa!&");

            result = convertor.ConvertInfixToPostFix("( (a & (!b | b)) | (!a & (!b | b)) )");
            Assert.AreEqual(result, "ab!b|&a!b!b|&|");

            result = convertor.ConvertInfixToPostFix("(!a | (a & a))");
            Assert.AreEqual(result, "a!aa&|");

            result = convertor.ConvertInfixToPostFix("(!a | (b & !a))");
            Assert.AreEqual(result, "a!ba!&|");

            result = convertor.ConvertInfixToPostFix("(!a | a)");
            Assert.AreEqual(result, "a!a|");            


        }

        [TestMethod]
        public void Test_PostFix_Evaluation()
        {
            var evaluator = new ExpressionEvaluator();
            bool result;

            result = evaluator.EvaluatePostFixExpression("1!0&");
            Assert.AreEqual(result, false);
            result = evaluator.EvaluatePostFixExpression("0!0&");
            Assert.AreEqual(result, false);
            result = evaluator.EvaluatePostFixExpression("1!1&");
            Assert.AreEqual(result, false);
            result = evaluator.EvaluatePostFixExpression("0!1&");
            Assert.AreEqual(result, true);

            result = evaluator.EvaluatePostFixExpression("0");
            Assert.AreEqual(result, false);
            result = evaluator.EvaluatePostFixExpression("1");
            Assert.AreEqual(result, true);

            result = evaluator.EvaluatePostFixExpression("00&");
            Assert.AreEqual(result, false);
            result = evaluator.EvaluatePostFixExpression("01&"); 
            Assert.AreEqual(result, false);
            result = evaluator.EvaluatePostFixExpression("10&");
            Assert.AreEqual(result, false);
            result = evaluator.EvaluatePostFixExpression("11&");
            Assert.AreEqual(result, true);


            result = evaluator.EvaluatePostFixExpression("000|&");
            Assert.AreEqual(result, false);
            result = evaluator.EvaluatePostFixExpression("001|&");
            Assert.AreEqual(result, false);
            result = evaluator.EvaluatePostFixExpression("010|&");
            Assert.AreEqual(result, false);
            result = evaluator.EvaluatePostFixExpression("011|&");
            Assert.AreEqual(result, false);
            result = evaluator.EvaluatePostFixExpression("100|&");
            Assert.AreEqual(result, false);
            result = evaluator.EvaluatePostFixExpression("101|&");
            Assert.AreEqual(result, true);
            result = evaluator.EvaluatePostFixExpression("110|&");
            Assert.AreEqual(result, true);
            result = evaluator.EvaluatePostFixExpression("111|&");
            Assert.AreEqual(result, true);          


        }

        [TestMethod]
        public void Test_Tautology_BruteForce()
        {
            var verifier = new BruteForcePropositionalEngine();
            bool result;

            result = verifier.CheckTautology("!a&b");
            Assert.AreEqual(result, false);

            result = verifier.CheckTautology(" a ");
            Assert.AreEqual(result, false);

            result = verifier.CheckTautology(" a & b");
            Assert.AreEqual(result, false);

            result = verifier.CheckTautology("a & (b | c)");
            Assert.AreEqual(result, false);

            result = verifier.CheckTautology("!a & !b");
            Assert.AreEqual(result, false);

            result = verifier.CheckTautology("(!a | (b & !a))");
            Assert.AreEqual(result, false);

            result = verifier.CheckTautology(" a & !a");
            Assert.AreEqual(result, false);



            result = verifier.CheckTautology("( (a & (!b | b)) | (!a & (!b | b)) )");
            Assert.AreEqual(result, true);

            result = verifier.CheckTautology("(!a | (a & a))");
            Assert.AreEqual(result, true);

            result = verifier.CheckTautology("(!a | a)");
            Assert.AreEqual(result, true);


        }

        [TestMethod]
        public void Test_Tautology_Optimized()
        {
            var verifier = new OptimizedPropositionalEngine();
            bool result;

            result = verifier.CheckTautology("!a&b");
            Assert.AreEqual(result, false);

            result = verifier.CheckTautology(" a ");
            Assert.AreEqual(result, false);

            result = verifier.CheckTautology(" a & b");
            Assert.AreEqual(result, false);

            result = verifier.CheckTautology("a & (b | c)");
            Assert.AreEqual(result, false);

            result = verifier.CheckTautology("!a & !b");
            Assert.AreEqual(result, false);

            result = verifier.CheckTautology("(!a | (b & !a))");
            Assert.AreEqual(result, false);

            result = verifier.CheckTautology(" a & !a");
            Assert.AreEqual(result, false);



            result = verifier.CheckTautology("( (a & (!b | b)) | (!a & (!b | b)) )");
            Assert.AreEqual(result, true);

            result = verifier.CheckTautology("(!a | (a & a))");
            Assert.AreEqual(result, true);

            result = verifier.CheckTautology("(!a | a)");
            Assert.AreEqual(result, true);

            result = verifier.CheckTautology("(!a | (a & !a))");
            Assert.AreEqual(result, false);

            //Extra conditions
            result = verifier.CheckTautology("( !(a & a) | (a | !a))");
            Assert.AreEqual(result, true);


        }

        [TestMethod]
        public void Test_EBNF_PostFix_Conversion()
        {
            var convertor = new EBNFConvertor();
            string result;

            result = convertor.ConvertInfixToPostFix("!a&b");
            Assert.AreEqual(result, "a!b&");

            result = convertor.ConvertInfixToPostFix(" a ");
            Assert.AreEqual(result, "a");

            result = convertor.ConvertInfixToPostFix(" a & b");
            Assert.AreEqual(result, "ab&");

            result = convertor.ConvertInfixToPostFix("a & (b | c)");
            Assert.AreEqual(result, "abc|&");

            result = convertor.ConvertInfixToPostFix("!a & !b");
            Assert.AreEqual(result, "a!b!&");

            result = convertor.ConvertInfixToPostFix(" a & !a");
            Assert.AreEqual(result, "aa!&");

            result = convertor.ConvertInfixToPostFix("( (a & (!b | b)) | (!a & (!b | b)) )");
            Assert.AreEqual(result, "ab!b|&a!b!b|&|");

            result = convertor.ConvertInfixToPostFix("(!a | (a & a))");
            Assert.AreEqual(result, "a!aa&|");

            result = convertor.ConvertInfixToPostFix("(!a | (b & !a))");
            Assert.AreEqual(result, "a!ba!&|");

            result = convertor.ConvertInfixToPostFix("(!a | a)");
            Assert.AreEqual(result, "a!a|");

            //Extra conditions
            result = convertor.ConvertInfixToPostFix("(!a | !(a& a))");
            Assert.AreEqual(result, "a!aa&!|");


        }

        [TestMethod]
        public void Test_Tautology_Refactored()
        {
            var verifier = new RefactoredPropositionalEngine();
            bool result;

            result = verifier.CheckTautology("!a&b");
            Assert.AreEqual(result, false);

            result = verifier.CheckTautology(" a ");
            Assert.AreEqual(result, false);

            result = verifier.CheckTautology(" a & b");
            Assert.AreEqual(result, false);

            result = verifier.CheckTautology("a & (b | c)");
            Assert.AreEqual(result, false);

            result = verifier.CheckTautology("!a & !b");
            Assert.AreEqual(result, false);

            result = verifier.CheckTautology("(!a | (b & !a))");
            Assert.AreEqual(result, false);

            result = verifier.CheckTautology(" a & !a");
            Assert.AreEqual(result, false);



            result = verifier.CheckTautology("( (a & (!b | b)) | (!a & (!b | b)) )");
            Assert.AreEqual(result, true);

            result = verifier.CheckTautology("(!a | (a & a))");
            Assert.AreEqual(result, true);

            result = verifier.CheckTautology("(!a | a)");
            Assert.AreEqual(result, true);

            result = verifier.CheckTautology("(!a | (a & !a))");
            Assert.AreEqual(result, false);

            //Extra conditions
            result = verifier.CheckTautology("( !(a & a) | (a | !a))");
            Assert.AreEqual(result, true);

            result = verifier.CheckTautology("( !(a & b) | (a & b))");
            Assert.AreEqual(result, true);

            result = verifier.CheckTautology("( !(a & ((b & (a | !a))| c)) | (a & (b|c)))");
            Assert.AreEqual(result, true);

            result = verifier.CheckTautology("( !(a & !(a))");
            Assert.AreEqual(result, true);

            result = verifier.CheckTautology("!(a & !a)");
            Assert.AreEqual(result, true);

            result = verifier.CheckTautology("( !(a & !(!b)) | (a & b))");
            Assert.AreEqual(result, true);

            result = verifier.CheckTautology("( !a | (a & !(b & !b)))");
            Assert.AreEqual(result, true);
        }


    }
}
