using OpenQA.Selenium;
using System;

namespace Task2.Pages
{
    class GameDetailsPage
    {
        private By GameTitleBy = By.XPath("//div[@id=\"appHubAppName\"]");
        private By GameReleaseDateBy = By.XPath("//div[contains(@class,\"release_date\")]//div[contains(@class,\"date\")]");
        private By GamePriceBy = By.XPath("//div[contains(@class,\"game_purchase_price\")]");
        private IWebDriver driver;

        public GameDetailsPage(IWebDriver webDriver)
        {
            driver = webDriver;
        }

        public GameDetailsPage GetGameTitle(ref string title)
        {
            title = driver.FindElement(GameTitleBy).Text;
            return this;
        }
        public GameDetailsPage GetGameRelease(ref string release)
        {
            release = driver.FindElement(GameReleaseDateBy).Text;
            return this;
        }
        public GameDetailsPage GetGamePrice(ref decimal price)
        {
            price = Convert.ToDecimal(driver.FindElement(GamePriceBy).GetAttribute("data-price-final"))/100;
            return this;
        }
    }
}
