using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfApp1.Models
{
    public class SlotModel
    {

       
        private int _par_slot_id;

        public int par_slot_id
        {
            get { return _par_slot_id; }
            set { _par_slot_id = value; }
        }

        private string _park_slot_status;

        public string park_slot_status
        {
            get { return _park_slot_status; }
            set { _park_slot_status = value; }
        }

        private int _park_slot_sts;

        public int park_slot_sts
        {
            get { return _park_slot_sts; }
            set { _park_slot_sts = value; }
        }

        private int _area_number;

        public int area_number
        {
            get { return _area_number; }
            set { _area_number = value; }
        }

        private int _kat_number;

        public int kat_number
        {
            get { return _kat_number; }
            set { _kat_number = value; }
        }

        private string _kat_area_name;

        public string kat_area_name
        {
            get { return _kat_area_name; }
            set { _kat_area_name = value; }
        }

        private int? _park_slot_user_id;

        public int? park_slot_user_id
        {
            get { return _park_slot_user_id; }
            set { _park_slot_user_id = value; }
        }

        private string _user_username;

        public string user_username
        {
            get { return _user_username; }
            set { _user_username = value; }
        }

        private string _park_car_license;

        public string park_car_license
        {
            get { return _park_car_license; }
            set { _park_car_license = value; }
        }

    }
}
