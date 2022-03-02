using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using WebDriverManager;
using WebDriverManager.DriverConfigs.Impl;

namespace Task3.Drivers
{
    public static class Chrome
    {
        private static IWebDriver Instance;

        public static IWebDriver GetInstance()
        {
            if (Instance == null)
            {
                new DriverManager().SetUpDriver(new ChromeConfig(), "98.0.4758.102"); //Версию браузера вставил так как драйвер обновился а сам браузер до 99 версии у меня обновляться не хочет
                var options = new ChromeOptions();
                options.AddArgument("--start-maximized");
                options.AddArgument("--incognito");
                options.AddUserProfilePreference("download.default_directory", ConfigClass.DownloadPath);
                Instance = new ChromeDriver(options);
            }
            return Instance;
        }

        public static void ResetInstance()
        {
            Instance = null;
        }
    }
}
