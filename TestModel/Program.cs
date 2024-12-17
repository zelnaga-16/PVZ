using Model.General;
using Model.Zombies.Units;

namespace TestModel
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Game game = new Game();
            game.GameEntities.Add(new BasicZombie(game,new Model.General.Entity.Vector2(10.96,2),100,1,13));
            while (game.GameEntities.Count > 0) 
            {
                game.GameTick();
            }
            
            Console.WriteLine("Hello, World!");
        }
    }
}
