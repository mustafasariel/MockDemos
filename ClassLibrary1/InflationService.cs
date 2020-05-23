using System;
using System.Collections.Generic;
using System.Text;

namespace ClassLibrary1
{
    public class SalaryService
    {
        IInflationRate _inflationRate;

        public SalaryService(IInflationRate inflationRate)
        {
            this._inflationRate = inflationRate;
        }
        public double CalculateSalaryByInflationRateAndYear(int year,int amount)
        {
            var rate = _inflationRate.GetInflationRateByYear(year);
            var result = amount + amount * rate;
            return result;
        }
    }
}
