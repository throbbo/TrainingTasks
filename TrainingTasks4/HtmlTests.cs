using System.Collections.Generic;
using System.Linq;
using System.Text;
using NUnit.Framework;

namespace TrainingTasks4
{
    [TestFixture]
    public class HtmlTests
    {
        [Test]
        public void BasicHtmlBuilder()
        {
            Html html = Html.Tag("div").Attr("test", "testvalue");
            Assert.AreEqual("<div test=\"testvalue\"></div>", html.ToString());
        }

        [Test]
        public void BasicHtmlBuilderMultipleAttributes()
        {
            Html html = Html.Tag("div").Attr("test", "testvalue").Attr("test1", "testvalue1");
            Assert.AreEqual("<div test=\"testvalue\" test1=\"testvalue1\"></div>", html.ToString());
        }

        [Test]
        public void BasicHtmlBuilderAddClass()
        {
            Html html = Html.Tag("span").Attr("test", "testvalue").AddClass("wow");
            Assert.AreEqual("<span test=\"testvalue\" class=\"wow\"></span>", html.ToString());
        }

        [Test]
        public void BasicHtmlBuilderModify()
        {
            Html html = Html.Tag("div").Attr("test", "testvalue").Modify(x => x.AddClass("wow"));
            Assert.AreEqual("<div test=\"testvalue\" class=\"wow\"></div>", html.ToString());
        }

        [Test]
        public void BasicHtmlBuilderWithoutToString()
        {
            Html html = Html.Tag("span").Attr("test", "testvalue");
            Assert.True("<span test=\"testvalue\"></span>" == html);
        }

        [Test]
        public void HtmlHelperTest1()
        {
            var data = new MyClass {Location = "Park Orchards"};
            var htmlHelper = new HtmlHelper<MyClass>("");
            var html = htmlHelper.InputFor(x => x.Location, data).ToString();

            var expectedHtml = string.Format("<input name=\"Location\" value=\"{0}\" />", data.Location);
            Assert.AreEqual(expectedHtml, html);
        }

        [Test]
        public void HtmlHelperTest2()
        {
            var data = new MyClass {Location = "Park Orchards"};
            var htmlHelper = new HtmlHelper<MyClass>("span");
            var expectedHtml = string.Format("<span test=\"testvalue\"><input name=\"Location\" value=\"{0}\" /></span>", data.Location);
            var actualHtml = htmlHelper.Attr("test", "testvalue").InputFor(x => x.Location, data).ToString();
            Assert.AreEqual(expectedHtml, actualHtml);
        } 
    }

    public class MyClass
    {
        public string Location { get; set; }
    }
}
