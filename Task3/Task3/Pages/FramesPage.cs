using OpenQA.Selenium;
using Task3.Drivers;
using Task3.Elements;

namespace Task3.Pages
{
    public class FramesPage:BasePage
    {
        private static Label Def = new Label(By.XPath("//div[contains(@class,'main-header') and text()='Frames']"), "Default element");
        private Button FrameCategory = new Button(By.XPath("//div[contains(@class,'element-list')]//*[span[text()='Frames'] and contains(@class,'btn')]"), "Frames button in category submenu");
        private Label FrameText = new Label(By.XPath("//*[@id='sampleHeading']"), "Text from frame");

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
            DriverUtil.SwitchToFrame(By.XPath("//iframe[@id='frame1']"));
            string frame1 = FrameText.GetText();
            DriverUtil.SwitchToDefault();
            DriverUtil.SwitchToFrame(By.XPath("//iframe[@id='frame2']"));
            string frame2 = FrameText.GetText();
            return frame1 == frame2;
        }
    }
}
