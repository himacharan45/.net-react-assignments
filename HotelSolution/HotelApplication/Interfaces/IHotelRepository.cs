using HotelApplication.Models;

namespace HotelApplication.Interfaces
{
    public interface IHotelRepository
    {
        Hotel GetHotelById(int key);
        List<Hotel> GetAllHotels();
        string AddHotel(Hotel entity);
        string UpdateHotel(Hotel entity);
        string DeleteHotel(int key);
    }
}
