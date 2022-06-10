using System;
using System.Collections.Generic;
using System.Linq;

namespace UnitTest_Sample.Mocking
{
    public class BookingHelper
    {
        private readonly IBookingRepository _bookingRepository;
        public BookingHelper(IBookingRepository bookingRepository)
        {
            _bookingRepository = bookingRepository;
        }

        public string OverlappingBookingsExist(Booking booking)
        {
            if (booking.Status == "Cancelled")
                return string.Empty;

            var bookings = _bookingRepository.GetActiveBookings(booking.Id);
            var overlappingBooking =
                bookings.FirstOrDefault(
                    b =>
                        booking.ArrivalDate < b.DepartureDate &&
                        b.ArrivalDate < booking.DepartureDate);

            return overlappingBooking == null ? string.Empty : overlappingBooking.Reference;
        }
    }

    public interface IUnitOfWork
    {
        IQueryable<T> Query<T>();
    }

    public class UnitOfWork : IUnitOfWork
    {
        public IQueryable<T> Query<T>()
        {
            return new List<T>().AsQueryable();
        }
    }

    public class Booking
    {
        public string Status { get; set; }
        public int Id { get; set; }
        public DateTime ArrivalDate { get; set; }
        public DateTime DepartureDate { get; set; }
        public string Reference { get; set; }
    }
}
