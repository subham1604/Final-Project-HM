using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace BookingAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IDatabase dal;
        public UserController(IDatabase dal)
        {
            this.dal = dal;
        }
        [HttpGet]
        [Route("GetUser")]
        public IEnumerable<UserDetail> Get()
        {
            return dal.GetAllUsers();
        }

        // GET api/<UserController>/5
        [HttpGet]
        [Route("GetUserById/{id}")]
        public UserDetail GetUserById(int id)
        {
            return dal.GetUserById(id);
        }

        // POST api/<UserController>
        [HttpPost]
        [Route("AddUser")]
        public IActionResult AddUser([FromBody] UserDetail user)
        {
            try
            {
                dal.AddUser(user);
                return Ok(user);
            }
            catch (Exception ex)
            {
                return BadRequest(new { ErrMsg = ex.Message });
            }
        }

        //PUT api/<UserController>/5
        [HttpPut]
        [Route("Edit/{id}")]
        public void Put(int id, [FromBody] UserDetail value)
        {
            dal.UpdateUser(value, id);
        }


        // DELETE api/<UserController>/5
        [HttpDelete]
        [Route("DeleteById/{id}")]
        public void Delete(int id)
        {
            dal.DeleteUser(id);
        }
    }
}





