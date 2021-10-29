using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace UnitTest_Sample.Fundamentals
{
    public class HtmlFormatter
    {
        public string FormatAsBold(string text)
        {
            return $"<strong>{text}</strong>";
        }
    }
}
