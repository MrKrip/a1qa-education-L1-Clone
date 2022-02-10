using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;
using OpenQA.Selenium.Support.UI;
using System;
using Task2.Util;

namespace Task2.Pages
{
    class MainPage
    {
        private string MainPageUrl = "https://store.steampowered.com/";
        private By MainPageIndicator = By.XPath("//div[contains(@class,\"home\")]");
        private By AboutLinkBy = By.XPath("//div[@id=\"global_header\"]//a[contains(@href,\"about\") and contains(@class,\"menuitem\")]");
        private By NoteWorthyBy = By.XPath("//div[@id=\"noteworthy_tab\"]");
        private By TopSellersLinkBy = By.XPath("//div[contains(@class,\"focus\")]//following-sibling::div[@id=\"noteworthy_flyout\"]//a[contains(@href,\"topsellers\")]");
        private IWebDriver driver;

        public MainPage(IWebDriver webDriver)
        {
            driver = webDriver;
        }

        public MainPage ClickAboutButton()
        {

            var AboutLink = WaiterUtil.WaitFindElement(AboutLinkBy);
            AboutLink.Click();
            return this;
        }

        public bool IsPageOpened()
        {
            var Indicator = driver.FindElements(MainPageIndicator);
            return Indicator.Count > 0;
        }

        public MainPage ClickTopSellersLink()
        {
            var NoteWorthy = driver.FindElement(NoteWorthyBy);
            Actions actionProvider = new Actions(driver);
            actionProvider.MoveToElement(NoteWorthy).Build().Perform();
            WaiterUtil.WaitClickible(TopSellersLinkBy);
            var TopSellersLink = driver.FindElement(TopSellersLinkBy);
            TopSellersLink.Click();
            return this;
        }
    }
}
