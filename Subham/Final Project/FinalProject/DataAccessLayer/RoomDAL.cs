using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer
{
    public class RoomDAL : IDatabaseRoom
    {
        private DBContext dbCtx;

        public RoomDAL(DBContext dbCtx)
        {
            this.dbCtx = dbCtx;
        }

        public void AddRoomByHotelId(Room room)
        {
            dbCtx.Add(room);
            dbCtx.SaveChanges();
        }

        public void DeleteRoomByHotelIdAndRoomType(int hotel_id)
        {
            //find the record
            var rm = dbCtx.room_description.Where(
                o => o.hotel_id == hotel_id 
                ).SingleOrDefault();

            //delete if found
            if(rm != null)
            {
                dbCtx.room_description.Remove(rm);
                dbCtx.SaveChanges();
            }
        }


        public List<Room> GetAllRoomByHotelId(int hotel_id)
        {

            var rmlist = dbCtx.room_description.
                Where(o => o.hotel_id == hotel_id).ToList();

            
                return rmlist;
           
          
            
           
        }
    }
}
