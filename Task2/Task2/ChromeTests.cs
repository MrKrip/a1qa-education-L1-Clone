using NUnit.Framework;
using Task2.Drivers;
using Task2.Pages;
using Task2.Test_conditions;

namespace Task2
{
    public class Tests : ChromeBaseTest
    {

        [Test]
        public void TestCase1()
        {
            MainPage mainPage = new MainPage(driver);
            AboutPage aboutPage = new AboutPage(driver);
            BrowserFactory.GoToPage(Config["MainPageUrl"], "Chrome");
            var IsMainPageOpen = mainPage.IsPageOpened();
            Assert.IsTrue(IsMainPageOpen, "Main page not open");
            mainPage.ClickAboutButton();
            var IsAboutPageOpen = aboutPage.IsPageOpened();
            Assert.IsTrue(IsAboutPageOpen, "About page not open");
            var IsNumbersOfGamersCorrect = aboutPage.CheckNumberOfGamers();
            Assert.IsTrue(IsNumbersOfGamersCorrect, "There are more players in the game than online");
            BrowserFactory.GoToPage(Config["MainPageUrl"], "Chrome");
            IsMainPageOpen = mainPage.IsPageOpened();
            Assert.IsTrue(IsMainPageOpen, "Main page not open");
        }

        [Test]
        public void TestCase2()
        {
            MainPage mainPage = new MainPage(driver);
            TopSellersPage sellersPage = new TopSellersPage(driver);
            GameDetailsPage detailsPage = new GameDetailsPage(driver);
            BrowserFactory.GoToPage(Config["MainPageUrl"], "Chrome");
            var IsMainPageOpen = mainPage.IsPageOpened();
            Assert.IsTrue(IsMainPageOpen, "Main page not open");

            mainPage.ClickTopSellersLink();
            var OSCheck = sellersPage.IsLinuxOSChose();
            Assert.IsTrue(OSCheck, "Linux not selected");

            var LanCoopCheck = sellersPage.AreNumberOfPlayersChosen();
            Assert.IsTrue(LanCoopCheck, "LAN-Coop not selected");

            (var TagCheck, var CountCheck) = sellersPage.IsTagChosen();
            Assert.IsTrue(TagCheck, "Tag not selected");
            Assert.IsTrue(CountCheck, "The specified number of results for the query does not match the number of games in the list");

            string SellersGameTitle = string.Empty, SellersGameRelease = string.Empty;
            decimal SellersGamePrice = 0;
            sellersPage.GetFirstGameTitle(ref SellersGameTitle)
                .GetFirstGameRelease(ref SellersGameRelease)
                .GetFirstGamePrice(ref SellersGamePrice)
                .OpenFirstGamePage();

            string DetailsGameTitle = string.Empty, DetailsGameRelease = string.Empty;
            decimal DetailsGamePrice = 0;
            detailsPage.GetGameTitle(ref DetailsGameTitle)
                .GetGameRelease(ref DetailsGameRelease)
                .GetGamePrice(ref DetailsGamePrice);

            Assert.AreEqual(SellersGameTitle, DetailsGameTitle, "The title on the \"Top Sellers\" page does not match the title on the \"Game Details\" page.");
            Assert.AreEqual(SellersGameRelease, DetailsGameRelease, "The release date on the \"Top Sellers\" page does not match the title on the \"Game Details\" page.");
            Assert.AreEqual(SellersGamePrice, DetailsGamePrice, "The price on the \"Top Sellers\" page does not match the title on the \"Game Details\" page.");
        }

        [Test]
        public void TestCase3()
        {
            MainPage mainPage = new MainPage(driver);
            CommunityMarketPage community = new CommunityMarketPage(driver);
            MarketUnitPage unitPage = new MarketUnitPage(driver);

            BrowserFactory.GoToPage(Config["MainPageUrl"], "Chrome");
            var IsMainPageOpen = mainPage.IsPageOpened();
            Assert.IsTrue(IsMainPageOpen, "Main page not open");

            mainPage.ClickMarketLink();
            var IsCommunityPageOpen = community.IsPageOpened();
            Assert.IsTrue(IsMainPageOpen, "Community Market page not open");

            var IsAdvanceOptionsOpened = community.IsAdvancedOptionsOpened();
            Assert.IsTrue(IsAdvanceOptionsOpened, "Advance Options not open");

            bool GameCheck, HeroCheck, RarityCheck, SearchBoxCheck, First5Results;
            (GameCheck, HeroCheck, RarityCheck, SearchBoxCheck, First5Results) = community.FillFilters()
                .ClickSerchButton()
                .IsFilterWork();
            Assert.IsTrue(GameCheck, "Missing Game filter");
            Assert.IsTrue(HeroCheck, "Missing Hero filter");
            Assert.IsTrue(RarityCheck, "Missing Rarity filter");
            Assert.IsTrue(SearchBoxCheck, "Missing Search filter");
            Assert.IsTrue(First5Results, "The first 5 results do not match the search filter");

            var FilterUpdateCheck = community.IsFilerUpdatingWork();
            Assert.IsTrue(FilterUpdateCheck, "Search result does not change");

            string ItemInCommunityPage = string.Empty;
            community.GetItemName(ref ItemInCommunityPage)
                .ClickFirstElement();
            string ItemInMarketUnitPage = string.Empty;
            bool NameCheck, ItemRaritycheck, HeroUnitCheck;
            (NameCheck, ItemRaritycheck, HeroUnitCheck) = unitPage.GetItemName(ref ItemInMarketUnitPage)
                .IsItemMatchesFilters();
            Assert.AreEqual(ItemInCommunityPage, ItemInMarketUnitPage, "The item name on the \"Community Market\" page does not match the title on the \"Item Details\" page.");
            Assert.IsTrue(NameCheck, "The item game name on the \"Item Details(Community Market)\" page does not match the filters.");
            Assert.IsTrue(ItemRaritycheck, "The item rarity on the \"Item Details(Community Market)\" page does not match the filters.");
            Assert.IsTrue(HeroUnitCheck, "The item hero on the \"Item Details(Community Market)\" page does not match the filters.");
        }
    }
}