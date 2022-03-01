using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Firefox;
using System;
using System.IO;
using Task3.Util;
using WebDriverManager;
using WebDriverManager.DriverConfigs.Impl;

namespace Task3.Drivers
{
    public static class BrowserFactory
    {

        public static IWebDriver GetInstance()
        {           
            switch (ParseJSON.GetConfigFile(ConfigClass.ConfigPath)["BrowserName"].ToLower())
            {
                case "firefox":
                    {
                        return Firefox.GetInstance();
                    }
                case "chrome":
                    {
                        return Chrome.GetInstance();
                    }
                default:
                    {
                        throw new NotImplementedException();
                    }
            }
        }

        public static void ResetInstance()
        {
            switch (ParseJSON.GetConfigFile(ConfigClass.ConfigPath)["BrowserName"].ToLower())
            {
                case "firefox":
                    {
                        Firefox.ResetInstance();
                    }break;
                case "chrome":
                    {
                        Chrome.ResetInstance();
                    }break;
                default:
                    {
                        throw new NotImplementedException();
                    }
            }
        }

    }
}
