using Model.General;
using Model.General.Entity;
using Model.Zombies.Units;
using System.Runtime.InteropServices;

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
        Game.zombieCount[zombie.Transform.Position.Y - 1]++;
    }
    
}
