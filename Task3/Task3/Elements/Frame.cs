using OpenQA.Selenium;
using Task3.Drivers;
using Task3.Util;

namespace Task3.Elements
{
    public class Frame : BaseElement
    {
        public Frame(By locator, string name) : base(locator, name)
        { }

        public Frame SwitchTo()
        {
            LoggerUtil.MakeLog($"Switching to {Name}");
            DriverUtil.SwitchToFrame(GetElement());
            return this;
        }
    }
}
