﻿using Moq;
using SalaryCalculateServices;
using System;
using Xunit;

namespace XUnitTestProject1
{
    public class UnitTest1
    {
        //  private IInflationRate _inflation;
        private readonly Mock<IInflationRate> _mockRate;
        private readonly Mock<ILog> _mockLog;
        private readonly SalaryService _salaryService;

        public UnitTest1()
        {
            _mockRate = new Mock<IInflationRate>(MockBehavior.Loose);
            _mockLog = new Mock<ILog>(MockBehavior.Loose);
            //  _inflation = new InflationRate();
            //_inflationService = new InflationService(_inflation);
            _salaryService = new SalaryService(_mockRate.Object,_mockLog.Object);
            // sana sahte bir nesne verdim demiş oldum.
        }

        [Fact]
        public void CalculateSalaryByInflationRateAndYear_WhenSalary3000andRate0_3_Return3900()
        {
            double expectedSalary = 3900;

            _mockRate.Setup(x => x.GetInflationRateByYear(It.IsAny<int>())).Returns(0.3);

            var actualRate = _salaryService.CalculateSalaryByInflationRateAndYear(2020, 3000);

            Assert.Equal<double>(expectedSalary, actualRate);
        }

        [Theory]
        [InlineData(1999, -100)]
        public void CalculateSalaryByInflationRateAndYear_WhenValidYear_ReturnException(int year, int salaryAmount)
        {
            // method un validasyon kısmında fırlatılan hatayı yakalama test edildiğinden mock nesneye ihtiyacım yok.
            var actaulResult = Assert.Throws<Exception>(() => _salaryService.CalculateSalaryByInflationRateAndYear(year, salaryAmount));

            Assert.Equal("Invalid Year", actaulResult.Message);
        }

        [Fact]
        public void CalculateSalaryByInflationRateAndYear_WhenValidYear__WhenSalary3000andRate0_3_Return3900AndLogMetotRun()
        {
            double expected = 3900;
            _mockRate.Setup(x => x.GetInflationRateByYear(It.IsAny<int>())).Returns(0.3);
            var actual = _salaryService.CalculateSalaryByInflationRateAndYear(2020, 3000);
            Assert.Equal<double>(expected, actual);
            _mockLog.Verify(x => x.LogWrite(It.IsAny<string>()), Times.Once());
        }
    }
}