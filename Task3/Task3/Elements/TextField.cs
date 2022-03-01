using OpenQA.Selenium;
using Task3.Util;

namespace Task3.Elements
{
    public class TextField : BaseElement
    {
        public TextField(By locator, string name) : base(locator, name)
        { }

        public void SendKeys(string content)
        {
            LoggerUtil.MakeLog($"Sending keys to {Name}");
            GetElement().SendKeys(content);
        }
    }
}
