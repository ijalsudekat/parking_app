using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfApp1.Models
{
    public class FeesModel
    {
        private int parkFeesId;

        [JsonProperty("parkFeesId")]
        public int ParkFeesId
        {
            get { return parkFeesId; }
            set { parkFeesId = value; }
        }

        private int parkFeesValue;
        [JsonProperty("parkFeesValue")]
        public int FeesValue
        {
            get { return parkFeesValue; }
            set { parkFeesValue = value; }
        }


    }
}
