using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;
using System.Threading;

namespace Task2.Pages
{
    class TopSellersPage
    {
        private By LinuxCheckSpanBy = By.XPath("//span[@data-value=\"linux\"]");
        private By LinuxCheckBy = By.XPath("//span[@data-value=\"linux\" and contains(@class,\"checked\")]");
        private By NumberOfPlayersBy = By.XPath("//div[@data-collapse-name=\"category3\"]");
        private By LANCoopBy = By.XPath("//span[@data-value=\"48\"]");
        private By LANCoopCheckBy = By.XPath("//span[@data-value=\"48\" and contains(@class,\"checked\")]");
        private By FirstTagBy = By.XPath("//div[@id=\"TagFilter_Container\"]//span[1]");
        private By ActionTagBy = By.XPath("//div[@id=\"TagFilter_Container\"]//span[@data-value=\"19\" and @data-param=\"tags\"]");
        private By ActionTagCountBy = By.XPath("//div[@id=\"TagFilter_Container\"]//span[@data-value=\"19\" and @data-param=\"tags\"]//span[contains(@class,\"count\")]");
        private By ActionTagCheckBy = By.XPath("//div[@id=\"TagFilter_Container\"]//span[@data-value=\"19\" and @data-param=\"tags\" and contains(@class,\"checked\")]");
        private By GameListBy = By.XPath("//div[@id=\"search_resultsRows\"]//a");
        private By FirstGameBy = By.XPath("//div[@id=\"search_resultsRows\"]//a[1]");
        private By FirstGameTitleBy = By.XPath("//div[@id=\"search_resultsRows\"]//a[1]//span[contains(@class,\"title\")]");
        private By FirstGameReleaseBy = By.XPath("//div[@id=\"search_resultsRows\"]//a[1]//div[contains(@class,\"released\")]");
        private By FirstGamePriceBy = By.XPath("//div[@id=\"search_resultsRows\"]//a[1]//div[contains(@class,\"price\")]");
        private IWebDriver driver;
        private WebDriverWait wait;

        public TopSellersPage(IWebDriver webDriver)
        {
            driver = webDriver;
            wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
        }

        public bool ChooseLinuxOS()
        {
            var LinuxOS = driver.FindElement(LinuxCheckSpanBy);
            LinuxOS.Click();
            var LinuxCheck = driver.FindElements(LinuxCheckBy).Count > 0;
            return LinuxCheck;
        }

        public bool ChooseNumberOfPlayers()
        {
            var NumOfPlayers = driver.FindElement(NumberOfPlayersBy);
            NumOfPlayers.Click();            
            var LANCoop = wait.Until(e => e.FindElement(LANCoopBy));
            //wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementToBeClickable(LANCoop));
            Thread.Sleep(1000);
            LANCoop.Click();
            var LanCoopCheck = driver.FindElements(LANCoopCheckBy).Count > 0;
            return LanCoopCheck;
        }
        public (bool, bool) ChooseTag()
        {
            var FirstTag = driver.FindElement(FirstTagBy);
            FirstTag.Click();
            FirstTag.Click();
            var ActionTag = wait.Until(e => e.FindElement(ActionTagBy));
            Thread.Sleep(1000);
            var ActionTagCount = Int32.Parse(driver.FindElement(ActionTagCountBy).Text.Replace(" ",""));
            ActionTag.Click();
            Thread.Sleep(1000);
            var ActionTagCheck = wait.Until(e => e.FindElements(ActionTagCheckBy)).Count > 0;
            var GameList = driver.FindElements(GameListBy);
            var CountCheck = (ActionTagCount == GameList.Count);
            return (ActionTagCheck, CountCheck);
        }

        public TopSellersPage GetFirstGameTitle(ref string title)
        {
            title = driver.FindElement(FirstGameTitleBy).Text;
            return this;
        }

        public TopSellersPage GetFirstGameRelease(ref string release)
        {
            release = driver.FindElement(FirstGameReleaseBy).Text;
            return this;
        }

        public TopSellersPage GetFirstGamePrice(ref decimal price)
        {
            string FinalPrice = driver.FindElement(FirstGamePriceBy).GetAttribute("data-price-final");
            price = Convert.ToDecimal(FinalPrice) / 100;
            return this;
        }
        public void OpenFirstGamePage()
        {
            driver.FindElement(FirstGameBy).Click();
        }
    }
}
