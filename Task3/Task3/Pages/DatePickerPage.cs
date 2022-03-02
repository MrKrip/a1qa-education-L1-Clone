using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Task3.Elements;

namespace Task3.Pages
{
    class DatePickerPage : BasePage
    {
        private static Label Def = new Label(By.XPath("//div[contains(@class,'main-header') and text()='Date Picker']"), "Default element");
        private static string name = "Date Picker Page";
        private Button DatePickerCategory = new Button(By.XPath("//div[contains(@class,'element-list')]//*[span[text()='Date Picker'] and contains(@class,'btn')]"), "Browser Windows button in category submenu");
        private Input SelectDate = new Input(By.Id("datePickerMonthYearInput"), "Select date input");
        private Input DateAndTime = new Input(By.Id("dateAndTimePickerInput"), "Date nd time input");
        private Select SelectYear = new Select(By.XPath("//select[contains(@class,'react-datepicker__year-select')]"), "Year select");
        private Label February29 = new Label(By.XPath("//div[contains(@aria-label,'February') and text()='29']"), "29 Februry label");
        private string FirstDateTimeFormat;
        private string SecondDateTimeFormat;

        public DatePickerPage() : base(name, Def)
        {

        }

        public DatePickerPage ClickDatePickerCategory()
        {
            DatePickerCategory.Click();
            FirstDateTimeFormat = DateTime.Now.ToString("MM/dd/yyyy", CultureInfo.InvariantCulture);
            SecondDateTimeFormat = DateTime.Now.ToString("MMMM d, yyyy h:mm tt", CultureInfo.InvariantCulture);
            return this;
        }

        public (bool, bool) IsDateCorrect()
        {
            return (SelectDate.GetAttribute("value") == FirstDateTimeFormat, DateAndTime.GetAttribute("value") == SecondDateTimeFormat);
        }

        public string FindDate()
        {
            SelectDate.Click();
            string value = SelectYear.GetCurrentValue();
            while(!February29.IsVisible())
            {
                value = (Int32.Parse(value)+1).ToString();
                SelectYear.SelectByValue(value);
            }
            February29.Click();
            return value;
        }

        public bool IsFabruary29DateCorrect(string year)
        {
            return SelectDate.GetAttribute("value") == $"02/29/{year}";
        }
    }
}
