using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Runtime.Serialization.Json;
using System.Web;

namespace WeatherData
{
    public class WeatherConnector
    {
        List<City> Cities = new List<City>();

        string URL = "http://api.openweathermap.org/data/2.5/forecast?id=2658370&appid=05a8a433c2eed7226b5bea14c27d4050";

        public WeatherConnector()
        {
            Cities = GenerateCityCodes();

        }

        public void GetWeatherData(string location)
        {
            HttpWebRequest request = (HttpWebRequest)WebRequest.Create(URL);
            DataContractJsonSerializer ser = new DataContractJsonSerializer(typeof(WeatherDetails));

            request.AutomaticDecompression = DecompressionMethods.GZip | DecompressionMethods.Deflate;

            using (HttpWebResponse response = (HttpWebResponse)request.GetResponse())
            using (Stream stream = response.GetResponseStream())
            {
               
                WeatherDetails weather = (WeatherDetails)ser.ReadObject(stream);
            }

        }

        private List<City> GenerateCityCodes()
        {
            throw new NotImplementedException();
        }
    }
}