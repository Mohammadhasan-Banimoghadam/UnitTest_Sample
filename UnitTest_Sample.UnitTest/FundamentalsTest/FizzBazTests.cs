using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnitTest_Sample.Fundamentals;
using Xunit;

namespace UnitTest_Sample.UnitTest.FundamentalsTest
{
    public class FizzBazTests
    {
        private readonly FizzBaz _fizzBaz;
        public FizzBazTests()
        {
            _fizzBaz = new FizzBaz();
        }

        [Theory]
        [InlineData(15, "FizzBaz")]
        [InlineData(6, "Fizz")]
        [InlineData(5, "Baz")]
        [InlineData(7, "7")]
        public void GetOutPut_WhenCalled_ReturnExpectedResult(int number, string expectedResult)
        {
            var result = _fizzBaz.GetOutPut(number);
            Assert.Equal(expectedResult, result);
        }
    }
}
