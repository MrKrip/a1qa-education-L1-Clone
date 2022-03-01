using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using Task3.Util;

namespace Task3.Elements
{
    class Select : BaseElement
    {
        public Select(By locator, string name) : base(locator, name)
        { }

        public string GetCurrentValue()
        {
            LoggerUtil.MakeLog($"Get current valuer of {Name}");
            var selectObject = new SelectElement(GetElement());
            return selectObject.SelectedOption.Text;
        }

        public void SelectByValue(string Val)
        {
            LoggerUtil.MakeLog($"Select value {Val} for {Name}");
            var selectObject = new SelectElement(GetElement());
            selectObject.SelectByValue(Val);
        }
    }
}
