using Model.General;
using Model.General.Entity;

namespace Model.Zombies.Units;

public class BucketheadZombie : Zombie
{
    public BucketheadZombie(Game game, Vector2 position) : base(game, position, 175, 0.3f, 1) { }
}
