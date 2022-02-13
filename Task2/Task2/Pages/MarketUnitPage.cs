using OpenQA.Selenium;
using System;
using System.IO;
using System.Threading;
using Task2.Models;
using Task2.Util;

namespace Task2.Pages
{
    class MarketUnitPage
    {
        private By ItemNameBy = By.XPath("//*[@id='largeiteminfo_item_name']");
        private By GameNameBy = By.XPath("//div[@id='largeiteminfo_game_name']");
        private By ItemTypeBy = By.XPath("//div[@id='largeiteminfo_item_type']");
        private By DiscriptionBy = By.XPath("//div[@id='largeiteminfo_item_descriptors']");
        private IWebDriver driver;
        private FilterModel Filter;

        public MarketUnitPage(IWebDriver webDriver)
        {
            driver = webDriver;
            string path = Directory.GetParent(Directory.GetCurrentDirectory()).Parent.Parent.FullName + @"\FilterData.json";
            Filter = ParseJSON.GetDataFile<FilterModel>(path);
        }

        public MarketUnitPage GetItemName(ref string Name)
        {
            Name = WaiterUtil.WaitFindElement(ItemNameBy).Text;
            return this;
        }

        public (bool, bool, bool) IsItemMatchesFilters()
        {
            bool NameCheck = WaiterUtil.WaitFindElement(GameNameBy).Text.Contains(Filter.Game);
            bool ItemRaritycheck = WaiterUtil.WaitFindElement(ItemTypeBy).Text.Contains(Filter.Rarity);
            bool HeroCheck = WaiterUtil.WaitFindElement(DiscriptionBy).Text.Contains(Filter.Hero);
            return (NameCheck, ItemRaritycheck, HeroCheck);
        }
    }
}
