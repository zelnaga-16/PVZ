using Model.General;
using Model.General.Entity;

namespace Model.Zombies.Units;

public class BasicZombie : Zombie
{
    public BasicZombie(Game game, Vector2 position) : base(game, position, 75, 0.3f, 1) { }
}
