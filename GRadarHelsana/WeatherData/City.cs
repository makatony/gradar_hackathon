using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Web;

namespace WeatherData
{
    [DataContract]
    public class City
    {
        [DataMember(Name = "swiss_canton_iso")]
        public string swiss_canton_iso { get; set; }
        [DataMember(Name = "openweathermap_city_id")]
        public int openweathermap_city_id { get; set; }

        public Coord coord { get; set; }
    }

    public class CityList
    {
        public City cities { get; set; }

    }


    public class Coord
    {
        public double lon { get; set; }
        public double lat { get; set; }
    }

}