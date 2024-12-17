using Model.General;
using Model.General.Effects;
using Model.General.Entity;
using Model.General.LogTools;

namespace Model.Plants.Units;

public abstract class Plant : GameEntity, IAction, IHittable
{
    public event Action? OnAction;
    public bool IsPlantable { get; private set; }

    private Health _health;
    private Cooldown _actionCooldown;
    private Cooldown _plantCooldown;
    private int _cost;
    protected List<IEffect> Effects { get; set; } = new List<IEffect>();

    public Plant(Game game, Vector2 position, float maxHealth, float actionCooldown, float plantCooldown, int cost) : base(game)
    {
        Transform.Position = position;
        game.DecreaseSun(_cost);

        _health = new Health(maxHealth, Destroy);
        _actionCooldown = new Cooldown(actionCooldown, Action);
        _plantCooldown = new Cooldown(plantCooldown, () => IsPlantable = true);
        _cost = cost;

        Logger.Log($"plant {{{this}}} has been planted");
    }

    public override void Update(double tick)
    {
        base.Update(tick);
        _actionCooldown.Tick(tick);

        if (!IsPlantable)
            _plantCooldown.Tick(tick);
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