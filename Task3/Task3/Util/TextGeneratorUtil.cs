using System.Linq;
using System.Security.Cryptography;

namespace Task3.Util
{
    public static class TextGeneratorUtil
    {
        public static string GenerteText()
        {
            string chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789";
            int lenght = RandomNumberGenerator.GetInt32(0, chars.Length);
            string text = new string(Enumerable.Repeat(chars, lenght).Select(s => s[RandomNumberGenerator.GetInt32(0, chars.Length)]).ToArray());
            return text;
        }
    }
}
