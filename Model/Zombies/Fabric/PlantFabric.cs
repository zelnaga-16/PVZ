using Model.General;
using Model.General.Entity;
using Model.Zombies.Units;

namespace Model.Zombies.Fabrics;

public abstract class ZombieFabric : BaseFabric
{
    public int Cost;

    public ZombieFabric(Game game, int cost) : base(game)
    {
        Cost = cost;
    }

    public virtual void Spawn(Zombie zombie)
    {
        Game.DeacreaseZoombiePool(Cost);
        Game.GameEntities.Add(zombie);
    }
}
