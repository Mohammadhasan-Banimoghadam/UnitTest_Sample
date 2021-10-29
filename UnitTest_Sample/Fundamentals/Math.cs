using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace UnitTest_Sample.Fundamentals
{
    public class Math
    {
        public int Add(int firstNumber, int secondNumber)
        {
            return firstNumber + secondNumber;
        }

        public int Max(int firstNumber, int secondNumber)
        {
            return (firstNumber > secondNumber) ? firstNumber : secondNumber;
        }

        public IEnumerable<int> GetOddNumbers(int limit)
        {
            for (int i = 0; i <= limit; i++)
                if (i % 2 != 0)
                    yield return i;
        }
    }
}
