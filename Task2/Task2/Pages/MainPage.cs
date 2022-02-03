﻿using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task2.Pages
{
    class MainPage
    {
        private string MainPageUrl = "https://store.steampowered.com/";
        private By MainPageIndicator = By.XPath("//body[contains(@class,\"home\")]");
        private By AboutLinkBy = By.XPath("//div[@id=\"global_header\"]//a[contains(@href,\"about\") and contains(@class,\"menuitem\")]");
        private IWebDriver driver;
        private WebDriverWait wait;

        public MainPage(IWebDriver webDriver)
        {
            driver = webDriver;
            wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
        }

        public MainPage GoToPage()
        {
            driver.Navigate().GoToUrl(MainPageUrl);
            return this;
        }
        public MainPage ClickAboutButton()
        {

            var AboutLink = wait.Until(e=>e.FindElement(AboutLinkBy));
            AboutLink.Click();
            return this;
        }

        public bool ChekPage()
        {
            var Indicator = driver.FindElements(MainPageIndicator);
            return Indicator.Count > 0;
        }
    }
}
