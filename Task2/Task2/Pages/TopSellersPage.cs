using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task2.Pages
{
    class TopSellersPage
    {
        private By LinuxCheckBoxBy = By.XPath("//span[@data-value=\"linux\"]");
        private By NumberOfPlayersBy = By.XPath("//div[@data-collapse-name=\"category3\"]");
        private By LANCoopBy = By.XPath("//span[@data-value=\"48\"]");
        private By FirstTagBy = By.XPath("//div[@id=\"TagFilter_Container\"]//span[1]");
        private By ActionTagBy = By.XPath("//div[@id=\"TagFilter_Container\"]//span[@data-value=\"19\" and @data-param=\"tags\"]");
        private By FirstGameInListBy = By.XPath("//div[@id=\"search_resultsRows\"]//a[1]");
        private By FirstGameTitleBy = By.XPath("//div[@id=\"search_resultsRows\"]//a[1]//span[contains(@class,\"title\")]");
        private By FirstGameReleaseBy = By.XPath("//div[@id=\"search_resultsRows\"]//a[1]//div[contains(@class,\"released\")]");
        private By FirstGamePriceBy = By.XPath("//div[@id=\"search_resultsRows\"]//a[1]//div[contains(@class,\"price\")]//@data-price-final");
        private IWebDriver driver;
        private WebDriverWait wait;

        public TopSellersPage(IWebDriver webDriver)
        {
            driver = webDriver;
            wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
        }
    }
}
