using System;
using GRadarHelsana;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using WeatherData;

namespace GRadarHelsanaTest
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestBAGAdapter()
        {
            BAG_Adapter bag = new BAG_Adapter();
            if (!bag.GetDataFromBAG())
            {
                Assert.Fail();
            }
        }


        [TestMethod]
        public void TestCityMapper()
        {
            WeatherConnector wc = new WeatherConnector();

            //if (wc.GenerateCityCodes().Count <= 0)
            //{
            //    Assert.Fail();
            //}
        }

        [TestMethod]
        public void TestCityWeatherAPI()
        {
            WeatherConnector wc = new WeatherConnector();

            try
            {
                wc.GetWeatherData("ZH");
            }
            catch (Exception ex)
            {
                Assert.Fail();
            }
        }
    }



}
