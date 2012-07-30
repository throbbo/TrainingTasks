using System;

namespace TrainingTasks3
{
    public class MenuContext
    {
        private readonly string _groupIn;

        public MenuContext()
        {
        }
        public MenuContext(string groupIn)
        {
            _groupIn = groupIn;
        }

        public string MenuGroup { get; set; }
    }
}