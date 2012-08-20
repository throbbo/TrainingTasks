using System;

namespace TrainingTasks4
{
    public class HtmlInput : IHtmlElement
    {
        public HtmlInput()
        {
            Type = "input";
        }

        //Func<string, HtmlHelper<string>> ProperyAccessor { get; set; }
        public string Name {get; set; }
        public string Value {get; set; }
        public string Type {get; set; }
    }
}