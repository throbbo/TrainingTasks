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
            _config.IsVisible = func;
        }

        public void AddDynamic(Func<MenuContext, IEnumerable<MenuItem>> func)
        {
            _config.MenuItems = func;
        }

        public void AddStatic(string test, string s)
        {
            _config.Url = new Url(test);
            _config.Label = s;
        }  
    }
}