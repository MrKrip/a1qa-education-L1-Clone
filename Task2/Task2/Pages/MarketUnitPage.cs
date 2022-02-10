using OpenQA.Selenium;
using System;
using System.Threading;
using Task2.Util;

namespace Task2.Pages
{
    class MarketUnitPage
    {
        private By ItemTymeBy = By.XPath("//div[@id='largeiteminfo_item_type']");
        private By DiscriptionBy = By.XPath("//div[@id='largeiteminfo_item_descriptors']");
        private IWebDriver driver;

        public MarketUnitPage(IWebDriver webDriver)
        {
            driver = webDriver;
        }
    }
}
