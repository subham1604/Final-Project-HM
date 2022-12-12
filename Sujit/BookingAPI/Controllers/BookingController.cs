using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace BookingAPI.Controllers
{
    //[Route("api/[controller]")]
    //[ApiController]
    //public class BookingController : ControllerBase
    //{
    //    private readonly HolidayDbContext _booking;

    //    public BookingController(HolidayDbContext booking)
    //    {
    //        this._booking = booking;
    //    }

    //    [HttpGet]
    //    public async Task<IActionResult> GetBookings()
    //    {
    //        return Ok(await _booking.Bookings.ToListAsync());
    //    }

    //}

    [Route("api/[controller]")]
    [ApiController]
    public class BookingController : ControllerBase
    {
        private readonly IDatabase dal;
        public BookingController(IDatabase dal)
        {
            this.dal = dal;
        }


        [HttpGet]
        [Route("GetAllBooking")]
        public IEnumerable<Booking> Get()
        {
            return dal.GetAllBooking();
        }


        [HttpGet]
        [Route("GetBookingByBookingId/{booking_id}")]
        public Booking GetBookingById(string booking_id)
        {
            return dal.GetBookingById(booking_id);
        }


        [HttpPost]
        [Route("AddBooking")]
        public IActionResult AddBooking([FromBody] Booking booking)
        {
            try
            {
                booking.BookingId = "BKID00" + booking.HotelId + booking.UserId;
                dal.AddBooking(booking);
                return Ok(booking);
            }
            catch (Exception ex)
            {
                return BadRequest(new { ErrMsg = ex.Message });
            }
        }


        // PUT api/<UserController>/5
        [HttpPut]
        [Route("Edit/{booking_id}")]
        public void Put(string booking_id, [FromBody] Booking value)
        {
            value.BookingId = "BKID00" + value.HotelId + value.UserId;
            dal.UpdateBooking(value, booking_id);
        }


        // DELETE api/<UserController>/5
        [HttpDelete]
        [Route("DeleteById/{booking_id}")]
        public void Delete(string booking_id)
        {
            dal.DeleteBooking(booking_id);
        }
    }



}



