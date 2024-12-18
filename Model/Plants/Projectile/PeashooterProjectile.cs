using Model.General;
using Model.General.Entity;

namespace Model.Plants.Projectile;

public class PeashooterProjectile : Projectile
{
    public PeashooterProjectile(Game game, Vector2 position) : base(game, position, 15, 3) { }
}
