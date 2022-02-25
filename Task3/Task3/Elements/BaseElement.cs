using OpenQA.Selenium;
using Task3.Util;

namespace Task3.Elements
{
    public abstract class BaseElement
    {
        protected string Xpath;
        protected string Name;

        public BaseElement(string xpath, string name)
        {
            Xpath = xpath;
            Name = name;
        }

        protected IWebElement GetElement()
        {
            return WaiterUtil.WaitClickible(By.XPath(Xpath));
        }

        public string GetText()
        {
            return GetElement().Text;
        }

        public string GetAttribute(string Attribute)
        {
            return GetElement().GetAttribute(Attribute);
        }

        public void Click()
        {
            GetElement().Click();
        }

        public bool IsVisible()
        {
            return WaiterUtil.WaitFindElements(By.XPath(Xpath)).Count > 0;
        }
    }
}
