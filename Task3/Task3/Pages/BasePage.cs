using Task3.Elements;

namespace Task3.Pages
{
    public abstract class BasePage
    {
        BaseElement DefaultElement;
        string Name;

        public BasePage(string name,BaseElement Base)
        {
            Name = name;
            DefaultElement = Base;
        }

        public bool IsPageOpened()
        {
            return DefaultElement.IsVisible();
        }
    }
}
