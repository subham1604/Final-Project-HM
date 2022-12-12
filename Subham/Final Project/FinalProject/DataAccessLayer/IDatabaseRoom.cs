using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer
{
    public interface IDatabaseRoom
    {
        void AddRoomByHotelId(Room room);
        void DeleteRoomByHotelIdAndRoomType(int hotel_id);

        List<Room> GetAllRoomByHotelId(int hotel_id);

    }
}
