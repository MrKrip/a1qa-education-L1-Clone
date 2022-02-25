using OpenQA.Selenium;
using System.Linq;
using System.Security.Cryptography;
using Task3.Drivers;
using Task3.Elements;
using Task3.Util;

namespace Task3.Pages
{
    public class AlertsPage : BasePage
    {
        private static ContentForm Def = new ContentForm("//div[contains(@class,'main-header') and contains(.,'Alerts')]", "Default element");
        private Button AlertCategory = new Button("//div[contains(@class,'element-list')]//*[contains(.,'Alerts') and contains(@class,'btn')]", "Alert button in category submenu");
        private ContentForm AlertForm = new ContentForm("//div[@id='javascriptAlertsWrapper']", "Alert form");
        private Button AlertButton = new Button("//button[@id='alertButton']", "Default alert button");
        private Button ConfirmAlertButton = new Button("//button[@id='confirmButton']", "Confirm alert button");
        private Button PromtAlertButton = new Button("//button[@id='promtButton']", "Promt alert button");
        private ContentForm ConfirmFrom = new ContentForm("//span[@id='confirmResult']", "Confirm result");
        private ContentForm PromptFrom = new ContentForm("//span[@id='promptResult']", "Prompt result");

        public AlertsPage(string name) : base(name, Def)
        {
        }

        public bool ChooseAlertCategory()
        {
            AlertCategory.Click();
            return AlertForm.IsVisible();
        }

        public bool IsDefaultAlertOpened()
        {
            try
            {
                AlertButton.Click();
                IAlert alert = WaiterUtil.WaitAlert();
                return true;
            }
            catch (WebDriverTimeoutException ex)
            {
                return false;
            }
        }
        public bool IsConfirmAlertOpened()
        {
            try
            {
                ConfirmAlertButton.Click();
                IAlert alert = WaiterUtil.WaitAlert();
                return true;
            }
            catch (WebDriverTimeoutException ex)
            {
                return false;
            }
        }
        public bool IsPromptAlertOpened()
        {
            try
            {
                PromtAlertButton.Click();
                IAlert alert = WaiterUtil.WaitAlert();
                return true;
            }
            catch (WebDriverTimeoutException ex)
            {
                return false;
            }
        }

        public string RandomFillAlertField()
        {
            IAlert alert = DriverUtil.SwitchToAlert();
            string chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789";
            int lenght = RandomNumberGenerator.GetInt32(0, chars.Length);
            string text= new string(Enumerable.Repeat(chars, lenght).Select(s => s[RandomNumberGenerator.GetInt32(0, chars.Length)]).ToArray()); 
            alert.SendKeys(text);
            return text;
        }

        public bool IsAlertTextMatch(string text)
        {
            IAlert alert = DriverUtil.SwitchToAlert();
            return alert.Text == text;
        }

        public AlertsPage ConfirmAlert()
        {
            IAlert alert = DriverUtil.SwitchToAlert();
            alert.Accept();
            return this;
        }

        public bool IsAlertClosed()
        {
            try
            {                
                DriverUtil.SwitchToAlert();
                return false;
            }
            catch (NoAlertPresentException ex)
            {
                return true;
            }
        }

        public bool IsPromptAlertWork(string text)
        {
            return PromptFrom.GetText().Contains(text);
        }

        public bool IsConfirmAlertWork(string text)
        {
            return ConfirmFrom.GetText() == text;
        }
    }
}
