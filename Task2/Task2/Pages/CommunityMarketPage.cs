using OpenQA.Selenium;
using System.IO;
using Task2.Models;
using Task2.Util;
using OpenQA.Selenium.Support.UI;
using System.Threading;
using System.Linq;
using System;

namespace Task2.Pages
{
    class CommunityMarketPage
    {
        private By AdvancedOptionsBy = By.XPath("//div[@id='market_search_advanced_show']//div[contains(@class,'button')]");
        private By SearchCommunityMarket = By.XPath("//div[contains(@class,'newmodal') and @data-panel]");
        private By GamesListBy = By.XPath("//div[@id='market_advancedsearch_appselect_activeapp']");
        private By HeroListBy = By.XPath("//div[@id='market_advancedsearch_filters']//select[contains(@name,'Hero')]");
        private By SearchBoxBy = By.XPath("//input[@id='advancedSearchBox']");
        private By SearchButtonBy = By.XPath("//div[contains(@class,'bottombuttons')]//div[contains(@onclick,'search')]");
        private By SerchTermsBy = By.XPath("//a[contains(@class,'market_searchedForTerm')]");
        private By SearchResultBy = By.XPath("//div[contains(@class,'market_listing_searchresult')]");
        private By SearchResultItemNameBy = By.XPath("//div[contains(@class,'market_listing_searchresult')]//span[contains(@class,'market_listing_item_name')]");
        private IWebDriver driver;
        private FilterModel Filter;
        private string game;
        private string gameRarity;
        private string Game
        {
            set
            {
                game = $"//div[@id='market_advancedsearch_appselect_options_apps']//div[img[@alt='{value}']]";
            }
            get
            {
                return game;
            }
        }
        private string GameRarity
        {
            set
            {
                gameRarity = $"//div[contains(@class,'econ_tag_filter_container')]//input[contains(@value,'{value}')]";
            }
            get
            {
                return gameRarity;
            }
        }

        public CommunityMarketPage(IWebDriver webDriver)
        {
            driver = webDriver;
        }

        public bool IsPageOpened()
        {
            return driver.FindElements(AdvancedOptionsBy).Count > 0;
        }

        public bool IsAdvancedOptionsOpened()
        {
            var AdvancedOptions = driver.FindElement(AdvancedOptionsBy);
            AdvancedOptions.Click();
            return WaiterUtil.WaitFindElements(SearchCommunityMarket).Count > 0;
        }

        public CommunityMarketPage FillFilters()
        {
            string path = Directory.GetParent(Directory.GetCurrentDirectory()).Parent.Parent.FullName + @"\FilterData.json";
            Filter = ParseJSON.GetDataFile<FilterModel>(path);
            var GameList = driver.FindElement(GamesListBy);
            GameList.Click();
            Game = Filter.Game;
            var GameElement = WaiterUtil.WaitFindElement(By.XPath(Game));
            GameElement.Click();
            WaiterUtil.WaitClickible(HeroListBy);
            var HeroList = WaiterUtil.WaitFindElement(HeroListBy);
            var selectHero = new SelectElement(HeroList);
            selectHero.SelectByText(Filter.Hero);
            GameRarity = Filter.Rarity;
            var RarityCheckbox = WaiterUtil.WaitFindElement(By.XPath(GameRarity));
            RarityCheckbox.Click();
            var SearchBox = WaiterUtil.WaitFindElement(SearchBoxBy);
            SearchBox.SendKeys(Filter.Search);
            return this;
        }

        public CommunityMarketPage ClickSerchButton()
        {
            var SearchButton = WaiterUtil.WaitFindElement(SearchButtonBy);
            SearchButton.Click();
            return this;
        }

        public (bool, bool, bool, bool, bool) IsFilterWork()
        {
            bool GameCheck = false;
            bool HeroCheck = false;
            bool RarityCheck = false;
            bool SearchBoxCheck = false;
            bool First5Results = true;
            var FilterTags = WaiterUtil.WaitFindElements(SerchTermsBy);
            for (int i = 0; i < FilterTags.Count; i++)
            {
                if (FilterTags[i].Text.Contains(Filter.Game))
                {
                    GameCheck = true;
                    continue;
                }
                else if (FilterTags[i].Text.Contains(Filter.Hero))
                {
                    HeroCheck = true;
                    continue;
                }
                else if (FilterTags[i].Text.Contains(Filter.Rarity))
                {
                    RarityCheck = true;
                    continue;
                }
                else if (FilterTags[i].Text.Contains(Filter.Search))
                {
                    SearchBoxCheck = true;
                    continue;
                }
            }

            var SearchResults = WaiterUtil.WaitFindElements(SearchResultItemNameBy);
            int SearchCount;
            if (SearchResults.Count < 5)
            {
                SearchCount = SearchResults.Count;
            }
            else
            {
                SearchCount = 5;
            }
            for (int i = 0; i < SearchCount; i++)
            {
                if (!SearchResults[i].Text.ToLower().Contains(Filter.Search))
                {
                    First5Results = false;
                    break;
                }
            }
            return (GameCheck, HeroCheck, RarityCheck, SearchBoxCheck, First5Results);
        }

        public bool IsFilerUpdatingWork()
        {
            var SearchResultsBefore = WaiterUtil.WaitFindElements(SearchResultItemNameBy);
            var SearchTag = WaiterUtil.WaitFindElements(SerchTermsBy).First(el => el.Text.Contains(Filter.Search));
            SearchTag.Click();
            var GameTag = WaiterUtil.WaitFindElements(SerchTermsBy).First(el => el.Text.Contains(Filter.Game));
            GameTag.Click();
            var SearchResultsAfter = WaiterUtil.WaitFindElements(SearchResultItemNameBy);
            var SearchCount = Math.Min(SearchResultsAfter.Count, SearchResultsBefore.Count);

            bool FilterUpdate = true;
            if (SearchResultsAfter.Count == SearchResultsBefore.Count)
            {
                int Matches = 0;
                for (int i = 0; i < SearchCount; i++)
                {
                    if (SearchResultsBefore[i].Text == SearchResultsAfter[i].Text)
                    {
                        Matches++;
                    }
                }

                if (Matches == SearchResultsAfter.Count)
                {
                    FilterUpdate = false;
                }
            }

            return FilterUpdate;
        }

        public CommunityMarketPage GetItemName(ref string Name)
        {
            Name = WaiterUtil.WaitFindElements(SearchResultItemNameBy).First().Text;
            return this;
        }

        public CommunityMarketPage ClickFirstElement()
        {
            WaiterUtil.WaitFindElements(SearchResultBy).First().Click();
            return this;
        }
    }
}
