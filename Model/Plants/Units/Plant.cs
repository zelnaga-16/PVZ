using Model.General.Effects;
using Model.General.Entity;
using Model.General.LogTools;

namespace Model.Plants.Units;

public abstract class Plant : GameEntity, IAction
{
    public event Action? OnAction;
    public bool IsPlantable { get; private set; }

    private Health _health;
    private Cooldown _actionCooldown;
    private Cooldown _plantCooldown;
    private int _cost;
    protected List<IEffect> Effects { get; set; } = new List<IEffect>();

    public Plant(float maxHealth, float actionCooldown, float plantCooldown, int cost)
    {
        _health = new Health(maxHealth, Destroy);
        _actionCooldown = new Cooldown(actionCooldown, Action);
        _plantCooldown = new Cooldown(plantCooldown, () => IsPlantable = true);
        _cost = cost;

        Logger.Log($"plant {{{this}}} has been planted");
    }

    public override void Update()
    {
        _actionCooldown.Tick();
        _plantCooldown.Tick();
    }
    public virtual void Action()
    {
        OnAction?.Invoke();
        Console.WriteLine(DateTime.UtcNow.ToString());
        Logger.Log($"plant {{{this}}} did something");
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