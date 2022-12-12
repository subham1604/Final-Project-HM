using Microsoft.AspNetCore.Mvc;
using DataAccessLayer; 

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace HotelWebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class HotelController : ControllerBase
    {
        private readonly IDatabaseHotel dal;

        public HotelController(IDatabaseHotel dal)
        {
            this.dal = dal;
        }


    
        // GET: api/<HotelController>
        [HttpGet]
        [Route("GetAllHotels")]
        public IEnumerable<Hotel> Get()
        {
            return dal.GetAllHotels();
        }

        // GET api/<HotelController>/5
        [HttpGet]
        [Route("GetHotelById/{id}")]
        public Hotel Get(int id)
        {
            return dal.GetHotelById(id);
        }

        // POST api/<HotelController>
        [HttpPost]
        [Route("AddHotel")]
        public void Post([FromBody] Hotel htl)
        {
            
                dal.AddHotel(htl);

            
            

        }

        // PUT api/<HotelController>/5
        [HttpPut]
        [Route("UpdateHotel/{id}")]
        public void Put(int id, [FromBody] Hotel htl)
        {
            dal.UpdateHotel(htl);
        }

        // DELETE api/<HotelController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            dal.DeleteHotel(id);
        }
    }
}
