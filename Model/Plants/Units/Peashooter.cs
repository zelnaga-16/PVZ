using Model.General;
using Model.General.Entity;
using Model.Plants.Projectile;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model.Plants.Units;

public class Peashooter : Plant, IShoot
{
    private ProjectileFabric _fabric;

    public Peashooter(Game game, Vector2 position) : base(game, position, 25, 3, 10, 100)
    {
        _fabric = new ProjectileFabric(game);
    }

    public override void Action()
    {
        base.Action();
        Shoot();
    }

    public void Shoot()
    {
        Logger.Log("Shoot");
        _fabric.CreatePeashooterProj(Transform.Position);
    }
}
