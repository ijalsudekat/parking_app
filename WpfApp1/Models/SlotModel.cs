using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfApp1.Models
{
    public class SlotModel
    {
        public int par_slot_id { get; set; }
        public string park_slot_status { get; set; }
        public int park_slot_sts { get; set; }
        public int area_number { get; set; }
        public int kat_number { get; set; }
        public string kat_area_name { get; set; }
        public int park_slot_user_id { get; set; }
        public string user_username { get; set; }
        public string park_car_license { get; set; }
    }
}
