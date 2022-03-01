using OpenQA.Selenium;
using Task3.Util;

namespace Task3.Elements
{
    public abstract class BaseElement
    {
        protected By Locator;
        protected string Name;


        public BaseElement(By locator, string name)
        {
            Locator = locator;
            Name = name;
        }

        protected IWebElement GetElement()
        {
            LoggerUtil.MakeLog($"Get {Name}");
            return WaiterUtil.WaitClickible(Locator);
        }

        public string GetText()
        {
            LoggerUtil.MakeLog($"Get text from {Name}");
            return GetElement().Text;
        }

        public string GetAttribute(string Attribute)
        {
            LoggerUtil.MakeLog($"Get attribute from {Name}");
            return GetElement().GetAttribute(Attribute);
        }

        public void Click()
        {
            LoggerUtil.MakeLog($"Click on {Name}");
            GetElement().Click();
        }

        public bool IsVisible()
        {
            LoggerUtil.MakeLog($"Finding an {Name}");
            return WaiterUtil.WaitFindElements(Locator).Count > 0;
        }
    }
}
