﻿using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Security.Policy;
using System.Text;
using NUnit.Framework;

namespace TrainingTasks3
{
    public class Tests
    {
        [Test]
        public void Task3Requirements()
        {
            // Implement the following API with tests.
            // Leave this test alone. It should obviously compile once finished.

            MenuConfig menuConfig = Menu.Config(options =>
            {
                options.AddStatic("/test", "Test");                                        // first param is url, second is text
                options.AddDynamic(context => { return Enumerable.Empty<MenuItem>(); });   // context is MenuContext, returns IEnumerable<MenuItem>
                options.Visible((context, menuItem) => true);                              // context is MenuContext, menuItem is MenuItem, returns bool
            });
            Assert.AreEqual("Test", menuConfig.SomeText);
            Assert.AreEqual("/test", menuConfig.Url.Value);
            Assert.AreEqual(0, menuConfig.MenuItems.Count());
        }
    }
}
