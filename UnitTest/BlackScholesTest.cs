using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Calculations;

namespace UnitTest
{
    [TestClass]
    public class BlackScholesTest
    {
        BlackScholes BSCalc;
        [TestInitialize]
        public void CreateCalc()
        {
            BSCalc = new BlackScholes();
        }

        [TestMethod]
        public void NormZTest_1()
        {
            double Value = 0;
            double Result = 0.5;
            Assert.AreEqual(BSCalc.NormDistZ(Value), Result, $"NormZTest_ Should Be {Result}");
        }

        [TestMethod]
        public void NormZTest_2()
        {
            double Value = 1.5;
            double ResultExpected = 0.933193;
            double ResultReal = Math.Round(BSCalc.NormDistZ(Value), 6);

            Assert.AreEqual(ResultExpected, ResultReal, $"NormZTest_ Should Be {ResultExpected} but was {ResultReal }");
        }

        [TestMethod]
        public void NormZTest_3()
        {
            double Value = 4;
            double ResultExpected = 0.999968;
            double ResultReal = Math.Round(BSCalc.NormDistZ(Value), 6, MidpointRounding.AwayFromZero);

            Assert.AreEqual(ResultExpected, ResultReal, $"NormZTest_ Should Be {ResultExpected} but was {ResultReal }");
        }

        [TestMethod]
        public void BS_d1_Test()
        {
            double ResultExpected = -1.728946;

            double ResultReal = Math.Round(
                BSCalc.D1( new CalculatorValues
                {
                    UnderlinePrice = 1,
                    Strike = 2,
                    QtdDaysExpire = 3,
                    Volatility = 4,
                    RiskFreeRate = 0.05

                }),  
            6);

            Assert.AreEqual(ResultExpected, ResultReal, $"BS_d1_Test Should Be {ResultExpected} but was {ResultReal }");
        }

        [TestMethod]
        public void BS_d2_Test()
        {
            double ResultExpected = -2.091585;
            double ResultReal = Math.Round(
                BSCalc.D2(new CalculatorValues
                {
                    UnderlinePrice = 1,
                    Strike = 2,
                    QtdDaysExpire = 3,
                    Volatility = 4,
                    RiskFreeRate = 0.05
                }),
            6);

            Assert.AreEqual(ResultExpected, ResultReal, $"BS_d2_Test Should Be {ResultExpected} but was {ResultReal}");
        }

        [TestMethod]
        public void BSCallPremiumTest()
        {
            double ResultExpected = 0.796646;
            double ResultReal = Math.Round(
                BSCalc.CallPremium(new CalculatorValues
                {
                    UnderlinePrice = 47.22,
                    Strike = 47.25,
                    QtdDaysExpire = 10,
                    Volatility = 0.25,
                    RiskFreeRate = 0.05,
                    Dividend = 0
                }),
            6);

            Assert.AreEqual(ResultExpected, ResultReal, $"BSCallPremiumTest Should Be {ResultExpected} but was {ResultReal }");
        }

        [TestMethod]
        public void BSPutPremiumTest()
        {
            double ResultExpected = 0.761964;
            double ResultReal = Math.Round(
                BSCalc.PutPremium(new CalculatorValues
                {
                    UnderlinePrice = 47.22,
                    Strike = 47.25,
                    QtdDaysExpire = 10,
                    Volatility = 0.25,
                    RiskFreeRate = 0.05,
                    Dividend = 0
                }),
            6);

            Assert.AreEqual(ResultExpected, ResultReal, $"BSCallPremiumTest Should Be {ResultExpected} but was {ResultReal }");
        }



    }
}
