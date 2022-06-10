using System.Linq;

namespace UnitTest_Sample.Mocking
{
    public interface IBookingRepository
    {
        public IQueryable<Booking> GetActiveBookings(int? bookingId = null);
    }
    public class BookingRepository : IBookingRepository
    {
        private readonly IUnitOfWork _unitOfWork;
        public BookingRepository(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public IQueryable<Booking> GetActiveBookings(int? bookingId = null)
        {
            var bookings = _unitOfWork
                .Query<Booking>()
                .Where(b => b.Status != "Cancelled");

            if (bookingId.HasValue)
                bookings = bookings.Where(b => b.Id != bookingId.Value);

            return bookings;
        }
    }
}
