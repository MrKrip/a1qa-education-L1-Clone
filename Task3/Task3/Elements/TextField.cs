using Task3.Util;

namespace Task3.Elements
{
    public class TextField : BaseElement
    {
        public TextField(string xpath, string name) : base(xpath, name)
        { }

        public void SendKeys(string content)
        {
            LoggerUtil.MakeLog($"Sending keys to {Name}");
            GetElement().SendKeys(content);
        }
    }
}
