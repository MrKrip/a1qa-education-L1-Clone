using OpenQA.Selenium;
using System;
using System.Threading;
using Task2.Util;

namespace Task2.Pages
{
    class CommunityMarketPage
    {
        private By AdvancedOptionsBy = By.XPath("//div[@id='market_search_advanced_show']//div[contains(@class,'button')]");
        private By SearchCommunityMarket = By.XPath("//div[contains(@class,'newmodal') and @data-panel]");
        private By GamesListBy = By.XPath("//div[@id='app_option_0_selected']");
        private By HeroListBy = By.XPath("//div[@id='market_advancedsearch_filters']//select[contains(@name,'Hero')]");
        private By CheckBoxBy = By.XPath("//input[@id='tag_570_Rarity_Rarity_Immortal']");
        private By SearchBoxBy = By.XPath("//input[@id='advancedSearchBox']");
        private By SearchButtonBy = By.XPath("//div[contains(@class,'bottombuttons')]//div[contains(@onclick,'search')]");
        private By SerchTermsBy = By.XPath("//a[contains(@class,'market_searchedForTerm')]");
        private By SearchResultBy = By.XPath("//div[contains(@class,'market_listing_searchresult')]");
        private IWebDriver driver;

        public CommunityMarketPage(IWebDriver webDriver)
        {
            driver = webDriver;
        }

        public bool IsPgeOpened()
        {
            return driver.FindElements(AdvancedOptionsBy).Count > 0;
        }

        public bool IsAdvancedOptionsOpened()
        {
            var AdvancedOptions = driver.FindElement(AdvancedOptionsBy);
            AdvancedOptions.Click();
            return WaiterUtil.WaitFindElements(SearchCommunityMarket).Count>0;
        }
    }
}
