using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnitTest_Sample.Fundamentals;
using Xunit;

namespace UnitTest_Sample.UnitTest.FundamentalsTest
{
    public class DemeritPointsCalculatorTests
    {
        private readonly DemeritPointsCalculator _demeritPointsCalculator;

        public DemeritPointsCalculatorTests()
        {
            _demeritPointsCalculator = new DemeritPointsCalculator();
        }

        [Theory]
        [InlineData(-1)]
        [InlineData(301)]
        public void CalculateDemeritPoints_SpeedOutOfRange_ReturnArgumentOutOfRangeException(int speed)
        {
            Assert.Throws<ArgumentOutOfRangeException>(() => _demeritPointsCalculator.CalculateDemeritPoints(speed));
        }

        [Theory]
        [InlineData(0, 0)]
        [InlineData(64, 0)]
        [InlineData(65, 0)]
        [InlineData(66, 0)]
        [InlineData(70, 1)]
        [InlineData(75, 2)]
        public void CalculateDemeritPoints_WhenCalled_ReturnExpectedResult(int speed, int expectedResult)
        {
            Assert.Equal(expectedResult, _demeritPointsCalculator.CalculateDemeritPoints(speed));
        }

    }
}
