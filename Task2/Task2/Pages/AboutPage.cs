﻿using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;
using System.Linq;

namespace Task2.Pages
{
    class AboutPage
    {
        private By GamersOnlineBy = By.XPath("//div[contains(@class,\"gamers_online\")]//parent::div[@class=\"online_stat\"]");
        private By GamersInGameBy = By.XPath("//div[contains(@class,\"gamers_in_game\")]//parent::div[@class=\"online_stat\"]");
        private IWebDriver driver;

        public AboutPage(IWebDriver webDriver)
        {
            driver = webDriver;
        }

        public bool IsPageOpened()
        {
            var GamersOnline = driver.FindElements(GamersOnlineBy);
            return GamersOnline.Count > 0;
        }

        public bool CheckNumberOfGamers()
        {
            var GamersOnline = driver.FindElement(GamersOnlineBy).Text.Split("\n").Last().Replace(",", "");
            var GamersInGame = driver.FindElement(GamersInGameBy).Text.Split("\n").Last().Replace(",", "");
            int Online = Int32.Parse(GamersOnline);
            int InGame = Int32.Parse(GamersInGame);
            return Online >= InGame;
        }
    }
}
