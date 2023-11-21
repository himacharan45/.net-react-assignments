//using HotelApplication.Exceptions;
//using HotelApplication.Interfaces;
//using HotelApplication.Models;
//using Microsoft.AspNetCore.Mvc;

//namespace HotelApplication.Controllers
//{
//    [Route("api/[controller]")]
//    [ApiController]
//    public class RoomsController : ControllerBase
//    {
//        private readonly IRoomRepository Repositories;

//        public RoomsController(IRoomRepository repo)
//        {
//            Repositories = repo;
//        }

//        [HttpGet]
//        public ActionResult<IEnumerable<Room>> GetRooms()
//        {
//            try
//            {
//                var rooms = Repositories.GetAllRooms();
//                return Ok(rooms);
//            }
//            catch (DatabaseException ex)
//            {
//                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
//            }
//        }

//        [HttpGet("{id}")]
//        public ActionResult<Room> GetRoom(int id)
//        {
//            try
//            {
//                var room = Repositories.GetRoomById(id);
//                return Ok(room);
//            }
//            catch (NotFoundException ex)
//            {
//                return NotFound(ex.Message);
//            }
//            catch (DatabaseException ex)
//            {
//                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
//            }
//        }

//        [HttpPut("{id}")]
//        public ActionResult<string> PutRoom(int id, Room room)
//        {
//            try
//            {
//                var response = Repositories.UpdateRoom(room);
//                return Ok(response);
//            }
//            catch (NotFoundException ex)
//            {
//                return NotFound(ex.Message);
//            }
//            catch (DatabaseException ex)
//            {
//                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
//            }
//        }

//        [HttpPost]
//        public ActionResult<string> PostRoom(Room room)
//        {
//            try
//            {
//                var response = Repositories.AddNewRoom(room);
//                return Ok(response);
//            }
//            catch (DatabaseException ex)
//            {
//                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
//            }
//        }

//        [HttpDelete("{id}")]
//        public ActionResult<string> DeleteRoom(int id)
//        {
//            try
//            {
//                var response = Repositories.DeleteRoom(id);
//                return Ok(response);
//            }
//            catch (NotFoundException ex)
//            {
//                return NotFound(ex.Message);
//            }
//            catch (DatabaseException ex)
//            {
//                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
//            }
//        }
//    }
//}
