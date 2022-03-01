using OpenQA.Selenium;
using Task3.Drivers;
using Task3.Elements;

namespace Task3.Pages
{
    public class BrowserWindowsPage : BasePage
    {
        private static Label Def = new Label(By.XPath("//div[contains(@class,'main-header') and text()='Browser Windows']"), "Default element");
        public static string name = "Browser Windows Page";
        private Button WindowsCategory = new Button(By.XPath("//div[contains(@class,'element-list')]//*[span[text()='Browser Windows'] and contains(@class,'btn')]"), "Browser Windows button in category submenu");
        private Button NewTab = new Button(By.XPath("//button[@id='tabButton']"), "New tab button");
        private Label NewTabText = new Label(By.XPath("//*[@id='sampleHeading']"), "Text on new tab");

        public BrowserWindowsPage() : base(name, Def)
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

        public (bool, bool) IsTabOpened(string text)
        {
            DriverUtil.SwitchToWindow(1);          
            return (NewTabText.IsVisible(), text == NewTabText.GetText());
        }
    }
}
