using Model.General;
using Model.General.Effects;
using Model.General.Entity;
using Model.Plants.Units;

namespace Model.Zombies.Units;

public abstract class Zombie : GameEntity, IAction, IHittable
{
    public event Action? OnAction;
    public bool IsPlantable { get; private set; }

    protected Cooldown ActionCooldown;
    protected Plant? FrontPlant { get; set; }
    private Move _move;
    private Health _health;
    private int _cost;
    protected List<IEffect> Effects { get; set; } = new List<IEffect>();

    public Zombie(Game game, Vector2 position, float maxHealth, float moveSpeed,  int cost) : base(game)
    {
        Transform.Size = new Vector2(0.3, 1); ;
        Transform.Position = new Vector2(position.X - Transform.Size.X * 0.5, position.Y);
        _move = new Move(this, -moveSpeed);

        ActionCooldown = new Cooldown(1.2, Action);
        _health = new Health(maxHealth, Destroy);
        _cost = cost;

        Logger.Log($"zombie {{{this}}} has been spawned, on x:{Transform.Position.X} y:{Transform.Position.Y}");
    }

    public override void Update()
    {
        base.Update();

        if (FrontPlant == null)
        {
            ActionCooldown.IsActive = false;
            _move.MoveEntity(Game.Tick);
            if (Transform.Position.X <= 0)
            {
                Game.IsGameEnded = true;
            }
        }
        else
        {
            ActionCooldown.IsActive = true;
            ActionCooldown.Tick(Game.Tick);
        }
    }

    protected override GameEntity IsHitBoxEnter<T>()
    {
        FrontPlant = (Plant)base.IsHitBoxEnter<Plant>();
        return FrontPlant;
    }
    protected override void Destroy()
    {
        Game.zombieCount[Transform.Position.Y - 1]--;
        base.Destroy();
    }

    public void Action()
    {
        OnAction?.Invoke();
        Logger.Log(FrontPlant.ToString());
        FrontPlant?.Hit(4);
    }

    public void Hit(float damage)
    {
        _health.TakeDamage(damage);
    }
}