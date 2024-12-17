using Model.General;
using Model.General.Effects;
using Model.General.Entity;

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
        Transform.Position = position;
        _move = new Move(this, moveSpeed);
        
        _health = new Health(maxHealth, Destroy);
        _cost = cost;

        Logger.Log($"zombie {{{this}}} has been spawned");
    }

    public override void Update(double tick)
    {
        base.Update(tick);
        _move.MoveEntity(tick);
    }

    public void Action()
    {
        OnAction?.Invoke();
    }

    public void Hit(float damage)
    {
        _health.TakeDamage(damage);
    }
}