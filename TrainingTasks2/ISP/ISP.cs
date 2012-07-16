using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TrainingTasks2.ISP
{
    public interface IAnimal
    {
        void See();
        void Eat();
    }

    public interface IFly
    {
        void Fly();
    }

    public interface IRun
    {
        void Run();
    }
}
