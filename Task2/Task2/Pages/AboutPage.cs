using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;
using System.Linq;

namespace Task2.Pages
{
    class AboutPage
    {
        private string PageUrl = "https://store.steampowered.com/about/";
        private By GamersOnlineBy = By.XPath("//div[contains(@class,\"gamers_online\")]//parent::div[@class=\"online_stat\"]");
        private By GamersInGameBy = By.XPath("//div[contains(@class,\"gamers_in_game\")]//parent::div[@class=\"online_stat\"]");
        private IWebDriver driver;
        private WebDriverWait wait;

        public AboutPage(IWebDriver webDriver)
        {
            driver = webDriver;
            wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
        }

        public bool CheckPage()
        {
            var GamersOnline = driver.FindElements(GamersOnlineBy);
            var GamersInGame = driver.FindElements(GamersInGameBy);
            return GamersInGame.Count>0 && GamersOnline.Count>0;
        }

        public bool CheckNumberOfGamers()
        {
            var GamersOnline = driver.FindElement(GamersOnlineBy).Text.Split("\n").Last().Replace(",", "");
            var GamersInGame = driver.FindElement(GamersInGameBy).Text.Split("\n").Last().Replace(",", "");
            int Online = Int32.Parse(GamersOnline);
            int InGame = Int32.Parse(GamersInGame);
            return Online>=InGame;
        }
    }
}
