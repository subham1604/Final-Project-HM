using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer
{
    [Keyless]
    public class Room
    {
        public int hotel_id { get; set; }
        public string room_type { get; set; }
        public int no_of_rooms { get; set; }
        public float price { get; set; }
    }
}
