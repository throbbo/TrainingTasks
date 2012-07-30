using System;
using System.Collections.Generic;
using System.Reflection.Emit;
using System.Security.Policy;

namespace TrainingTasks3
{
    public interface IMenuConfigBuilder
    {
        void Visible(Func<MenuContext, MenuItem, bool> func);
        void AddDynamic(Func<MenuContext, IEnumerable<MenuItem>> func);
        void AddStatic(string test, string s);
    }

    public class MenuConfigBuilder : IMenuConfigBuilder
    {
        
        private readonly IMenuConfig _config;
        public MenuConfigBuilder(IMenuConfig config)
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

    public interface IMenuConfig
    {
        Func<MenuContext, IEnumerable<MenuItem>> MenuItems { get; set; }
        Url Url { get; set; }
        string Label { get; set; }
        Func<MenuContext, MenuItem, bool> IsVisible { get; set; }
    }

    public class MenuConfig : IMenuConfig
    {
        public Func<MenuContext, IEnumerable<MenuItem>> MenuItems { get; set; }
        public Url Url { get; set; }
        public string Label { get; set; }
        public Func<MenuContext, MenuItem, bool> IsVisible { get; set; }
    }
}