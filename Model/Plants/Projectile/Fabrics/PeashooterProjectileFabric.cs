using Model.General;
using Model.General.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model.Plants.Projectile.Fabrics;

public class PeashooterProjectileFabric : BaseFabric
{
    public PeashooterProjectileFabric(Game game) : base(game) { }

    public override GameEntity? TryCreate(Vector2 position)
    {
        PeashooterProjectile projectile = new PeashooterProjectile(Game, position);
        Game.GameEntities.Add(projectile);
        return projectile;
    }
}
