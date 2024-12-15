

using Model.General;
using Model.General.Entity;
using Model.Plants.Units;

namespace TestModel;

internal class Program
{
    static void Main(string[] args)
    {
        EntityList gameEntities = [new SunFlower()];
        Constants.CalculateTick(DateTime.Now);
        while (true) 
        {
            Constants.CalculateTick(DateTime.Now);
            gameEntities.UpdateEntities();
            Thread.Sleep(50);
        }
    }
}
