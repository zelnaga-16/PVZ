using Model.General;
using Model.General.Entity;
using Model.Plants.Units;

namespace Model.Plants.Fabrics;

public abstract class PlantFabric : BaseFabric
{
    public Cooldown PlantCooldown;
    public int Cost;
    public bool IsRecoveried = true;

    public PlantFabric(Game game, float plantCooldown, int cost) : base(game)
    {
        PlantCooldown = new Cooldown(plantCooldown, () => IsRecoveried = true);
        Cost = cost;
    }

    public virtual void Plant(Plant plant)
    {
        IsRecoveried = false;
        Game.DecreaseSun(Cost);
        Game.GameEntities.Add(plant);
    }

    public override void Update()
    {
        base.Update();

        if (!IsRecoveried)
        {
            PlantCooldown.Tick(Game.Tick);
        }
    }

    public bool IsPlantable() => IsRecoveried && Cost <= Game.Suns;
}
