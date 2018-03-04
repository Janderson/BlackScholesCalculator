using Accord.Statistics.Distributions.Univariate;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Calculations
{
    public class Garman : ICalculator
    {
        /* Calculate the prob the value fall into normal probability distribution */
        public double NormDistZ(double Value)
        {
            var NormDist = new NormalDistribution(mean: 0, stdDev: 1);
            return NormDist.DistributionFunction(Value);
        }

        public double D1(CalculatorValues Values)
        {
            double pt1 = (Math.Log(Values.ForwardPrice / Values.Strike) + Math.Pow(Values.Volatility, 2) * (Values.QtdDaysExpire / 252.0) / 2.0);
            double pt2 = Values.Volatility * Math.Pow(Values.QtdDaysExpire / 252, (1.0 / 2.0));
            return pt1 / pt2;
        }

        public double D2(CalculatorValues Values)
        {
            return D1(Values) - Values.Volatility * Math.Pow((Values.QtdDaysExpire / 252.0), (1.0 / 2.0));
        }

        public double CallPremium(CalculatorValues Values)
        {
            Values.CalcForwardPrice();
            return (Values.ForwardPrice * NormDistZ(D1(Values)) 
                - Values.Strike * NormDistZ(D2(Values))) 
                * Values.Interest;
        }

        public double PutPremium(CalculatorValues Values)
        {
            Values.CalcForwardPrice();
            return (Values.ForwardPrice * NormDistZ(-D2(Values)) - Values.Strike * NormDistZ(-D1(Values))) * Values.Interest;
        }
    }



}
