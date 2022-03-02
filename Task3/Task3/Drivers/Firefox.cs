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
                options.SetPreference("browser.download.folderList",2);
                options.SetPreference("browser.download.dir",ConfigClass.DownloadPath);
                options.SetPreference("browser.helperApps.neverAsk.saveToDosk","image/jpeg");
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
