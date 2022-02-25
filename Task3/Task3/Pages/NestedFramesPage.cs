using Task3.Drivers;
using Task3.Elements;

namespace Task3.Pages
{
    public class NestedFramesPage : BasePage
    {
        private static ContentForm Def = new ContentForm("//div[contains(@class,'main-header') and text()='Nested Frames']", "Default element");
        private Button NestedFrameCategory = new Button("//div[contains(@class,'element-list')]//*[contains(.,'Nested Frames') and contains(@class,'btn')]", "Nested frames button in category submenu");
        private Frame ParentFrame = new Frame("//iframe[@id='frame1']", "Parent frame");
        private ContentForm ParentFrameText = new ContentForm("//body", "Parent frame text");
        private Frame ChildFrame = new Frame("//iframe[@srcdoc]", "Child frame");

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
            ParentFrame.SwitchTo();
            string Parent = ParentFrameText.GetText();
            string Child = ChildFrame.GetAttribute("srcdoc").Replace("<p>", "").Replace("</p>", "");
            DriverUtil.SwitchToDefault();
            return (parent == Parent, Child == child);
        }

        
    }
}
