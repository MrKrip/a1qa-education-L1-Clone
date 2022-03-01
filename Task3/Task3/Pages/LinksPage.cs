using OpenQA.Selenium;
using Task3.Drivers;
using Task3.Elements;

namespace Task3.Pages
{
    public class LinksPage : BasePage
    {
        private static Label Def = new Label(By.XPath("//div[contains(@class,'main-header') and text()='Links']"), "Default element");
        public static string name = "Links Page";
        private Button ElementsSubMenu = new Button(By.XPath("//div[contains(@class,'header-wrapper') and *[text()='Elements']]"), "Element submenu button");
        private Button LinksCategory = new Button(By.XPath("//div[contains(@class,'element-list')]//*[span[text()='Links'] and contains(@class,'btn')]"), "Links button in category submenu");
        private Button HomeLink = new Button(By.XPath("//*[@id='simpleLink']"),"Home link");

        public LinksPage() : base(name, Def)
        {

        }

        public LinksPage ChooseLinksCategory()
        {
            ElementsSubMenu.Click();
            LinksCategory.Click();
            return this;
        }

        public LinksPage ClickHomeLink()
        {
            HomeLink.Click();
            DriverUtil.SwitchToWindow(1);
            return this;
        }

        public LinksPage ReturnToLinksPage()
        {
            DriverUtil.SwitchToWindow(0);
            return this;
        }
    }
}
