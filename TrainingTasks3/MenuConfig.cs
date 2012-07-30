using System;
using System.Collections.Generic;
using System.Reflection.Emit;
using System.Security.Policy;

namespace TrainingTasks3
{
    public interface IMenuConfigBuilder
    {
        bool Visible(Func<MenuContext, MenuItem, bool> func);
        IEnumerable<MenuItem> AddDynamic(Func<MenuContext, IEnumerable<MenuItem>> func);
        void AddStatic(string test, string s);
    }

    public class MenuConfigBuilder : IMenuConfigBuilder
    {
        
        private readonly IMenuConfig _Config;
        public MenuConfigBuilder(IMenuConfig Config)
        {
            _Config = Config;
        }

        public bool Visible(Func<MenuContext, MenuItem, bool> func)
        {
            var mc = new MenuContext();
            var mi = new MenuItem();

            _Config.IsVisible = func;

            return _Config.IsVisible(mc, mi);
        }

        public IEnumerable<MenuItem> AddDynamic(Func<MenuContext, IEnumerable<MenuItem>> func)
        {
            var mc = new MenuContext();

            _Config.MenuItems = func;

            return _Config.MenuItems(mc);
        }

        public void AddStatic(string test, string s)
        {
            _Config.Url = new Url(test);
            _Config.Label = s;
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