using Model.Zombies.Units;

namespace Model.General.Entity;

public class EntityList : List<GameEntity>
{
    private Game _game;

    public EntityList(Game game)
    {
        _game = game;
    }

    public new void Add(GameEntity entity)
    {
        _game.ToAddList.Add(entity);
        entity.OnDestroy += () => _game.ToRemoveList.Add(entity);
    }

    public void AddList(List<GameEntity> toAdd)
    {
        foreach (GameEntity entity in toAdd)
            base.Add(entity);

        toAdd.Clear();
    }

    public void UpdateEntities()
    {

        foreach (GameEntity entity in this)
        {
            entity.Update();
            if (entity is Zombie) 
            {
            
            }
            
        }
    }

    public void RemoveList(List<GameEntity> toDelete)
    {
        foreach (GameEntity entity in toDelete)
            Remove(entity);

        toDelete.Clear();
    }
}
