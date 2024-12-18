using Model.General;
using Model.General.Entity;
using Model.Plants.Units;

namespace Model.Plants.Fabrics;

public class PeashooterFabric : PlantFabric
{
    public PeashooterFabric(Game game) : base(game, 10, 100) { }
    public override GameEntity? TryCreate(Vector2 position)
    {
        if (IsPlantable())
        {
            Plant plant = new Peashooter(Game, position);
            Plant(plant);
            return plant;
        }

        return null;
    }
}
