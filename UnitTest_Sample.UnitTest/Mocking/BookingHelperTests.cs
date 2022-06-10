using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnitTest_Sample.Mocking;
using Xunit;

namespace UnitTest_Sample.UnitTest.Mocking
{
    public class BookingHelperTests
    {
        private Booking _booking;
        private Mock<IBookingRepository> _bookingRepository;
        private BookingHelper _bookingHelper;

        public BookingHelperTests()
        {
            _booking = new Booking()
            {
                Id = 2,
                ArrivalDate = ArrivalOn(2017, 1, 15),
                DepartureDate = DepartureOn(2017, 1, 20),
                Reference = "a"
            };
            _bookingRepository = new Mock<IBookingRepository>();
            _bookingRepository.Setup(b => b.GetActiveBookings(1)).Returns(new List<Booking>
            {
                _booking
            }.AsQueryable());
            _bookingHelper = new BookingHelper(_bookingRepository.Object);
        }
        [Fact]
        public void OverlappingBookingsExist_StartAndEndBeforeAnExistingBooking_ReturnEmptyString()
        {
            var result = _bookingHelper.OverlappingBookingsExist(new Booking()
            {
                Id = 1,
                ArrivalDate = Before(_booking.ArrivalDate),
                DepartureDate = Before(_booking.ArrivalDate)
            });

            Assert.Equal(string.Empty, result);
        }

        [Fact]
        public void OverlappingBookingsExist_StartBeforeAndEndMiddleAnExistingBooking_ReturnRefrence()
        {
            var result = _bookingHelper.OverlappingBookingsExist(new Booking()
            {
                Id = 1,
                ArrivalDate = Before(_booking.ArrivalDate),
                DepartureDate = After(_booking.ArrivalDate)
            });

            Assert.Equal(_booking.Reference, result);
        }

        [Fact]
        public void OverlappingBookingsExist_StartMiddleAndEndMiddleAnExistingBooking_ReturnRefrence()
        {
            var result = _bookingHelper.OverlappingBookingsExist(new Booking()
            {
                Id = 1,
                ArrivalDate = After(_booking.ArrivalDate),
                DepartureDate = Before(_booking.DepartureDate)
            });

            Assert.Equal(_booking.Reference, result);
        }

        [Fact]
        public void OverlappingBookingsExist_StartMiddleAndEndAfterAnExistingBooking_ReturnRefrence()
        {
            var result = _bookingHelper.OverlappingBookingsExist(new Booking()
            {
                Id = 1,
                ArrivalDate = Before(_booking.DepartureDate),
                DepartureDate = After(_booking.DepartureDate)
            });

            Assert.Equal(_booking.Reference, result);
        }

        [Fact]
        public void OverlappingBookingsExist_StartAfterAndEndAfterAnExistingBooking_ReturnEmptyString()
        {
            var result = _bookingHelper.OverlappingBookingsExist(new Booking()
            {
                Id = 1,
                ArrivalDate = After(_booking.DepartureDate),
                DepartureDate = After(_booking.DepartureDate)
            });

            Assert.Equal(string.Empty, result);
        }

        [Fact]
        public void OverlappingBookingsExist_StartBeforeAndEndAfterAnExistingBooking_ReturnEmptyString()
        {
            var result = _bookingHelper.OverlappingBookingsExist(new Booking()
            {
                Id = 1,
                ArrivalDate = After(_booking.DepartureDate),
                DepartureDate = After(_booking.DepartureDate)
            });

            Assert.Equal(string.Empty, result);
        }

        [Fact]
        public void OverlappingBookingsExist_OverLappButNewBookingCancelled_ReturnEmptyString()
        {
            var result = _bookingHelper.OverlappingBookingsExist(new Booking()
            {
                Id = 1,
                ArrivalDate = After(_booking.ArrivalDate),
                DepartureDate = Before(_booking.DepartureDate),
                Status = "Cancelled"
            });

            Assert.Equal(string.Empty, result);
        }


        private DateTime ArrivalOn(int year, int month, int day)
        {
            return new DateTime(year, month, day, 14, 0, 0);
        }
        private DateTime DepartureOn(int year, int month, int day)
        {
            return new DateTime(year, month, day, 10, 0, 0);
        }

        private DateTime Before(DateTime dateTime, int day = 1)
        {
            return dateTime.AddDays(-day);
        }

        private DateTime After(DateTime dateTime)
        {
            return dateTime.AddDays(1);
        }
    }
}
