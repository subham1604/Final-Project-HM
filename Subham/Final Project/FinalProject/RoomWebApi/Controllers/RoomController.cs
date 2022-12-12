using DataAccessLayer;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace RoomWebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RoomController : ControllerBase
    {
        private readonly IDatabaseRoom dal;

        public RoomController(IDatabaseRoom dal)
        {
            this.dal = dal;
        }


    
        // GET: api/<RoomController>
        [HttpGet]
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET api/<RoomController>/5
        [HttpGet]
        [Route("GetRoomByHotelId/{id}")]
        public IEnumerable<Room> Get(int id)
        {
            return dal.GetAllRoomByHotelId(id);
        }

        // POST api/<RoomController>
        [HttpPost]
        [Route("AddRoomByHotelId")]
        public void Post([FromBody] Room rm)
        {
            dal.AddRoomByHotelId(rm);
        }

        // PUT api/<RoomController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<RoomController>/5
        [HttpDelete]
        [Route("DeleteRoomByHotelIdAndRoomType/{id}")]
        public void Delete(int id)
        {
            dal.DeleteRoomByHotelIdAndRoomType(id);
        }
    }
}
