using Microsoft.Extensions.DependencyInjection;
using SalaryCalculateServices;
using System;

namespace MockDemos
{
    internal class Program
    {
        private static IInflationRate _inflation;
        private static void Main(string[] args)
        {
            ServiceProvider serviceProvider = startup();

            _inflation = serviceProvider.GetService<IInflationRate>();

            // _inflation = new InflationRate();

            var result = _inflation.GetInflationRateByYear(2030);

            Console.WriteLine($"{result}");
        }

        private static ServiceProvider startup()
        {
            return new ServiceCollection()
                                           .AddTransient<IInflationRate, InflationRate>()
                                           .BuildServiceProvider();
        }
    }
  
}