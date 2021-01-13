using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfApp1.Models
{
    public class HistoryModels
    {
        private int _hist_id;

        public int hist_id
        {
            get { return _hist_id; }
            set { _hist_id = value; }
        }

        private string _hist_kode;

        public string hist_kode
        {
            get { return _hist_kode; }
            set { _hist_kode = value; }
        }

        private string _hist_area_id;

        public string hist_area_id
        {
            get { return _hist_area_id; }
            set { _hist_area_id = value; }
        }

        private DateTime? _hist_out;

        public DateTime? hist_out
        {
            get { return _hist_out; }
            set { _hist_out = value; }
        }

        private DateTime _hist_in;

        public DateTime hist_in
        {
            get { return _hist_in; }
            set { _hist_in = value; }
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

        private string _iser_fullname;

        public string user_fullname
        {
            get { return _iser_fullname; }
            set { _iser_fullname = value; }
        }

        private string _user_username;

        public string user_username
        {
            get { return _user_username; }
            set { _user_username = value; }
        }

        private int _user_id;

        public int user_id
        {
            get { return _user_id; }
            set { _user_id = value; }
        }

        private int _hist_sts;

        public int hist_sts
        {
            get { return _hist_sts; }
            set { _hist_sts = value; }
        }

        private DateTime _hist_created_atd;

        public DateTime hist_created_atd
        {
            get { return _hist_created_atd; }
            set { _hist_created_atd = value; }
        }


    }
}
