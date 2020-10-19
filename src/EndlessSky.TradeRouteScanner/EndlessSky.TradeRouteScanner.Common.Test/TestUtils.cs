using System;
using System.Collections.Generic;
using System.IO;
using System.Reflection;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;

namespace EndlessSky.TradeRouteScanner.Common.Test
{
    public static class TestUtils
    {
        public static string JsonSerialize(object obj)
        {
            return Newtonsoft.Json.JsonConvert.SerializeObject(obj);
        }

        public static string BinarySerialize(object obj)
        {
            using (var stream = new MemoryStream())
            {
                var formatter = new BinaryFormatter();
                formatter.Serialize(stream, obj);
                stream.Flush();
                stream.Position = 0;
                return Convert.ToBase64String(stream.ToArray());
            }
        }

        public static Stream LoadResourceStream(string filename)
        {
            Assembly thisAssembly = Assembly.GetExecutingAssembly();

            string path = "EndlessSky.TradeRouteScanner.Common.Test";

            return thisAssembly.GetManifestResourceStream(path + "." + filename);
        }

        public static TextReader LoadResource(string filename)
        {
            Assembly thisAssembly = Assembly.GetExecutingAssembly();

            string path = "EndlessSky.TradeRouteScanner.Common.Test";

            return new StreamReader(thisAssembly.GetManifestResourceStream(path + "." + filename));
        }
    }
}
