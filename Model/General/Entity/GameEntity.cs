using Model.General.LogTools;
using System.Xml.Linq;

namespace Model.General.Entity;

public abstract class GameEntity
{
    public event Action? OnDestroy;
    public event Action? OnHitBoxEnter;

    public Transform Transform { get; set; }
    protected Game Game { get; set; }
    protected bool IsICollide { get; set; } = false;
    protected static readonly ILogger Logger;

    public GameEntity(Game game)
    {
        Game = game;
        Transform = new Transform();
    }

    static GameEntity()
    {
        Logger = GetLogger.GetLoggerInstance();
    }

    public virtual void Update()
    {
        IsHitBoxEnter<GameEntity>();
    }

    protected virtual GameEntity IsHitBoxEnter<T>()
    {
        foreach (GameEntity entity in Game.GameEntities)
        {
            if (entity is not T || entity == this)
                continue;

            if (Transform.isInside(entity.Transform))
            {
                Logger.Log($"{this}, collide with {entity}");
                HitBoxEnter(entity);
                return entity;
            }
        }

        IsICollide = false;
        return null!;
    }

    protected virtual void Destroy() => OnDestroy?.Invoke();
    protected virtual void HitBoxEnter(GameEntity other)
    {
        IsICollide = true;
        OnHitBoxEnter?.Invoke();
    }
    public override string ToString()
    {
        return $"{GetType().Name}";
    }
}