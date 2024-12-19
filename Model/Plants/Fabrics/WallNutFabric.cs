using Model.General.Entity;
using Model.General;
using Model.Plants.Units;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model.Plants.Fabrics;

internal class WallNutFabric : PlantFabric
{
    public WallNutFabric(Game game) : base(game, 20, 50) { }
    public override GameEntity? TryCreate(Vector2 position)
    {
        if (IsPlantable())
        {
            Plant plant = new SunFlower(Game, position);
            Plant(plant);
            return plant;
        }

        return null;
    }
}
