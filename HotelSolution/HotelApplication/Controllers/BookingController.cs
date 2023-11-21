using HotelApplication.Exceptions;
using HotelApplication.Interfaces;
using HotelApplication.Models;
using Microsoft.AspNetCore.Mvc;

namespace HotelApplication.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BookingController : ControllerBase
    {
        private readonly IBookingRepository Repositories;

        public BookingController(IBookingRepository repo)
        {
            Repositories = repo;
        }

        [HttpGet]
        public ActionResult<IEnumerable<Booking>> Get()
        {
            try
            {
                var bookings = Repositories.GetAllBookings();
                return Ok(bookings);
            }
            catch (DatabaseException ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }

        [HttpGet("{id:int}")]
        public ActionResult<List<Booking>> Get(int id)
        {
            try
            {
                var bookings = Repositories.GetBookingById(id);
                return Ok(bookings);
            }
            catch (NotFoundException ex)
            {
                return NotFound(ex.Message);
            }
            catch (DatabaseException ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }

        [HttpPost]
        public ActionResult<string> Post(Booking booking)
        {
            try
            {
                var response = Repositories.AddNewBooking(booking);
                return Ok(response);
            }
            catch (DatabaseException ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }

        [HttpPut]
        public ActionResult<string> Put(Booking booking)
        {
            try
            {
                var response = Repositories.UpdateBooking(booking);
                return Ok(response);
            }
            catch (NotFoundException ex)
            {
                return NotFound(ex.Message);
            }
            catch (DatabaseException ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }

        [HttpDelete("{id:int}")]
        public ActionResult<string> Delete(int id)
        {
            try
            {
                var response = Repositories.DeletBooking(id);
                return Ok(response);
            }
            catch (NotFoundException ex)
            {
                return NotFound(ex.Message);
            }
            catch (DatabaseException ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }
    }
}
