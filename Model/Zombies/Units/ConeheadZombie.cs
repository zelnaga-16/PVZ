using Model.General;
using Model.General.Entity;

namespace Model.Zombies.Units;

public class ConeheadZombie : Zombie
{
    public ConeheadZombie(Game game, Vector2 position) : base(game, position, 125, 0.3f, 1) { }
}
