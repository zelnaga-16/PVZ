using Model.General;
using Model.General.Effects;
using Model.General.Entity;
using Model.Plants.Units;

namespace Model.Zombies.Units;

public abstract class Zombie : GameEntity, IAction, IHittable
{
    public event Action? OnAction;
    public bool IsPlantable { get; private set; }

    private Move _move;
    private Health _health;
    private int _cost;
    protected List<IEffect> Effects { get; set; } = new List<IEffect>();

    public Zombie(Game game, Vector2 position, float maxHealth, float moveSpeed,  int cost) : base(game)
    {
        Transform.Size = new Vector2(1, 1);
        Transform.Position = new Vector2(position.X - Transform.Size.X * 0.5, position.Y);
        _move = new Move(this, -moveSpeed);
        
        _health = new Health(maxHealth, Destroy);
        _cost = cost;

        Logger.Log($"zombie {{{this}}} has been spawned");
    }

    public override void Update()
    {
        base.Update();
        _move.MoveEntity(Game.Tick);
    }

    protected override GameEntity IsHitBoxEnter<T>()
    {
        return base.IsHitBoxEnter<T>();
    }

    public void Action()
    {
        OnAction?.Invoke();
    }

    public void Hit(float damage)
    {
        _health.TakeDamage(damage);
    }

    public override string ToString()
    {
        return $"{GetType().Name}";
    }
}