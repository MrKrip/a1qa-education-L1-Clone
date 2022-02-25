using System;
using System.IO;

namespace Task3.Util
{
    public static class LoggerUtil
    {
        private static string Path;

        public static void InitLoger()
        {
            if(Path==null)
            {
                Path= Directory.GetParent(Directory.GetCurrentDirectory()).Parent.Parent.FullName + $@"\Logs\{DateTime.Now.ToString("dd_MM_yy_H_mm_ss")}_Log.txt";
            }
        }
        public static void MakeLog(string log)
        {
            File.AppendAllText(Path, log+"\n");
        }
    }
}
