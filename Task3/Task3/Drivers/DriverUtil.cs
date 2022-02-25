using OpenQA.Selenium;

namespace Task3.Drivers
{
    public static class DriverUtil
    {
        public static void GoToPage(string StrURL)
        {
            BrowserFactory.GetInstance().Navigate().GoToUrl(StrURL);
        }

        public static void Quit()
        {
            BrowserFactory.GetInstance().Quit();
            BrowserFactory.ResetInstance();
        }

        public static IAlert SwitchToAlert()
        {
            return BrowserFactory.GetInstance().SwitchTo().Alert();
        }

        public static void SwitchToDefault()
        {
            BrowserFactory.GetInstance().SwitchTo().DefaultContent();
        }

        public static void SwitchToFrame(IWebElement el)
        {
            BrowserFactory.GetInstance().SwitchTo().Frame(el);
        }

        public static void SwitchToFrame(int el)
        {
            BrowserFactory.GetInstance().SwitchTo().Frame(el);
        }

        public static void SwitchToWindow(int id)
        {
            BrowserFactory.GetInstance().SwitchTo().Window(BrowserFactory.GetInstance().WindowHandles[id]);
        }

        public static void CloseTab()
        {
            BrowserFactory.GetInstance().Close();
        }

        public static string GetUrl()
        {
            return BrowserFactory.GetInstance().Url;
        }
    }
}
