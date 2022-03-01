using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Task3.Util;

namespace Task3
{
    public static class Config
    {
        public static string browserName = ParseJSON.GetConfigFile(Directory.GetParent(Directory.GetCurrentDirectory()).Parent.Parent.FullName + @"\Config.json")["BrowserName"];

    }
}
