namespace Model.General.Entity;

public class EntityList : List<GameEntity>
{
    public new void Add(GameEntity entity)
    {
        base.Add(entity);

        entity.OnDestroy += () => Remove(entity);
    }
    public void UpdateEntities(double tick) 
    {
        if (this.Count<=0) return; 
        foreach (GameEntity entity in this) 
        {
            entity.Update(tick);
        }
    }
}
