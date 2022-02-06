using NUnit.Framework;
using OpenQA.Selenium;
using Task2.Drivers;
using Task2.Pages;

namespace Task2
{
    public class Tests
    {
        private IWebDriver driver;
        private Chrome Instance = new Chrome();
        [SetUp]
        public void Setup()
        {
            driver = Instance.GetInstance();
        }
        [TearDown]
        public void CleanUp()
        {
            driver.Quit();
        }

        [Test]
        public void TestCase1()
        {
            MainPage mainPage = new MainPage(driver);
            AboutPage aboutPage = new AboutPage(driver);
            var IsMainPageOpen = mainPage
                .GoToPage()
                .ChekPage();
            Assert.IsTrue(IsMainPageOpen, "Main page not open");
            mainPage.ClickAboutButton();
            var IsAboutPageOpen = aboutPage.CheckPage();
            Assert.IsTrue(IsAboutPageOpen, "About page not open");
            var IsNumbersOfGamersCorrect = aboutPage.CheckNumberOfGamers();
            Assert.IsTrue(IsNumbersOfGamersCorrect, "There are more players in the game than online");
            IsMainPageOpen= mainPage
                .GoToPage()
                .ChekPage();
            Assert.IsTrue(IsMainPageOpen, "Main page not open");
        }
        [Test]
        public void TestCase2()
        {
            MainPage mainPage = new MainPage(driver);
            TopSellersPage sellersPage = new TopSellersPage(driver);
            GameDetailsPage detailsPage = new GameDetailsPage(driver);
            var IsMainPageOpen = mainPage
               .GoToPage()
               .ChekPage();
            Assert.IsTrue(IsMainPageOpen, "Main page not open");

            mainPage.ClickTopSellersLink();
            var OSCheck = sellersPage.ChooseLinuxOS();
            Assert.IsTrue(OSCheck, "Linux not selected");

            var LanCoopCheck = sellersPage.ChooseNumberOfPlayers();
            Assert.IsTrue(LanCoopCheck, "LAN-Coop not selected");

            (var TagCheck, var CountCheck) = sellersPage.ChooseTag();
            Assert.IsTrue(TagCheck,"Tag not selected");
            Assert.IsTrue(CountCheck, "The specified number of results for the query does not match the number of games in the list");

            string SellersGameTitle=string.Empty, SellersGameRelease=string.Empty;
            decimal SellersGamePrice=0;
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
    }
}