using System;

namespace SalaryCalculateServices
{
    public interface IInflationRate
    {
        double GetInflationRateByYear(int year);
    }
    public class InflationRate : IInflationRate
    {
        public double GetInflationRateByYear(int year)
        {
            double rate;
            switch (year)
            {
                case 2020:
                    rate = 0.1;
                    break;
                case 2021:
                    rate = 0.2;
                    break;
                case 2022:
                    rate = 0.3;
                    break;
                default:
                    rate = 0.5;
                    break;
            }
            return rate;
        }
    }

    public class SalaryService
    {
        private IInflationRate _inflationRate;
        private readonly ILog _log;

        public SalaryService(IInflationRate inflationRate,ILog log)
        {
            this._inflationRate = inflationRate;
            this._log = log;
        }

        public double CalculateSalaryByInflationRateAndYear(int year, int salaryAmount)
        {
            if (year < 2000 || year > DateTime.Now.Year)
            {
                throw new Exception("Invalid Year");
            }
            if (salaryAmount<0)
            {
                throw new Exception("Invalid SalaryAmount");
            }
            _log.LogWrite($"{year} {salaryAmount}");

            var rate = _inflationRate.GetInflationRateByYear(year);
            var result = salaryAmount + salaryAmount * rate;
            return result;
        }
    }
}
