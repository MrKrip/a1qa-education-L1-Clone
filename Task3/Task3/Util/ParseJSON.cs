using Newtonsoft.Json;
using System.Collections.Generic;
using System.IO;

namespace Task3.Util
{
    public static class ParseJSON
    {
        public static Dictionary<string, string> GetConfigFile(string path)
        {
            var json = File.ReadAllText(path);
            return JsonConvert.DeserializeObject<Dictionary<string, string>>(json);
        }

        public static T GetDataFile<T>(string path)
        {
            var json = File.ReadAllText(path);
            return JsonConvert.DeserializeObject<T>(json);
        }
    }
}
