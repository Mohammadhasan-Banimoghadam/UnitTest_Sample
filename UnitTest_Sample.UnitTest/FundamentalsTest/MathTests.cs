using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;
using Math = UnitTest_Sample.Fundamentals.Math;

namespace UnitTest_Sample.UnitTest.FundamentalsTest
{
    public class MathTests : IDisposable
    {
        /// <summary>
        /// This Is Similar To SetUp Attribute In NUnit
        /// This Is Executed Before Calling Test Methods
        /// Usually Used To Make Instance
        /// </summary>
        private readonly Math _math;
        public MathTests()
        {
            _math = new Math();
        }
        /// <summary>
        /// This Method Is Similar To TearDown Attribute In NUnit
        /// This Method Is Executed After Calling Our Test Methods
        /// Usually Used After Executed Integration Tests
        /// </summary>
        public void Dispose()
        {

        }
        /// <summary>
        /// Similar To Ignore Attribute In NUnit
        /// </summary>
        [Fact(Skip = "This Test Method Disable For Learning")]
        public void Add_WhenCalled_ReturnSumArgument()
        {
            var result = _math.Add(1, 2);
            Assert.Equal(3, result);
        }
        /// <summary>
        /// Use To Parametrized Method In XUnit
        /// Similar To TestCase Attribute In NUnit
        /// </summary>
        [Theory]
        [InlineData(1, 2, 2)]
        [InlineData(2, 1, 2)]
        [InlineData(1, 1, 1)]
        public void Max_WhenCalled_ReturnTheGreaterNumber(int firstNumber, int secondNumber, int expectedNumber)
        {
            var result = _math.Max(firstNumber, secondNumber);
            Assert.Equal(expectedNumber, result);
        }
    }
}
