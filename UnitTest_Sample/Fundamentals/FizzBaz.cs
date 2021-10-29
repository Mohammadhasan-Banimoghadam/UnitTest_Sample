using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace UnitTest_Sample.Fundamentals
{
    public class FizzBaz
    {
        public string GetOutPut(int number)
        {
            if (number % 3 == 0 && number % 5 == 0)
                return "FizzBaz";

            if (number % 3 == 0)
                return "Fizz";

            if (number % 5 == 0)
                return "Baz";

            return number.ToString();
        }
    }
}
