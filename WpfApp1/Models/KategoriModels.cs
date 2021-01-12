using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfApp1.Models
{
    public class KategoriModels
    {

        private int _katareaid;

        [JsonProperty("katiAreaId")]
        public int KategoriId
        {
            get { return _katareaid; }
            set { _katareaid = value; }
        }

        private string _kathall;

        [JsonProperty("katAreaName")]
        public string KategoriHall
        {
            get { return _kathall; }
            set { _kathall = value; }
        }


    }
}
