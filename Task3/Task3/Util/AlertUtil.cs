using OpenQA.Selenium;
using Task3.Drivers;

namespace Task3.Util
{
    public static class AlertUtil
    {
        public static void SendKeys(string key)
        {
            IAlert alert = DriverUtil.SwitchToAlert();
            alert.SendKeys(key);
        }

        public static string GetText()
        {
            IAlert alert = DriverUtil.SwitchToAlert();
            return alert.Text;
        }

        public static void Confirm()
        {
            IAlert alert = DriverUtil.SwitchToAlert();
            alert.Accept();
        }
    }
}
