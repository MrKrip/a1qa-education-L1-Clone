using OpenQA.Selenium;
using Task3.Drivers;
using Task3.Elements;

namespace Task3.Pages
{
    public class NestedFramesPage : BasePage
    {
        private static Label Def = new Label(By.XPath("//div[contains(@class,'main-header') and text()='Nested Frames']"), "Default element");
        private Button NestedFrameCategory = new Button(By.XPath("//div[contains(@class,'element-list')]//*[contains(.,'Nested Frames') and contains(@class,'btn')]"), "Nested frames button in category submenu");
        private Label ParentFrameText = new Label(By.XPath("//body"), "Parent frame text");
        private Label ChildFrameText = new Label(By.XPath("//p"), "Child frame text");

        public NestedFramesPage(string name) : base(name, Def)
        {
        }

        public NestedFramesPage ChooseNestedFrameCategory()
        {
            NestedFrameCategory.Click();
            return this;
        }



        public (bool, bool) IsFramesCorrect(string parent, string child)
        {
            DriverUtil.SwitchToFrame(By.XPath("//iframe[@id='frame1']"));
            string Parent = ParentFrameText.GetText();
            DriverUtil.SwitchToFrame(By.XPath("//iframe[@srcdoc]"));
            string Child = ChildFrameText.GetText();
            DriverUtil.SwitchToDefault();
            return (parent == Parent, Child == child);
        }

        
    }
}
