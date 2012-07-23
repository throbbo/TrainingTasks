using System;
using System.Linq.Expressions;
using System.Security.Policy;

namespace TrainingTasks3
{
    public static class Menu
    {
        public static MenuConfig Config(Action<MenuConfig> func)
        {
            var menuConfig = new MenuConfig();
            func.Invoke(menuConfig);
            
            return menuConfig;
        }
    }
}