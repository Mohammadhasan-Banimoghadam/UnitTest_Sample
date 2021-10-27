using System;
using UnitTest_Sample.Fundamentals;
using Xunit;

namespace UnitTest_Sample.UnitTest.FundamentalsTest
{
    public class ReservationTests
    {
        [Fact]
        public void CanBeCancelBy_AdminCancelling_ReturnsTrue()
        {
            //arrange
            var reservation = new Reservation();
            //act
            var result = reservation.CanBeCancelBy(new User() { IsAdmin = true });
            //assert
            Assert.True(result);
        }

        [Fact]
        public void CanBeCancelBy_SameUserCancelling_ReturnsTrue()
        {
            var user = new User();
            var reservation = new Reservation() { MadeBy = user };
            var result = reservation.CanBeCancelBy(user);
            Assert.True(result);
        }

        [Fact]
        public void CanBeCancelBy_OtherUserCancelling_ReturnsFalse()
        {
            var reservation = new Reservation() { MadeBy = new User() };
            var result = reservation.CanBeCancelBy(new User());
            Assert.False(result);
        }
    }
}
