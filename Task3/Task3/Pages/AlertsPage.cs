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
        private static Label Def = new Label(By.XPath("//div[contains(@class,'main-header') and contains(.,'Alerts')"), "Default element");
        public static string name = "Alert Page";
        private Button AlertCategory = new Button(By.XPath("//div[contains(@class,'element-list')]//*[contains(.,'Alerts') and contains(@class,'btn')]"), "Alert button in category submenu");
        private Label AlertForm = new Label(By.XPath("//div[@id='javascriptAlertsWrapper']"), "Alert form");
        private Button AlertButton = new Button(By.XPath("//button[@id='alertButton']"), "Default alert button");
        private Button ConfirmAlertButton = new Button(By.XPath("//button[@id='confirmButton']"), "Confirm alert button");
        private Button PromtAlertButton = new Button(By.XPath("//button[@id='promtButton']"), "Promt alert button");
        private Label ConfirmFrom = new Label(By.XPath("//span[@id='confirmResult']"), "Confirm result");
        private Label PromptFrom = new Label(By.XPath("//span[@id='promptResult']"), "Prompt result");

        public AlertsPage() : base(name, Def)
        {
        }

        public bool IsAlertCategoryOpen()
        {
            AlertCategory.Click();
            return AlertForm.IsVisible();
        }

        public bool IsDefaultAlertOpened()
        {
            try
            {
                AlertButton.Click();
                WaiterUtil.WaitAlert();
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
                WaiterUtil.WaitAlert();
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
                WaiterUtil.WaitAlert();
                return true;
            }
            catch (WebDriverTimeoutException ex)
            {
                return false;
            }
        }

        public string RandomFillAlertField()
        {
            string text = TextGeneratorUtil.GenerteText();
            AlertUtil.SendKeys(text);
            return text;
        }

        public bool IsAlertTextMatch(string text)
        {            
            return AlertUtil.GetText() == text;
        }

        public AlertsPage ConfirmAlert()
        {
            AlertUtil.Confirm();
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
