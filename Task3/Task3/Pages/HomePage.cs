using OpenQA.Selenium;
using Task3.Elements;

namespace Task3.Pages
{
    public class HomePage : BasePage
    {
        private static Button Def = new Button(By.XPath("//div[contains(@class,'card')]"), "Default element");
        private static string name = "Home Page";
        private Button Alerts = new Button(By.XPath("//div[contains(@class,'top-card') and div[contains(.,'Alerts')]]"), "Alerts, Frame & Windows button");
        private Button Elements = new Button(By.XPath("//div[contains(@class,'top-card') and div[contains(.,'Elements')]]"), "Element button");
        private Button Widgets = new Button(By.XPath("//div[contains(@class,'top-card') and div[contains(.,'Widgets')]]"),"Widgets button");

        public HomePage() : base(name, Def)
        {
        }

        public HomePage ClickAlertsLink()
        {
            Alerts.Click();
            return this;
        }

        public HomePage ClickElementsLink()
        {
            Elements.Click();
            return this;
        }

        public HomePage ClickWidgetsButton()
        {
            Widgets.Click();
            return this;
        }
    }
}
