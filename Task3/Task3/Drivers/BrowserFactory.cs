using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Firefox;
using System;
using System.Collections.Generic;
using System.IO;
using Task3.Util;
using WebDriverManager;
using WebDriverManager.DriverConfigs.Impl;

namespace Task3.Drivers
{
    public static class BrowserFactory
    {
        private static IWebDriver Instatnce;

        public static IWebDriver GetInstance()
        {
            string browserName = ParseJSON.GetConfigFile(Directory.GetParent(Directory.GetCurrentDirectory()).Parent.Parent.FullName + @"\Config.json")["BrowserName"];
            switch (browserName)
            {
                case "Firefox":
                    {
                        if (Instatnce==null)
                        {
                            new DriverManager().SetUpDriver(new FirefoxConfig());
                            var options = new FirefoxOptions();
                            options.AddArgument("--start-maximized");
                            options.AddArgument("--incognito");
                            Instatnce = new FirefoxDriver(options);
                        }
                        return Instatnce;
                    }
                case "Chrome":
                    {
                        if (Instatnce == null)
                        {
                            new DriverManager().SetUpDriver(new ChromeConfig());
                            var options = new ChromeOptions();
                            options.AddArgument("--start-maximized");
                            options.AddArgument("--incognito");
                            Instatnce = new ChromeDriver(options);
                        }
                        return Instatnce;
                    }
                default:
                    {
                        throw new NotImplementedException();
                    }
            }
        }

        public static void GoToPage(string StrURL, string browserName)
        {
            GetInstance().Navigate().GoToUrl(StrURL);
        }
    }
}
