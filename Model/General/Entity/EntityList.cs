namespace Model.General.Entity;

public class EntityList : List<GameEntity>
{
    public new void Add(GameEntity entity)
    {
        base.Add(entity);

        entity.OnDestroy += () => Remove(entity);
    }
    public void UpdateEntities() 
    {
        foreach (GameEntity entity in this) 
        {
            entity.Update();
        }
    }
}
