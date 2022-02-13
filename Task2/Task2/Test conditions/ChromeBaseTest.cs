using NUnit.Framework;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.IO;
using Task2.Drivers;
using Task2.Util;

namespace Task2.Test_conditions
{
    public class ChromeBaseTest
    {
        protected IWebDriver driver;
        protected Dictionary<string, string> Config;

        [SetUp]
        public void Setup()
        {
            driver = BrowserFactory.GetInstance("Chrome");
            Config = ParseJSON.GetConfigFile(Directory.GetParent(Directory.GetCurrentDirectory()).Parent.Parent.FullName + @"\Config.json");
            WaiterUtil.SetWaiter(driver, Int32.Parse(Config["WaitTime"]));
        }
        [TearDown]
        public void CleanUp()
        {
            BrowserFactory.ClearInstance("Chrome");
            driver.Quit();
        }
    }
}
