using System;
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
        }

        //[Test]
        //public void Test2 ()
        //{

        //    IMenuConfig menuConfig = Menu.Config(options =>
        //    {
        //        options.AddStatic("/test", "Test");
        //        options.Visible((context, menuItem) =>
        //                            {
        //                                if(context.MenuGroup == "GROUP-A" && menuItem.Label =="MENUITEM-A" )
        //                                    return true;

        //                                return false;
        //                            });                              // context is MenuContext, menuItem is MenuItem, returns bool
        //    });

        //    var myContext = new MenuContext() {MenuGroup = "GROUP-A"};
        //    var myMenuItem = new MenuItem() {Label= "MENUITEM-A", Url = new Url("/MENUITEM-A")};

        //    Assert.AreEqual(true, menuConfig.IsVisible(myContext, myMenuItem));

        //}

        //[Test]
        //public void Test3 ()
        //{

        //    IMenuConfig menuConfig = Menu.Config(options =>
        //    {
        //        options.AddStatic("/test", "Test");
        //        options.Visible((context, menuItem) =>
        //                            {
        //                                if(context.MenuGroup == "GROUP-A" && menuItem.Label =="MENUITEM-A" )
        //                                    return true;

        //                                return false;
        //                            });                              // context is MenuContext, menuItem is MenuItem, returns bool
        //    });

        //    var myContext = new MenuContext() {MenuGroup = "GROUP-A"};
        //    var myMenuItem = new MenuItem() {Label= "MENUITEM-b", Url = new Url("/MENUITEM-b")};

        //    Assert.AreEqual(false, menuConfig.IsVisible(myContext, myMenuItem));

        //}
    }
}
