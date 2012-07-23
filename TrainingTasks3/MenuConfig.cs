using System;
using System.Collections.Generic;
using System.Security.Policy;

namespace TrainingTasks3
{
    public class MenuConfig
    {
        public IEnumerable<MenuItem> MenuItems { get; set; }
        public Url Url { get; set; }
        public string SomeText { get; set; }
        public bool IsVisible { get; set; }

        public bool Visible(Func<MenuContext, MenuItem, bool> func)
        {
            var mc = new MenuContext();
            var mi = new MenuItem();

            IsVisible = func.Invoke(mc, mi);
            
            return IsVisible;
        }

        public IEnumerable<MenuItem> AddDynamic(Func<MenuContext, IEnumerable<MenuItem>> func)
        {
            var mc = new MenuContext();
            
            MenuItems = func.Invoke(mc);

            return MenuItems;
        }

        public void AddStatic(string test, string s)
        {
            Url = new Url(test);
            SomeText = s;
        }
    }
}