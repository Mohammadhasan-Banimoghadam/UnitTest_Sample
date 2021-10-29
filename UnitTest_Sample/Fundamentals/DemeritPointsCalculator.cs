using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace UnitTest_Sample.Fundamentals
{
    public class DemeritPointsCalculator
    {
        private int speedLimit = 65;
        private int maxSpeed = 300;
        public int CalculateDemeritPoints(int speed)
        {
            if (speed < 0 || speed > maxSpeed)
                throw new ArgumentOutOfRangeException();

            if (speed <= speedLimit) return 0;

            int kmPerDemeritPoint = 5;

            var demeritPoints = (speed - speedLimit) / kmPerDemeritPoint;
            return demeritPoints;

        }
    }
}
