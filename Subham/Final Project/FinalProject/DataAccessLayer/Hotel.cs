using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer
{
    public class Hotel
    {
        [Key]
        public int hotel_id { get; set; }
        public string hotel_name { get; set; }

        public string hotel_email { get; set; }

        public string hotel_mobile { get; set; }

        public string gst_number { get; set; }
        public string area { get; set; }

        public string city { get; set; }

        public string state { get; set; }
        public int verified { get; set; }




    }
}
