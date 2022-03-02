using OpenQA.Selenium;
using Task3.Elements;
using Task3.Models;

namespace Task3.Pages
{
    public class WebTabelsPage : BasePage
    {
        private static Label Def = new Label(By.XPath("//div[contains(@class,'main-header') and text()='Web Tables']"), "Default element");
        private static string name = "Web Tabels Page";
        private Button WebTablesCategory = new Button(By.XPath("//div[contains(@class,'element-list')]//*[span[text()='Web Tables'] and contains(@class,'btn')]"), "Web tables button in category submenu");
        private Button Add = new Button(By.XPath("//button[@id='addNewRecordButton']"), "Add button");
        private Label RegistrationForm = new Label(By.XPath("//div[contains(@class,'modal-content')]"), "Registration form");
        private Input FirstName = new Input(By.XPath("//input[@id='firstName']"),"First name text field");
        private Input LastName = new Input(By.XPath("//input[@id='lastName']"), "Last name text field");
        private Input Email = new Input(By.XPath("//input[@id='userEmail']"), "Email text field");
        private Input Age = new Input(By.XPath("//input[@id='age']"), "Age text field");
        private Input Salary = new Input(By.XPath("//input[@id='salary']"), "Salary text field");
        private Input Department = new Input(By.XPath("//input[@id='department']"), "Department text field");
        private Button Submit = new Button(By.XPath("//button[@id='submit']"), "Submit button");

        public WebTabelsPage() : base(name, Def)
        {
        }

        public WebTabelsPage ChooseWebTablesCategory()
        {
            WebTablesCategory.Click();
            return this;
        }

        public WebTabelsPage ClickAddButton()
        {
            Add.Click();
            return this;
        }

        public bool IsRegistrationFromOpened()
        {
            return RegistrationForm.IsVisible();
        }

        public WebTabelsPage FillRegistrationForm(RegistrationModel model)
        {
            FirstName.SendKeys(model.FirstName);
            LastName.SendKeys(model.LastName);
            Email.SendKeys(model.Email);
            Age.SendKeys(model.Age);
            Salary.SendKeys(model.Salary);
            Department.SendKeys(model.Department);
            return this;
        }

        public WebTabelsPage SubmitRegistrationForm()
        {
            Submit.Click();
            return this;
        }
        
        public bool IsRecordAdded(RegistrationModel model)
        {
            return new Label(By.XPath($"//div[@role='row' and div[text()='{model.FirstName}'] and div[text()='{model.LastName}'] and div[text()='{model.Age}'] and div[text()='{model.Email}'] and div[text()='{model.Salary}'] and div[text()='{model.Department}'] ]"),
                "Added registration form").IsVisible();
        }

        public WebTabelsPage DeleteRecord(RegistrationModel model)
        {
            new Button(By.XPath($"//div[@role='row' and div[text()='{model.FirstName}'] and div[text()='{model.LastName}'] and div[text()='{model.Age}'] and div[text()='{model.Email}'] and div[text()='{model.Salary}'] and div[text()='{model.Department}']]//span[contains(@id,'delete-record')]"),
                "Delete button").Click();
            return this;
        }
    }
}
