namespace BookingAPI.Models
{
    public interface IDatabase
    {
        void AddUser(UserDetail user);
        void DeleteUser(int userId);
        void UpdateUser(UserDetail user, int id);
        UserDetail GetUserById(int userid);
        List<UserDetail> GetAllUsers();

        void AddBooking(Booking booking);
        void DeleteBooking(string booking_id);
        void UpdateBooking(Booking booking, string booking_id);
        Booking GetBookingById(string booking_id);
        List<Booking> GetAllBooking();
    }
}
