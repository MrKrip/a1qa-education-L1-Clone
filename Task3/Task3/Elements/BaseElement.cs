using OpenQA.Selenium;
using Task3.Util;

namespace Task3.Elements
{
    public abstract class BaseElement
    {
        private string Xpath;
        private string Name;

        public BaseElement(string xpath,string name)
        {
            Xpath = xpath;
            Name = name;
        }

        private IWebElement GetElement()
        {
            return WaiterUtil.WaitFindElement(By.XPath(Xpath));
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
