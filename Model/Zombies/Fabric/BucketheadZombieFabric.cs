using Model.General;
using Model.General.Entity;
using Model.Zombies.Fabrics;
using Model.Zombies.Units;

namespace Model.Zombies.Fabric;

public class BucketheadZombieFabric : ZombieFabric
{
    public BucketheadZombieFabric(Game game) : base(game, 3) { }

    public override GameEntity? TryCreate(Vector2 position)
    {
        Zombie zombie = new BucketheadZombie(Game, position);
        Spawn(zombie);
        return zombie;
    }
    
}
