using System.ComponentModel.DataAnnotations;

namespace HotelApplication.Models
{
    public class Booking
    {
        [Key]
        public int BookingId { get; set; }
        public int UserId { get; set; }
        public int RoomId { get; set; }
        public int HotelId { get; set; }
        public DateTime CheckInDate { get; set; }
        public DateTime CheckOutDate { get; set; }
        public int NoOfPeople { get; set; }

        public Room? Room { get; set; }
        public User? User { get; set; }
    }
}
