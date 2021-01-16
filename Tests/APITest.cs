using EmuLoader.Core.Business;
using EmuLoader.Core.Classes;
using Microsoft.VisualStudio.TestTools.UnitTesting;

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
            Platform.Fill();
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
            var access = "";
            var games = APIFunctions.GetGameByName("136", "Super Mario World", out access);

            Assert.IsNotNull(games);
        }

        [TestMethod]
        public void GetGameDetails_Test()
        {
            XML.LoadXml();
            Genre.Fill();
            var access = "";
            var games = APIFunctions.GetGameDetails("136", new Platform(), out access);

            Assert.IsNotNull(games);
        }

        [TestMethod]
        public void GetGameArtUrls_Test()
        {
            XML.LoadXml();
            Genre.Fill();
            string box, title, gameplay = "";
            var access = "";
            var result = APIFunctions.GetGameArtUrls("136", out box, out title, out gameplay, out access);

            Assert.IsTrue(result);
            Assert.IsNotNull(box);
            Assert.IsNotNull(title);
            Assert.IsNotNull(gameplay);
        }
    }
}
