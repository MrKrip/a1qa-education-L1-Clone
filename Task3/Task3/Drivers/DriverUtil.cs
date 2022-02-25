using OpenQA.Selenium;
using Task3.Util;

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
            LoggerUtil.MakeLog($"Switching to alert");
            return BrowserFactory.GetInstance().SwitchTo().Alert();
        }

        public static void SwitchToDefault()
        {
            LoggerUtil.MakeLog($"Switching to default");
            BrowserFactory.GetInstance().SwitchTo().DefaultContent();
        }

        public static void SwitchToFrame(IWebElement el)
        {
            LoggerUtil.MakeLog($"Switching to frame {el.ToString()}");
            BrowserFactory.GetInstance().SwitchTo().Frame(el);
        }

        public static void SwitchToFrame(int el)
        {
            LoggerUtil.MakeLog($"Switching to frame {el}");
            BrowserFactory.GetInstance().SwitchTo().Frame(el);
        }

        public static void SwitchToWindow(int id)
        {
            LoggerUtil.MakeLog($"Switching to {id} window");
            BrowserFactory.GetInstance().SwitchTo().Window(BrowserFactory.GetInstance().WindowHandles[id]);
        }

        public static void CloseTab()
        {
            LoggerUtil.MakeLog($"Closing current tab");
            BrowserFactory.GetInstance().Close();
        }

        public static string GetUrl()
        {
            LoggerUtil.MakeLog($"Getting current url tab");
            return BrowserFactory.GetInstance().Url;
        }
    }
}
