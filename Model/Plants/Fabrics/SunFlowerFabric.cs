using Model.General;
using Model.General.Entity;
using Model.Plants.Units;

namespace Model.Plants.Fabrics;

public class SunFlowerFabric : PlantFabric
{
    public SunFlowerFabric(Game game) : base(game, 15, 50) { }
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