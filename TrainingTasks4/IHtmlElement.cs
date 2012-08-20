using System;

namespace TrainingTasks4
{
    public interface IHtmlElement
    {
        //Func<string, HtmlHelper<string>> ProperyAccessor { get; set; }
        string Name { get; set; }
        string Value { get; set; }
        string Type { get; set; }
    }
}