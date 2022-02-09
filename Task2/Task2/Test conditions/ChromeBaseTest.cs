using NUnit.Framework;
using OpenQA.Selenium;
using System.Collections.Generic;
using System.IO;
using Task2.Drivers;
using Task2.Pages;
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
            driver = Chrome.GetInstance();
            Config = ParseJSON.GetConfigFile(Directory.GetParent(Directory.GetCurrentDirectory()).Parent.Parent.FullName+@"\Config.json");
        }
        [TearDown]
        public void CleanUp()
        {
            driver.Quit();
        }
    }
}
