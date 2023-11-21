using System.ComponentModel.DataAnnotations;

namespace HotelApplication.Models
{
    public class User
    {
        [Key]
        public int UserId { get; set; }
        [Required]
        public string Username { get; set; }

        public byte[] Password { get; set; }
        public string Role { get; set; }
        public byte[] Key { get; set; }
    }
}
