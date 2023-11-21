using global::HotelApplication.Models;
using Microsoft.EntityFrameworkCore;

namespace HotelApplication.Contexts
{
    namespace HotelApplication.Contexts
    {
        public class HotelContext : DbContext
        {
            public HotelContext(DbContextOptions<HotelContext> options) : base(options)
            {

            }
            public DbSet<User> Users { get; set; }
            public DbSet<Hotel> Hotels { get; set; }

            public DbSet<Room> Rooms { get; set; }
            public DbSet<Booking> Bookings { get; set; }


        }
    }

}
