using Accord.Statistics.Distributions.Univariate;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Calculations
{
    public class BlackScholes : ICalculator
    {
        /* Calculate the prob the value fall into normal probability distribution */
        public double NormDistZ(double Value)
        {
            var NormDist = new NormalDistribution(mean: 0, stdDev: 1);
            return NormDist.DistributionFunction(Value);
        }

        public double D1(CalculatorValues Values)
        {
            return (Math.Log(Values.UnderlinePrice / Values.Strike) +
                (Values.RiskFreeRate - Values.Dividend + 0.5 * Math.Pow(Values.Volatility, 2)) * Values.TimeAnually) /
                (Values.Volatility * (Math.Sqrt(Values.TimeAnually)));
        }

        public double D2(CalculatorValues Values)
        {
            return D1(Values) - Values.Volatility * Math.Sqrt(Values.TimeAnually);
        }

        double NdD1(CalculatorValues Values) {
            return Math.Exp(-Math.Pow(D1(Values),2) / 2) / (Math.Sqrt(2 * Math.PI));
        }


        public double CallPremium(CalculatorValues Values)
        {
            return Math.Exp(-Values.Dividend * Values.TimeAnually) *
                Values.UnderlinePrice * NormDistZ(D1(Values)) -
                Values.Strike * Math.Exp(-Values.RiskFreeRate * Values.TimeAnually) *
                NormDistZ(D1(Values) - Values.Volatility * Math.Sqrt(Values.TimeAnually));
        }

        public double PutPremium(CalculatorValues Values)
        {

            double d2 = D2(Values);
            //  optionValue = X * Math.Exp(-r * T) * CumulativeNormalDistributionFun(-d2) - S * CumulativeNormalDistributionFun(-d1);
            return (Values.Strike * Math.Exp(-Values.RiskFreeRate * Values.TimeAnually) * NormDistZ(-D2(Values))) - 
                (Math.Exp(-Values.Dividend * Values.TimeAnually) * Values.UnderlinePrice * NormDistZ(-D1(Values)));
        }
    }



}



