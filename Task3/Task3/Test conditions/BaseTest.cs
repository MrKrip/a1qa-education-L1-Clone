using NUnit.Framework;
using OpenQA.Selenium;
using System.Collections.Generic;
using System.IO;
using Task3;
using Task3.Drivers;
using Task3.Util;

namespace Task2.Test_conditions
{
    public abstract class BaseTest
    {
        protected IWebDriver driver;
        protected Dictionary<string, string> Config;
        protected string TestCaseMark = new string('*', 10);

        [SetUp]
        public void Setup()
        {
            BrowserFactory.GetInstance();
            LoggerUtil.InitLoger();
            Config = ParseJSON.GetConfigFile(ConfigClass.ConfigPath);
            DriverUtil.GoToPage(Config["MainPageUrl"]);
        }

        [TearDown]
        public void CleanUp()
        {
            DriverUtil.Quit();
        }
    }
}
