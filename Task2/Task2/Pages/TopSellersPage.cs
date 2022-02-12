using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.WaitHelpers;
using System;
using System.Threading;
using Task2.Util;

namespace Task2.Pages
{
    class TopSellersPage
    {
        private By LinuxCheckSpanBy = By.XPath("//span[@data-value=\"linux\"]");
        private By LinuxCheckBy = By.XPath("//span[@data-value=\"linux\" and contains(@class,\"checked\")]");
        private By NumberOfPlayersBy = By.XPath("//div[@data-collapse-name=\"category3\"]");
        private By LANCoopBy = By.XPath("//div[@data-value='48']");
        private By LANCoopCheckBy = By.XPath("//span[@data-value=\"48\" and contains(@class,\"checked\")]");
        private By FirstTagBy = By.XPath("//div[@id=\"TagFilter_Container\"]//span[1]");
        private By ActionTagBy = By.XPath("//div[@id=\"TagFilter_Container\"]//span[@data-value=\"19\" and @data-param=\"tags\"]");
        private By ActionTagCountBy = By.XPath("//div[@id=\"TagFilter_Container\"]//span[@data-value=\"19\" and @data-param=\"tags\"]//span[contains(@class,\"count\")]");
        private By ActionTagCheckBy = By.XPath("//div[@id=\"TagFilter_Container\"]//span[@data-value=\"19\" and @data-param=\"tags\" and contains(@class,\"checked\")]");
        private By GameListBy = By.XPath("//div[@id='search_resultsRows']//a");
        private By FirstGameBy = By.XPath("//div[@id=\"search_resultsRows\"]//a[1]");
        private By FirstGameTitleBy = By.XPath("//div[@id=\"search_resultsRows\"]//a[1]//span[contains(@class,\"title\")]");
        private By FirstGameReleaseBy = By.XPath("//div[@id=\"search_resultsRows\"]//a[1]//div[contains(@class,\"released\")]");
        private By FirstGamePriceBy = By.XPath("//div[@id=\"search_resultsRows\"]//a[1]//div[contains(@class,\"price\")]");
        private IWebDriver driver;

        public TopSellersPage(IWebDriver webDriver)
        {
            driver = webDriver;
        }

        public bool IsLinuxOSChose()
        {
            var LinuxOS = driver.FindElement(LinuxCheckSpanBy);
            LinuxOS.Click();
            var LinuxCheck = driver.FindElements(LinuxCheckBy).Count > 0;
            return LinuxCheck;
        }

        public bool AreNumberOfPlayersChosen()
        {
            var NumOfPlayers = driver.FindElement(NumberOfPlayersBy);
            NumOfPlayers.Click();
            var LANCoop = WaiterUtil.WaitFindElement(LANCoopBy);
            Actions action = new Actions(driver);
            action.MoveToElement(LANCoop).Perform();
            LANCoop.Click();
            return driver.FindElements(LANCoopCheckBy).Count > 0;
        }
        public (bool, bool) IsTagChosen()
        {
            var FirstTag = driver.FindElement(FirstTagBy);
            FirstTag.Click();
            FirstTag.Click();
            var ActionTag = WaiterUtil.WaitFindElement(ActionTagBy);
            WaiterUtil.WaitAllElementsVisible(GameListBy);
            var ActionTagCount = Int32.Parse(driver.FindElement(ActionTagCountBy).Text.Replace(" ", ""));            
            ActionTag.Click();
            var ActionTagCheck = WaiterUtil.WaitFindElements(ActionTagCheckBy).Count > 0;
            //WaiterUtil.WaitAllElementsVisible(GameListBy); //Вообще без понятия почему здесь выдает WebDriverTimeoutException, если я уже использовал эту функцию на 58 строке
            Thread.Sleep(1000);
            var GameList = WaiterUtil.WaitFindElements(GameListBy);
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
