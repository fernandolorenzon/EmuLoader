using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using EmuLoader.Business;
using System.Collections.Generic;
using EmuLoader.Classes;

namespace Tests
{
    [TestClass]
    public class ApiTest
    {
        [TestMethod]
        public void GetGamesListJSONByPlatform_Test()
        {
            XML.LoadXml();
            Genre.Fill();
            var games = APIFunctions.GetGamesListJSONByPlatform("6");

            Assert.IsNotNull(games);
        }
        [TestMethod]
        public void GetGamesListByPlatform_Test()
        {
            XML.LoadXml();
            Genre.Fill();
            var games = APIFunctions.GetGamesListByPlatform("6", "");

            Assert.IsNotNull(games);
        }

        [TestMethod]
        public void GetGameByName_Test()
        {
            XML.LoadXml();
            Genre.Fill();
            var games = APIFunctions.GetGameByName("136", "Super Mario World");

            Assert.IsNotNull(games);
        }

        [TestMethod]
        public void GetGameDetails_Test()
        {
            XML.LoadXml();
            Genre.Fill();
            var games = APIFunctions.GetGameDetails("136");

            Assert.IsNotNull(games);
        }

        [TestMethod]
        public void GetGameArtUrls_Test()
        {
            XML.LoadXml();
            Genre.Fill();
            string box, title, gameplay = "";
            var result = APIFunctions.GetGameArtUrls("136", out box, out title, out gameplay);

            Assert.IsTrue(result);
            Assert.IsNotNull(box);
            Assert.IsNotNull(title);
            Assert.IsNotNull(gameplay);
        }
    }
}
