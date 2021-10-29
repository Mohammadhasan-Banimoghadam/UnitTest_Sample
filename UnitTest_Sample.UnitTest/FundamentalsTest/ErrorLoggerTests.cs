using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnitTest_Sample.Fundamentals;
using Xunit;
using Xunit.Sdk;

namespace UnitTest_Sample.UnitTest.FundamentalsTest
{
    public class ErrorLoggerTests
    {
        private readonly ErrorLogger _errorLogger;
        public ErrorLoggerTests()
        {
            _errorLogger = new ErrorLogger();
        }
        [Fact]
        public void Log_WhenCalled_SetErrorMessageForLastErrorProperty()
        {
            _errorLogger.Log("my error");

            Assert.Equal("my error", _errorLogger.LastError);
        }

        [Theory]
        [InlineData(null)]
        [InlineData("")]
        [InlineData(" ")]
        public void Log_InvalidError_ThrowArgumentNullException(string error)
        {
            Assert.Throws<ArgumentNullException>(() => _errorLogger.Log(error));
        }
        [Fact]
        public void Log_validError_RaiseErrorLoggedEvent()
        {
            var guid = Guid.Empty;
            _errorLogger.ErrorLogged += (sender, args) => { guid = args; };
            _errorLogger.Log("Test Log");

            Assert.NotEqual(Guid.Empty, guid);
        }
    }
}
