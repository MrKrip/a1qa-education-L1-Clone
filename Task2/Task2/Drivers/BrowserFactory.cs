using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Firefox;
using System.Collections.Generic;
using WebDriverManager;
using WebDriverManager.DriverConfigs.Impl;

namespace Task2.Drivers
{
    public static class BrowserFactory
    {
        private static IDictionary<string, IWebDriver> Drivers = new Dictionary<string, IWebDriver>();

        public static IWebDriver GetInstance(string browserName)
        {
            switch (browserName)
            {
                case "Firefox":
                    {
                        if (!Drivers.ContainsKey(browserName))
                        {
                            new DriverManager().SetUpDriver(new FirefoxConfig());
                            var options = new FirefoxOptions();
                            options.AddArgument("--start-maximized");
                            options.AddArgument("--incognito");
                            IWebDriver driver = new FirefoxDriver(options);
                            Drivers.Add("Firefox", driver);
                        }
                        return Drivers["Firefox"];
                    }
                case "Chrome":
                    {
                        if (!Drivers.ContainsKey(browserName))
                        {
                            new DriverManager().SetUpDriver(new ChromeConfig());
                            var options = new ChromeOptions();
                            options.AddArgument("--start-maximized");
                            options.AddArgument("--incognito");
                            IWebDriver driver = new ChromeDriver(options);
                            Drivers.Add("Chrome", driver);
                        }
                        return Drivers["Chrome"];
                    }
                default:
                    {
                        if (!Drivers.ContainsKey(browserName))
                        {
                            new DriverManager().SetUpDriver(new ChromeConfig());
                            var options = new ChromeOptions();
                            options.AddArgument("--start-maximized");
                            options.AddArgument("--incognito");
                            IWebDriver driver = new ChromeDriver(options);
                            Drivers.Add("Chrome", driver);
                        }
                        return Drivers["Chrome"];
                    }
            }
        }

        public static void ClearInstance(string browserName)
        {
            Drivers.Remove(browserName);
        }

        public static void GoToPage(string StrURL, string browserName)
        {
            GetInstance(browserName).Navigate().GoToUrl(StrURL);
        }
    }
}
