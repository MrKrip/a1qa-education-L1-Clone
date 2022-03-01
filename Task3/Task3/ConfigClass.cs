using System.IO;

namespace Task3
{
    public static class ConfigClass
    {
        public static readonly string ConfigPath = Directory.GetParent(Directory.GetCurrentDirectory()).Parent.Parent.FullName + @"\Config.json";
        public static readonly string AlertData = Directory.GetParent(Directory.GetCurrentDirectory()).Parent.Parent.FullName + @"\AlertData.json";
        public static readonly string WebTablesData = Directory.GetParent(Directory.GetCurrentDirectory()).Parent.Parent.FullName + @"\WebTablesData.json";
        public static readonly string BrowserWindowsData = Directory.GetParent(Directory.GetCurrentDirectory()).Parent.Parent.FullName + @"\BrowserWindowsData.json";
    }
}
