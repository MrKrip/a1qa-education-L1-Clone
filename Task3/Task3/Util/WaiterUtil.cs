using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.WaitHelpers;
using System;
using System.Collections.ObjectModel;
using System.IO;
using Task3.Drivers;

namespace Task3.Util
{
    public static class WaiterUtil
    {
        private static int Time = Int32.Parse(ParseJSON.GetConfigFile(Directory.GetParent(Directory.GetCurrentDirectory()).Parent.Parent.FullName + @"\Config.json")["WaitTime"]);

        public static IWebElement WaitFindElement(By Element)
        {
            return new WebDriverWait(BrowserFactory.GetInstance(), TimeSpan.FromSeconds(Time)).Until(e => e.FindElement(Element));
        }

        public static ReadOnlyCollection<IWebElement> WaitFindElements(By Element)
        {
            return new WebDriverWait(BrowserFactory.GetInstance(), TimeSpan.FromSeconds(Time)).Until(e => e.FindElements(Element));
        }

        public static void WaitClickible(By Element)
        {
            new WebDriverWait(BrowserFactory.GetInstance(), TimeSpan.FromSeconds(Time)).Until(ExpectedConditions.ElementToBeClickable(Element));
        }

        public static void WaitAllElementsVisible(By Elements)
        {
            new WebDriverWait(BrowserFactory.GetInstance(), TimeSpan.FromSeconds(Time)).Until(ExpectedConditions.VisibilityOfAllElementsLocatedBy(Elements));
        }
        public static void WaitElementVisible(By Elements)
        {
            new WebDriverWait(BrowserFactory.GetInstance(), TimeSpan.FromSeconds(Time)).Until(ExpectedConditions.ElementIsVisible(Elements));
        }

        public static IAlert WaitAlert()
        {
            return new WebDriverWait(BrowserFactory.GetInstance(), TimeSpan.FromSeconds(Time)).Until(ExpectedConditions.AlertIsPresent());
        }
    }
}
