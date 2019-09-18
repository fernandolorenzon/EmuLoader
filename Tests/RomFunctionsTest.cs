using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using EmuLoader.Core.Business;
using EmuLoader.Core.Classes;

namespace Tests
{
    [TestClass]
    public class RomFunctionsTest
    {
        [TestMethod]
        public void TestMethod1()
        {
            var romname = RomFunctions.TrimRomName("Battletoads and Double Dragon");
            var imagename = RomFunctions.TrimRomName("Battletoads & Double Dragon");

            Assert.AreEqual(romname, imagename);
        }

        [TestMethod]
        public void MatchImage_TestMethod()
        {
            Dictionary<string, Region> imageRegion = new Dictionary<string, Region>();
            var item = @"D:\User\Downloads\1 - Super Famicom Boxart1\4 Nin Shogi.jpg";
            imageRegion.Add(RomFunctions.GetFileName(item), RomFunctions.DetectRegion(item));
            string imageFoundPath;
            var found = RomFunctions.MatchImages(new string[] { item }, imageRegion, "4-nin Shougi", out imageFoundPath);

            Assert.IsTrue(found);
        }
    }
}
