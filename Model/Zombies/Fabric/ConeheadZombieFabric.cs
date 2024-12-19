using Model.General;
using Model.General.Entity;
using Model.Zombies.Fabrics;
using Model.Zombies.Units;

namespace Model.Zombies.Fabric;

public class ConeheadZombieFabric : ZombieFabric
{
    public ConeheadZombieFabric(Game game) : base(game, 2) { }

    public override GameEntity? TryCreate(Vector2 position)
    {
        Zombie zombie = new ConeheadZombie(Game, position);
        Spawn(zombie);
        return zombie;
    }
    
}
