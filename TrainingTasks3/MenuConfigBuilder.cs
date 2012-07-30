using System;
using System.Collections.Generic;
using System.Security.Policy;

namespace TrainingTasks3
{
    public class MenuConfigBuilder : IMenuConfigBuilder
    {
        
        private readonly MenuConfig _config;

        public MenuConfigBuilder(MenuConfig config)
        {
            _config = config;
        }

        public void Visible(Func<MenuContext, MenuItem, bool> func)
        {
            _config.IsVisibleFunc = func;
        }

        public void AddDynamic(Func<MenuContext, IEnumerable<MenuItem>> func)
        {
            _config.DynamicMenuItemsFunc = func;
        }

        public void AddStatic(string test, string s)
        {
            _config.StaticMenuItems.Add(new MenuItem() {Url = test, Text = s});
        }  
    }
}