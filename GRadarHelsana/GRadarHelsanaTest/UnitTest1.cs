using System;
using GRadarHelsana;
using Microsoft.VisualStudio.TestTools.UnitTesting;

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
    }
}
