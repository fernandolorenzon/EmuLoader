using EmuLoader.Core.Business;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Tests
{
    [TestClass]
    public class JsonFunctionsTest
    {
        string json = "{" +
                        "\"game\":\"contra\"," +
                        "\"id\":\"9975\"" +
                       "}";

        string jsonNull = "{ \"name\":\"John\", \"age\":30, \"car\":null }";

        string jsonChildren = "{" +
                                    "\"name\":\"John\"," +
                                    "\"age\":30," +
                                    "\"cars\": {" +
                                        "\"car1\":\"Ford\"," +
                                        "\"car2\":\"BMW\"," +
                                        "\"car3\":\"Fiat\"" +
                                    "}" +
                                "}";

        [TestMethod]
        public void ParseTest()
        {
            var result = JsonFunctions.ParseJson(json);

            Assert.IsNotNull(result);
        }

        [TestMethod]
        public void ParseNullTest()
        {
            var result = JsonFunctions.ParseJson(jsonNull);

            Assert.IsNotNull(result);
        }

        [TestMethod]
        public void ParseChildrenTest()
        {
            var result = JsonFunctions.ParseJson(jsonChildren);

            Assert.IsNotNull(result);
        }

        [TestMethod]
        public void GetValueTest()
        {
            var result = JsonFunctions.GetJsonValue(json, "game");

            Assert.IsNotNull(result);
        }

        [TestMethod]
        public void GetValueNumberTest()
        {
            var result = JsonFunctions.GetJsonValue(jsonNull, "age");

            Assert.IsNotNull(result);
        }

        [TestMethod]
        public void GetNullTest()
        {
            var result = JsonFunctions.GetJsonValue(jsonNull, "car");

            Assert.IsNull(result);
        }
    }
}
