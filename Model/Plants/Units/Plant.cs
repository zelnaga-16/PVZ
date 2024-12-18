using Model.General;
using Model.General.Effects;
using Model.General.Entity;
using Model.General.LogTools;
using Model.Zombies.Units;

namespace Model.Plants.Units;

public abstract class Plant : GameEntity, IAction, IHittable
{
    public event Action? OnAction;
    private Health _health;

    protected Cooldown ActionCooldown;
    protected List<IEffect> Effects { get; set; } = new List<IEffect>();

    public Plant(Game game, Vector2 position, float maxHealth, float actionCooldown) : base(game)
    {
        Transform.Size = new Vector2(0.8, 1);
        Transform.Position = new Vector2(position.X - 0.5, position.Y);

        _health = new Health(maxHealth, Destroy);
        ActionCooldown = new Cooldown(actionCooldown, Action);

        Logger.Log($"plant {{{this}}} has been planted, on x:{Transform.Position.X} y:{Transform.Position.Y}");
    }

    public override void Update()
    {
        base.Update();
        ActionCooldown.Tick(Game.Tick);
    }

    protected override GameEntity IsHitBoxEnter<T>()
    {
        return base.IsHitBoxEnter<Plant>();
    }

    public virtual void Action()
    {
        OnAction?.Invoke();
    }

    public void Hit(float damage)
    {
        _health.TakeDamage(damage);
    }
}