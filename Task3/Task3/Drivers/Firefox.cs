using OpenQA.Selenium;
using OpenQA.Selenium.Firefox;
using WebDriverManager;
using WebDriverManager.DriverConfigs.Impl;

namespace Task3.Drivers
{
    public static class Firefox
    {
        private static IWebDriver Instance;

        public static IWebDriver GetInstance()
        {
            if (Instance == null)
            {
                new DriverManager().SetUpDriver(new FirefoxConfig());
                var options = new FirefoxOptions();
                options.AddArgument("--start-maximized");
                options.AddArgument("--incognito");
                Instance = new FirefoxDriver(options);
            }
            return Instance;
        }

        public static void ResetInstance()
        {
            Instance = null;
        }
    }
}
