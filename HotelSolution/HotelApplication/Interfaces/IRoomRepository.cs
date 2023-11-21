using HotelApplication.Models;

namespace HotelApplication.Interfaces
{
    public interface IRoomRepository
    {
        List<Room> GetAllRooms();
        List<Room> GetAllRoomsByHotelId(int hid);
        string AddNewRoom(Room room);
        string UpdateRoom(Room room);
        string DeleteRoom(int id);
        Room GetRoomById(int id);
    }
}
