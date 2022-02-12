using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using WebDriverManager;
using WebDriverManager.DriverConfigs.Impl;

namespace Task2.Drivers
{
    public static class Chrome
    {
        private static IWebDriver Instance;

        public static IWebDriver GetInstance()
        {
            if(Instance==null)
            {
                new DriverManager().SetUpDriver(new ChromeConfig());
                var options =new ChromeOptions();
                options.AddArgument("--start-maximized");
                options.AddArgument("--incognito");
                Instance = new ChromeDriver(options);
            }
            return Instance;
        }

        public static void GoToPage(string StrURL)
        {
            GetInstance().Navigate().GoToUrl(StrURL);
        }
    }
}
