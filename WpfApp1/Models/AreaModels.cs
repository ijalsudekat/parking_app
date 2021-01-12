using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfApp1.Models
{
    public class AreaModel
    {
       
        private int areaId;

        [JsonProperty("areaId")]
        public int AreaId
        {
            get { return areaId; }
            set { areaId = value; }
        }

        private int? areaNumber;

        [JsonProperty("areaNumber")]
        public int? AreaNumber
        {
            get { return areaNumber; }
            set {

                if (!value.Equals(areaNumber))
                {
                    areaNumber = null;
                }
                areaNumber = value;

            }
        }

        private int areaSts;

        [JsonProperty("areaSts")]
        public int AreaSts
        {
            get { return areaSts; }
            set { areaSts = value; }
        }

        private int feesVal;

        [JsonProperty("fessVal")]
        public int ParkFeesValue
        {
            get { return feesVal; }
            set { feesVal = value; }
        }

        private int kategoriId;
        [JsonProperty("areaKategoriId")]
        public int KategoriId
        {
            get { return kategoriId; }
            set { kategoriId = value; }
        }

        private int parkFessId;
        [JsonProperty("areaParkingFeesId")]
        public int ParkFeesId
        {
            get { return parkFessId; }
            set { parkFessId = value; }
        }



        private string kategori;

        [JsonProperty("kategori")]
        public string Kategori
        {
            get { return kategori; }
            set { kategori = value; }
        }

        private DateTime createdAt;

        [JsonProperty("areaCreatedAt")]
        public DateTime CreatedAt
        {
            get { return createdAt; }
            set {
                createdAt = value;
            }
        }

    }
}
