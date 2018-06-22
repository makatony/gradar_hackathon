﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WeatherData
{
    public class City
    {
        public int id { get; set; }
        public string name { get; set; }
        public string country { get; set; }
        public Coord coord { get; set; }
    }

    public class Coord
    {
        public double lon { get; set; }
        public double lat { get; set; }
    }

}