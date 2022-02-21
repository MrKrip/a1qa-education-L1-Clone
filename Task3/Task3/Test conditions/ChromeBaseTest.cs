using NUnit.Framework;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.IO;
using Task3.Drivers;
using Task3.Util;

namespace Task2.Test_conditions
{
    public class ChromeBaseTest
    {
        protected IWebDriver driver;
        protected Dictionary<string, string> Config;

        [SetUp]
        public void Setup()
        {
            driver = BrowserFactory.GetInstance();
            Config = ParseJSON.GetConfigFile(Directory.GetParent(Directory.GetCurrentDirectory()).Parent.Parent.FullName + @"\Config.json");
        }
        [TearDown]
        public void CleanUp()
        {
            driver.Quit();
        }
    }
}
