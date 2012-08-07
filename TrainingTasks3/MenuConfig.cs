using System;
using System.Collections.Generic;
using System.Linq;

namespace TrainingTasks3
{
    public class MenuConfig
    {
        public MenuConfig()
        {
            StaticMenuItems = new List<MenuItem>();
            DynamicMenuItems = new List<MenuItem>();
        }
        public List<MenuItem> StaticMenuItems { get; set; }
        public List<MenuItem> DynamicMenuItems { get; set; }
        public Func<MenuContext, IEnumerable<MenuItem>> DynamicMenuItemsFunc { get; set; }
        public Func<MenuContext, MenuItem, bool> IsVisibleFunc { get; set; }
    }
}