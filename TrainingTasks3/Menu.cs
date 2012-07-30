using System;
using System.Linq.Expressions;
using System.Security.Policy;

namespace TrainingTasks3
{
    public static class Menu
    {
        public static MenuConfig Config(Action<IMenuConfigBuilder> func)
        {
            var menuConfig = new MenuConfig();
            var menuConfigBuilder = new MenuConfigBuilder(menuConfig);
            func(menuConfigBuilder);
            
            return menuConfig;
        }
    }
}