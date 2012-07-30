using System;
using System.Collections.Generic;

namespace TrainingTasks3
{
    public interface IMenuConfigBuilder
    {
        void Visible(Func<MenuContext, MenuItem, bool> func);
        void AddDynamic(Func<MenuContext, IEnumerable<MenuItem>> func);
        void AddStatic(string test, string s);
    }
}