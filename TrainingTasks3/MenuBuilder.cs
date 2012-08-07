using System.Collections.Generic;
using System.Linq;

namespace TrainingTasks3
{
    public class MenuBuilder
    {
        private readonly MenuContext _context;
        private readonly MenuConfig _config;

        public MenuBuilder(MenuContext context, MenuConfig config)
        {
            _context = context;
            _config = config;
        }

        public List<MenuItem> Build()
        {
            var list = new List<MenuItem>();

            if (_config.DynamicMenuItemsFunc != null)
            {
                var dynamicList = (_config.DynamicMenuItemsFunc(_context) ?? new List<MenuItem>()).ToList();
                _config.DynamicMenuItems = dynamicList;
            }
            
            if(_config.IsVisibleFunc != null)
            {
                list.AddRange(_config.StaticMenuItems.Where(menuItem => _config.IsVisibleFunc(_context, menuItem)));
                list.AddRange(_config.DynamicMenuItems.Where(menuItem => _config.IsVisibleFunc(_context, menuItem)));
            }

            return list;
        }
    }
}