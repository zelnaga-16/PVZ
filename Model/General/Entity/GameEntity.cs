using Model.General.LogTools;

namespace Model.General.Entity;

public abstract class GameEntity
{
    public event Action? OnDestroy;
    public event Action? OnHitBoxEnter;
    private Vector2 _position;

    public Vector2 Position
    {
        get { return _position; }
        set { _position = value; }
    }
    protected static readonly ILogger Logger;

    static GameEntity()
    {
        Logger = GetLogger.GetLoggerInstance();
    }

    public abstract void Update();
    protected virtual void Destroy() => OnDestroy?.Invoke();
    protected virtual void HitBoxEnter(GameEntity other) => OnHitBoxEnter?.Invoke();
}