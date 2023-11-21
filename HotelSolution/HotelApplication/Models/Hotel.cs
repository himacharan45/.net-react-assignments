using System.ComponentModel.DataAnnotations;

namespace HotelApplication.Models
{
    public class Hotel
    {
            [Key]
            public int HotelId { get; set; }
            public string HotelName { get; set; }
    
            public string Location { get; set; }
        
            public int AvailableRooms { get; set; }

            public List<Room>? Rooms { get; set; }

    }
}
