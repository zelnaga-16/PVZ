using Model.General;
using Model.General.Entity;
using Model.Plants.Units;
using Model.Zombies.Units;

namespace Model.Zombies;

public class ZombiesFabric : EntitiesFabric
{
    public ZombiesFabric(Game game) : base(game) { }
    public Zombie CreateBasicZombie(Vector2 position)
    {
        Zombie zombie = new BasicZombie(Game, position);

        Game.GameEntities.Add(zombie);
        return zombie;
    }
}
