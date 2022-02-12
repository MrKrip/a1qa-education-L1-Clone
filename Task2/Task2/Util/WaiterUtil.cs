using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.WaitHelpers;
using System;
using System.Collections.ObjectModel;

namespace Task2.Util
{
    public static class WaiterUtil
    {
        private static WebDriverWait wait;

        public static void SetWaiter(IWebDriver driver,int Time)
        {
            wait = new WebDriverWait(driver, TimeSpan.FromSeconds(Time));
        }
        public static IWebElement WaitFindElement(By Element)
        {
            return wait.Until(e => e.FindElement(Element));
        }

        public static ReadOnlyCollection<IWebElement> WaitFindElements(By Element)
        {
            return wait.Until(e => e.FindElements(Element));
        }

        public static void WaitClickible(By Element)
        {
            wait.Until(ExpectedConditions.ElementToBeClickable(Element));
        }

        public static void WaitAllElementsVisible(By Elements)
        {
            wait.Until(ExpectedConditions.VisibilityOfAllElementsLocatedBy(Elements));
        }
        public static void WaitElementVisible(By Elements)
        {
            wait.Until(ExpectedConditions.ElementIsVisible(Elements));
        }
    }
}
