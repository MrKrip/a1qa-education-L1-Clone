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
            switch (Config.browserName)
            {
                case "Firefox":
                    {
                        return Firefox.GetInstance();
                    }
                case "Chrome":
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
            switch (Config.browserName)
            {
                case "Firefox":
                    {
                        Firefox.ResetInstance();
                    }break;
                case "Chrome":
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
