using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task3.Elements
{
    class TextField : BaseElement
    {
        public TextField(string xpath, string name) : base(xpath, name)
        { }

        public void SendKeys(string content)
        {
            GetElement().SendKeys(content);
        }
    }
}
