using Task3.Drivers;
using Task3.Elements;

namespace Task3.Pages
{
    public class BrowserWindowsPage : BasePage
    {
        private static ContentForm Def = new ContentForm("//div[contains(@class,'main-header') and text()='Browser Windows']", "Default element");
        private Button WindowsCategory = new Button("//div[contains(@class,'element-list')]//*[span[text()='Browser Windows'] and contains(@class,'btn')]", "Browser Windows button in category submenu");
        private Button NewTab = new Button("//button[@id='tabButton']", "New tab button");
        private ContentForm NewTabText = new ContentForm("//*[@id='sampleHeading']", "Text on new tab");

        public BrowserWindowsPage(string name) : base(name, Def)
        {

        }

        public BrowserWindowsPage ChooseWindowsCategory()
        {
            WindowsCategory.Click();
            return this;
        }

        public BrowserWindowsPage ClickNewTabButton()
        {
            NewTab.Click();
            return this;
        }

        public (bool, bool) IsTabOpened(string url, string text)
        {
            DriverUtil.SwitchToWindow(1);
            string Url = DriverUtil.GetUrl();
            if (!Url.Contains(url))
            {
                return (false, false);
            }
            return (Url.Contains(url), text == NewTabText.GetText());
        }

        public BrowserWindowsPage CloseTab()
        {
            DriverUtil.CloseTab();
            DriverUtil.SwitchToWindow(0);
            return this;
        }
    }
}
