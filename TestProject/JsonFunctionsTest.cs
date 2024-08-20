using EmuLoader.Core.Business;

namespace Tests
{
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

        public void ParseTest()
        {
            var result = JsonFunctions.ParseJson(json);

            Assert.IsNotNull(result);
        }

        public void ParseNullTest()
        {
            var result = JsonFunctions.ParseJson(jsonNull);

            Assert.IsNotNull(result);
        }

        public void ParseChildrenTest()
        {
            var result = JsonFunctions.ParseJson(jsonChildren);

            Assert.IsNotNull(result);
        }

        public void GetValueTest()
        {
            var result = JsonFunctions.GetJsonValue(json, "game");

            Assert.IsNotNull(result);
        }

        public void GetValueNumberTest()
        {
            var result = JsonFunctions.GetJsonValue(jsonNull, "age");

            Assert.IsNotNull(result);
        }

        public void GetNullTest()
        {
            var result = JsonFunctions.GetJsonValue(jsonNull, "car");

            Assert.IsNull(result);
        }
    }
}
