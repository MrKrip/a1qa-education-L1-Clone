using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task3.Drivers
{
    public static class DriverUtil
    {
        public static void GoToPage(string StrURL)
        {
            BrowserFactory.GetInstance().Navigate().GoToUrl(StrURL);
        }

        public static void Quit()
        {
            BrowserFactory.GetInstance().Quit();
        }

        public static IAlert SwitchToAlert()
        {
            return BrowserFactory.GetInstance().SwitchTo().Alert();
        }

        public static void SwitchToDefault()
        {
            BrowserFactory.GetInstance().SwitchTo().DefaultContent();
        }

        public static void SwitchToFrame(IWebElement el)
        {
            BrowserFactory.GetInstance().SwitchTo().Frame(el);
        }

        public static void SwitchToFrame(int el)
        {
            BrowserFactory.GetInstance().SwitchTo().Frame(el);
        }
    }
}
