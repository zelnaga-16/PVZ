using Model.General;
using Model.General.Entity;
using Model.Plants.Units;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model.Plants.Projectile;

public class ProjectileFabric : EntitiesFabric
{
    public ProjectileFabric(Game game) : base(game) { }

    public Projectile CreatePeashooterProj(Vector2 position)
    {
        Projectile plant = new PeashooterProjectile(Game, position);

        Game.GameEntities.Add(plant);
        return plant;
    }
}