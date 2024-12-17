using Model.General;
using Model.General.Entity;

namespace Model.Zombies.Units;

public class BasicZombie : Zombie
{
    public BasicZombie(Game game, Vector2 position) : base(game, position, 100, 0.3f, 1) { }
    public override void Update(double tick)
    {
        base.Update(tick);
        Logger.Log("x: " + Transform.Position.X);
    }
}
