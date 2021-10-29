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

        [Fact]
        public void GetOutPut_DividedByThreeAndDividedByFive_ReturnFizzBaz()
        {
            var result = _fizzBaz.GetOutPut(15);
            Assert.Equal("FizzBaz", result);
        }
        [Fact]
        public void GetOutPut_DividedByThree_ReturnFizz()
        {
            var result = _fizzBaz.GetOutPut(6);
            Assert.Equal("Fizz", result);
        }
        [Fact]
        public void GetOutPut_DividedByThreeAndDividedByFive_ReturnBaz()
        {
            var result = _fizzBaz.GetOutPut(5);
            Assert.Equal("Baz", result);
        }
        [Fact]
        public void GetOutPut_NotDividedByThreeAndNotDividedByFive_ReturnNumberStr()
        {
            var result = _fizzBaz.GetOutPut(7);
            Assert.Equal("7", result);
        }
    }
}
