namespace Model.General.Entity;

public class EntityList : List<GameEntity>
{
    public new void Add(GameEntity entity)
    {
        base.Add(entity);

        entity.OnDestroy += () => Remove(entity);
    }
}
