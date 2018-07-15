using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using EmuLoader.Business;

namespace Tests
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestMethod1()
        {
            var romname = RomFunctions.TrimRomName("Dream Basketball - Dunk & Hoop (J)");
            var imagename = RomFunctions.TrimRomName("Dream Basketball Dunk and Hoop.jpg");

            Assert.AreEqual(romname, imagename);
        }
    }
}
