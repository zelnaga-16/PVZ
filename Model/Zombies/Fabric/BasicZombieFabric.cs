using Model.General;
using Model.General.Entity;
using Model.Zombies.Fabrics;
using Model.Zombies.Units;

namespace Model.Zombies.Fabric;

public class BasicZombieFabric : ZombieFabric
{
    public BasicZombieFabric(Game game) : base(game, 1) { }

    public override GameEntity? TryCreate(Vector2 position)
    {
        Zombie zombie = new BasicZombie(Game, position);
        Spawn(zombie);
        return zombie;
    }
    
}
