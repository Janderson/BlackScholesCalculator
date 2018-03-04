using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Calculations
{
    interface ICalculator
    {
        double CallPremium(CalculatorValues Values);
        double PutPremium(CalculatorValues Values);
    }
}
