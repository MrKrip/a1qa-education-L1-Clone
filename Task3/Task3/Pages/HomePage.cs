using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Task3.Elements;

namespace Task3.Pages
{
    public class HomePage : BasePage
    {
        private static Button Def = new Button("//div[contains(@class,'card')]", "Default element");
        private Button Alerts = new Button("//div[contains(@class,'top-card') and div[contains(.,'Alerts')]]", "Alerts, Frame & Windows button");
        private Button Elements = new Button("//div[contains(@class,'top-card') and div[contains(.,'Elements')]]", "Element button");

        public HomePage(string name) : base(name, Def)
        {
        }

        public HomePage ClickAlertsLink()
        {
            Alerts.Click();
            return this;
        }

        public HomePage CleckElementsLink()
        {
            Elements.Click();
            return this;
        }
    }
}
