using Model.General.Effects;
using Model.General.Entity;

namespace Model.Zombies.Units;

public abstract class Zombie : GameEntity, IAction
{
    public event Action? OnAction;
    public bool IsPlantable { get; private set; }

    private Health _health;
    private int _cost;
    protected List<IEffect> Effects { get; set; } = new List<IEffect>();

    public Zombie(Vector2 position, float maxHealth,  int cost)
    {
        Position = position;
        
        _health = new Health(maxHealth, Destroy);
        _cost = cost;

        Logger.Log($"plant {{{this}}} has been planted");
    }

    public void Action()
    {
        throw new NotImplementedException();
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
