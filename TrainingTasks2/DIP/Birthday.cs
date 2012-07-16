using System;

namespace TrainingTasks2.DIP
{
    public interface IBirthday
    {
        string Name { get; set; }
        DateTime Date { get; set; }
    }

    public class Birthday : IBirthday
    {
        public string Name { get; set; }
        public DateTime Date { get; set; }
    }
}