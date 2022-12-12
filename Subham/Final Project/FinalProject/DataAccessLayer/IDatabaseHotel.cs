using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer
{
    public interface IDatabaseHotel
    {
        void AddHotel(Hotel hotel);
        void DeleteHotel(int hotel_id);
        void UpdateHotel(Hotel hotel);

        List<Hotel> GetAllHotels();

        Hotel GetHotelById(int hotel_id);

      
    }
}
