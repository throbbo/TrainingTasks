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

            list.AddRange(_config.StaticMenuItems);
            list.AddRange(_config.DynamicMenuItems);
            
            return list;
        }
    }
}