using OpenQA.Selenium;
using Task3.Drivers;
using Task3.Elements;

namespace Task3.Pages
{
    public class FramesPage:BasePage
    {
        private static ContentForm Def = new ContentForm(By.XPath("//div[contains(@class,'main-header') and text()='Frames']"), "Default element");
        private Button FrameCategory = new Button(By.XPath("//div[contains(@class,'element-list')]//*[span[text()='Frames'] and contains(@class,'btn')]"), "Frames button in category submenu");
        private Frame FirstFrame = new Frame(By.XPath("//iframe[@id='frame1']"), "Parent frame");
        private Frame SecondFrame = new Frame(By.XPath("//iframe[@id='frame2']"), "Second frame");
        private ContentForm FrameText = new ContentForm(By.XPath("//*[@id='sampleHeading']"), "Text from frame");

        public FramesPage(string name) : base(name, Def)
        {
        }
        public FramesPage ChooseFrameCategory()
        {
            FrameCategory.Click();
            return this;
        }

        public bool IsFrameTextMatch()
        {
            FirstFrame.SwitchTo();
            string frame1 = FrameText.GetText();
            DriverUtil.SwitchToDefault();
            SecondFrame.SwitchTo();
            string frame2 = FrameText.GetText();
            return frame1 == frame2;
        }
    }
}
