using Model.General;
using Model.General.Entity;
using Model.Plants.Units;

namespace Model.Plants;

public class PlantsFabric : EntitiesFabric
{
    public PlantsFabric(Game game) : base(game) { }
    public Plant CreateSunFlower(Vector2 position)
    {
        Plant plant = new SunFlower(Game, position);

        //Game.GameEntities.Add(plant);
        return plant;
    }

    public Plant CreatePeashooter(Vector2 position)
    {
        Plant plant = new Peashooter(Game, position);

        //Game.GameEntities.Add(plant);
        return plant;
    }
}
