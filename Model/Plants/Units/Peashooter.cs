using Model.General;
using Model.General.Entity;
using Model.Plants.Projectile;
using Model.Plants.Projectile.Fabrics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model.Plants.Units;

public class Peashooter : Plant, IShoot
{
    BaseFabric _projectileFabric;

    public Peashooter(Game game, Vector2 position) : base(game, position, 25, 3)
    {
        _projectileFabric = new PeashooterProjectileFabric(Game);
    }
     
    public override void Action()
    {
        base.Action();

        if (Game.IsAnyZombieOnRow(Transform.Position.Y))
        {
            Shoot(_projectileFabric);
        }

        Logger.Log($"IsAnyZombieOnRow({Transform.Position.Y}): {Game.IsAnyZombieOnRow(Transform.Position.Y)}");
    }

    public void Shoot(BaseFabric projectileFabric)
    {
        _projectileFabric.TryCreate(Transform.Position);
        Logger.Log("Shoot");
    }
}
