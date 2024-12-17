using Model.General;
using Model.General.Entity;

namespace Model.Plants.Units;

public class SunFlower : Plant
{
    public SunFlower(Game game, Vector2 position) : base(game, position, 25, 15, 15, 50)  { }
    public override void Action()
    {
        Game.IncreaseSun(25);
        base.Action();

    }
}
