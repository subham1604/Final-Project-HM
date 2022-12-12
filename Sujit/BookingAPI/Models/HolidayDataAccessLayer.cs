namespace BookingAPI.Models
{
    public class HolidayDataAccessLayer : IDatabase
    {
        private readonly HolidayDbContext dbCtx;
        public HolidayDataAccessLayer(HolidayDbContext dbCtx)
        {
            this.dbCtx = dbCtx;
        }

        //User data Access layer
        
        public void AddUser(UserDetail user)
        {
            try
            {
                dbCtx.Add(user);
                dbCtx.SaveChanges();
            }
            catch (Exception ex)
            {
                throw new Exception("Some database error");
            }
        }

        public void DeleteUser(int userId)
        {
            var user = dbCtx.UserDetails.Where(o => o.UserId == userId).SingleOrDefault();
            if (user != null)
            {
                dbCtx.UserDetails.Remove(user);
                dbCtx.SaveChanges();
            }
        }

        public List<UserDetail> GetAllUsers()
        {
            var lstuser = dbCtx.UserDetails.ToList();
            return lstuser;
        }

        public UserDetail GetUserById(int userid)
        {
            var user = dbCtx.UserDetails.Where(o => o.UserId == userid).SingleOrDefault();
            if (user != null)
            {
                return user;
            }
            else
            { 
                return null; 
            }
        }

        public void UpdateUser(UserDetail userdetail, int id)
        {
            var user = dbCtx.UserDetails.Where(o => o.UserId == id).SingleOrDefault();
            if (user != null)
            {
                user.Name = userdetail.Name;
                user.Mobile = userdetail.Mobile;
                user.Email = userdetail.Email;
                user.AdharNumber = userdetail.AdharNumber;
                dbCtx.SaveChanges();
            }
        }

        //booking Data Access layer

        public void AddBooking(Booking booking)
        {
            try
            {
                dbCtx.Add(booking);
                dbCtx.SaveChanges();
            }
            catch (Exception ex)
            {
                throw new Exception("Some database error:" + ex.Message);
            }
        }



        public void DeleteBooking(string booking_id)
        {
            var booking = dbCtx.Bookings.Where(o => o.BookingId == booking_id).SingleOrDefault();
            if (booking != null)
            {
                dbCtx.Bookings.Remove(booking);
                dbCtx.SaveChanges();
            }
        }



        public List<Booking> GetAllBooking()
        {
            var lstbooking = dbCtx.Bookings.ToList();
            return lstbooking;
        }
        public Booking GetBookingById(string booking_id)
        {
            var booking = dbCtx.Bookings.Where(o => o.BookingId == booking_id).SingleOrDefault();
            if (booking != null)
            {
                return booking;
            }
            else
            { return null; }
        }
        public void UpdateBooking(Booking booking, string booking_id)
        {
            var book = dbCtx.Bookings.Where(o => o.BookingId == booking_id).SingleOrDefault();
            if (book != null)
            {
                book.HotelId = booking.HotelId;
                book.CheckIn = booking.CheckIn;
                book.CheckOut = booking.CheckOut;
                book.BookingStatus = booking.BookingStatus;
                book.BookingDate = booking.BookingDate;
                dbCtx.SaveChanges();
            }
        }
        //public void AddBooking(Booking booking)
        //{
        //    throw new NotImplementedException();
        //}

        //public void DeleteBooking(string booking_id)
        //{
        //    throw new NotImplementedException();
        //}

        //public List<Booking> GetAllBooking()
        //{
        //    throw new NotImplementedException();
        //}
        //public Booking GetBookingById(string booking_id)
        //{
        //    throw new NotImplementedException();
        //}

        //public void UpdateBooking(Booking booking, string booking_id)
        //{
        //    throw new NotImplementedException();
        //}


    }
}
