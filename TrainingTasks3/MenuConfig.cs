using System;
using System.Collections.Generic;
using System.Reflection.Emit;
using System.Security.Policy;

namespace TrainingTasks3
{
    public class MenuConfig 
    {
        public Func<MenuContext, IEnumerable<MenuItem>> MenuItems { get; set; }
        public Url Url { get; set; }
        public string Label { get; set; }
        public Func<MenuContext, MenuItem, bool> IsVisible { get; set; }
    }
}