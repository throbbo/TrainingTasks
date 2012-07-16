using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TrainingTasks2.LSP
{
    public interface IFourSidedShape
    {
        int Width { get; set; }
        int Height { get; set; }
    }

    public class Rectangle : IFourSidedShape
    {
        public int Width { get; set; }
        public int Height { get; set; }
    }

    public class Square : IFourSidedShape
    {
        private int _height;
        
        public int Height
        {
            get { return _height; }
            set { _height = value; }
        }

        public int Width
        {
            get { return _height; }
            set { _height = value; }
        }
    }
}
