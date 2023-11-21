using HotelApplication.Exceptions;
using HotelApplication.Interfaces;
using HotelApplication.Models;
using Microsoft.AspNetCore.Mvc;

namespace HotelApplication.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class HotelController : ControllerBase
    {
        private readonly IHotelRepository Repositories;

        public HotelController(IHotelRepository repo)
        {
            Repositories = repo;
        }

        [HttpGet]
        public ActionResult GetAllHotels()
        {
            try
            {
                var hotels = Repositories.GetAllHotels();
                return Ok(hotels);
            }
            catch (DatabaseException ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }

        [HttpGet("{id:int}")]
        public ActionResult GetHotelById(int id)
        {
            try
            {
                var hotel = Repositories.GetHotelById(id);
                return Ok(hotel);
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
        public ActionResult<string> AddHotel(Hotel hotel)
        {
            try
            {
                string response = Repositories.AddHotel(hotel);
                return Ok(response);
            }
            catch (DatabaseException ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }

        [HttpPut]
        public ActionResult<string> UpdateHotel(Hotel hotel)
        {
            try
            {
                string response = Repositories.UpdateHotel(hotel);
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
        public ActionResult<string> DeleteHotel(int id)
        {
            try
            {
                string response = Repositories.DeleteHotel(id);
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
