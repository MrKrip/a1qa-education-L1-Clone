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
            var IsMainPageOpen = mainPage
                .GoToPage()
                .ChekPage();
            Assert.IsTrue(IsMainPageOpen, "Main page not open");
            mainPage.ClickAboutButton();
        }
    }
}