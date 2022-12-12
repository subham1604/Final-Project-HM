using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer
{
    public class HotelDAL : IDatabaseHotel
    {
        private DBContext dbCtx;
        public HotelDAL(DBContext dbCtx)
        {
            this.dbCtx = dbCtx;
        }
        public void AddHotel(Hotel hotel)
        {
            dbCtx.Add(hotel);
            dbCtx.SaveChanges();
        }

        public void DeleteHotel(int hotel_id)
        {
            //find the record
            var htl = dbCtx.hotel_description.
                Where(o=>o.hotel_id == hotel_id)
                .SingleOrDefault();

            //delete if found 
            if(htl != null)
            {
                dbCtx.hotel_description.Remove(htl);
                dbCtx.SaveChanges();
            }
        }

        public List<Hotel> GetAllHotels()
        {
            var lsthtls = dbCtx.hotel_description.ToList();
            return lsthtls;
        }

        public Hotel GetHotelById(int hotel_id)
        {
            //find the record
            var htl = dbCtx.hotel_description.
                Where(o => o.hotel_id == hotel_id)
                .SingleOrDefault();

            if(htl != null)
            {
                return htl;
            }
            else
            {
                return null;
            }
        }

        public void UpdateHotel(Hotel hotel)
        {
            var htl = dbCtx.hotel_description.Where(o => o.hotel_id == hotel.hotel_id).SingleOrDefault();
            if(htl != null)
            {
                htl.hotel_name = hotel.hotel_name;
                htl.hotel_email = hotel.hotel_email;
                htl.hotel_mobile = hotel.hotel_mobile;
                htl.gst_number = hotel.gst_number;
                htl.area = hotel.area;
                htl.city = hotel.city;
                htl.state = hotel.state;
                htl.verified = hotel.verified;
            }
        }
    }
}
