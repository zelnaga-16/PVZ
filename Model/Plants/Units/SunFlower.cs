using Model.General.Entity;

namespace Model.Plants.Units;

public class SunFlower : Plant
{
    public SunFlower(Vector2 position) : base(position, 25, 3, 15, 50)  { }
    public override void Action()
    {
        base.Action();
    }
}
