using Model.General.LogTools;

namespace Model.General.Entity;

public abstract class GameEntity
{
    public event Action? OnDestroy;
    public event Action? OnHitBoxEnter;

    public Vector2 Position;
    protected static readonly ILogger Logger;

    static GameEntity()
    {
        Logger = GetLogger.GetLoggerInstance();
    }

    public virtual void Update() { }
    protected virtual void Destroy() => OnDestroy?.Invoke();
    protected virtual void HitBoxEnter(GameEntity other) => OnHitBoxEnter?.Invoke();
}