using HotelApplication.Models.DTO;

namespace HotelApplication.Interfaces
{
    public interface ITokenService
    {
        string GetToken(UserDTO user);
    }
}
