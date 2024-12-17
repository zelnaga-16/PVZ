using Model.General.LogTools;

namespace Model.General.Entity;

public abstract class GameEntity
{
    public event Action? OnDestroy;
    public event Action? OnHitBoxEnter;

    public Transform Transform { get; set; }
    protected Game Game { get; set; }
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

    public virtual void Update(double tick)
    {

    }

    protected virtual void Destroy() => OnDestroy?.Invoke();
    protected virtual void HitBoxEnter(GameEntity other) => OnHitBoxEnter?.Invoke();

    public override string ToString()
    {
        return $"{GetType().Name}";
    }
}