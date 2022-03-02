using System.IO;

namespace Task3
{
    public static class ConfigClass
    {
        public static readonly string DefaultPath = Directory.GetParent(Directory.GetCurrentDirectory()).Parent.Parent.FullName;
        public static readonly string ConfigPath = DefaultPath + @"\Config.json";
        public static readonly string AlertData = DefaultPath + @"\AlertData.json";
        public static readonly string WebTablesData = DefaultPath + @"\WebTablesData.json";
        public static readonly string BrowserWindowsData = DefaultPath + @"\BrowserWindowsData.json";
        public static readonly string DownloadPath = DefaultPath + @"\Download";
    }
}
