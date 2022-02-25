using Task3.Drivers;

namespace Task3.Elements
{
    public class Frame : BaseElement
    {
        public Frame(string xpath, string name) : base(xpath, name)
        { }

        public Frame SwitchTo()
        {
            DriverUtil.SwitchToFrame(GetElement());
            return this;
        }
    }
}
