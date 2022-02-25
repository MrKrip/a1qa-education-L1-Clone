using Task3.Drivers;
using Task3.Util;

namespace Task3.Elements
{
    public class Frame : BaseElement
    {
        public Frame(string xpath, string name) : base(xpath, name)
        { }

        public Frame SwitchTo()
        {
            LoggerUtil.MakeLog($"Switching to {Name}");
            DriverUtil.SwitchToFrame(GetElement());
            return this;
        }
    }
}
