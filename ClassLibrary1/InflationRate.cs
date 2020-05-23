namespace SalaryCalculater
{
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

                case 2023:
                    rate = 0.4;
                    break;

                default:
                    rate = 0.5;
                    break;
            }
            return rate;
        }
    }
}