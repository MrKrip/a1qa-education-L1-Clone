﻿using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using WebDriverManager;
using WebDriverManager.DriverConfigs.Impl;

namespace Task2.Drivers
{
    sealed class Chrome
    {
        private static IWebDriver Instance;

        public IWebDriver GetInstance()
        {
            if(Instance==null)
            {
                new DriverManager().SetUpDriver(new ChromeConfig());
                var options =new ChromeOptions();
                options.AddArgument("--incognito");
                Instance = new ChromeDriver(options);
            }
            return Instance;
        }
    }
}
