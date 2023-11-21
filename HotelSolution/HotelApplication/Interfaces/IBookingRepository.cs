using HotelApplication.Models;

namespace HotelApplication.Interfaces
{
    public interface IBookingRepository
    {
        List<Booking> GetAllBookings();
        string AddNewBooking(Booking booking);
        string UpdateBooking(Booking booking);
        string DeletBooking(int id);
        List<Booking> GetBookingById(int id);
    }
}
