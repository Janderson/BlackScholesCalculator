using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Calculations
{
    public enum BSCalcType
    {
        CallOption = 1,
        PutOption = 2,
    }

    public class CalculatorValues
    {
        const int DaysIntoAYear = 365;
        public double UnderlinePrice { get; set; }
        public double ForwardPrice { get; private set; } // preço no futuro
        public double Interest
        {
            get { return CalcInterest(); }
            private set { }
        }


        public double TimeAnually
        {
            get { return CalcTimeAnually(); }
            private set { }
        }

        public double RiskFreeRate { get; set; }
        public double Strike { get; set; }
        public double QtdDaysExpire { get; set; }
        public double Volatility { get; set; }
        public double Dividend { get; set; }



        public void CalcForwardPrice()
        {
            CalcInterest();
            ForwardPrice = UnderlinePrice / Interest;
        }

        public double CalcInterest()
        {
            return Math.Pow(RiskFreeRate + 1, (QtdDaysExpire * -1) / DaysIntoAYear);
        }

        public double CalcTimeAnually()
        {
            return (double)QtdDaysExpire / (double)DaysIntoAYear;
        }
    }
}
