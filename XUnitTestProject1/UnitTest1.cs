using Moq;
using SalaryCalculater;
using Xunit;

namespace XUnitTestProject1
{
    public class UnitTest1
    {
        private IInflationRate _inflation;
        private readonly Mock<IInflationRate> _mockObjem;
        private readonly SalaryService _salaryService;

        public UnitTest1()
        {
            _mockObjem = new Mock<IInflationRate>(MockBehavior.Loose);
            _inflation = new InflationRate();
            //_inflationService = new InflationService(_inflation);
            _salaryService = new SalaryService(_mockObjem.Object);
            // sana sahte bir nesne verdim demiş oldum.
        }

        [Fact]
        public void Test1()
        {
            double expectedSalary = 3900;

            _mockObjem.Setup(x => x.GetInflationRateByYear(It.IsAny<int>())).Returns(0.3);

            var actualRate = _salaryService.CalculateSalaryByInflationRateAndYear(2021, 3000);

            Assert.Equal<double>(expectedSalary, actualRate);
        }
    }
}