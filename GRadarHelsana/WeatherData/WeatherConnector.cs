using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Runtime.Serialization.Json;
using System.Web;
using System.Web.Script.Serialization;

namespace WeatherData
{
    public class WeatherConnector
    {
        List<City> Cities = new List<City>();

        string URL = "http://api.openweathermap.org/data/2.5/forecast?";
        string URLParams = "id=#city_id#&appid=#APP_ID#";

        public WeatherConnector()
        {
            Cities = GenerateCityCodes();

        }

        public void GetWeatherData(string location)
        {
            HttpWebRequest request = (HttpWebRequest)WebRequest.Create(URL + SetParams(location));
            DataContractJsonSerializer ser = new DataContractJsonSerializer(typeof(WeatherDetails));

            request.AutomaticDecompression = DecompressionMethods.GZip | DecompressionMethods.Deflate;

            using (HttpWebResponse response = (HttpWebResponse)request.GetResponse())
            using (Stream stream = response.GetResponseStream())
            {

                WeatherDetails weather = (WeatherDetails)ser.ReadObject(stream);
            }

        }

        private string SetParams(string location)
        {
            URLParams = URLParams.Replace("#APP_ID#", "05a8a433c2eed7226b5bea14c27d4050");
            URLParams = URLParams.Replace("#city_id#", GetCityCode(location).ToString());

            return URLParams;
        }

        internal int GetCityCode(string canton)
        {
            City c = Cities.FirstOrDefault(x => x.swiss_canton_iso == canton);

            return c.openweathermap_city_id;
        }


        internal List<City> GenerateCityCodes()
        {
            using (StreamReader r = new StreamReader("..\\..\\..\\WeatherData\\File\\CityCode.json"))
            {
                string json = r.ReadToEnd();

                JavaScriptSerializer ser = new JavaScriptSerializer();

                var Cities = ser.Deserialize<List<City>>(json);

                return Cities;
            }
        }
    }
}