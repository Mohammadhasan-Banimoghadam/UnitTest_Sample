using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnitTest_Sample.Fundamentals;
using Xunit;

namespace UnitTest_Sample.UnitTest.FundamentalsTest
{
    public class HtmlFormatterTests
    {
        private readonly HtmlFormatter _htmlFormatter;
        public HtmlFormatterTests()
        {
            _htmlFormatter = new HtmlFormatter();
        }
        [Fact]
        public void FormatAsBold_WhenCalled_ShouldEncloseTheTextWithStrongElement()
        {
            var result = _htmlFormatter.FormatAsBold("abc");
            //specific
            Assert.Equal("<strong>abc</strong>", result);
            //more general
            Assert.StartsWith("<strong>", result);
            Assert.EndsWith("</strong>", result);
            Assert.Contains("abc", result);

        }
    }
}
