using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Task3.Drivers;

namespace Task3.Elements
{
    class Frame : BaseElement
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
