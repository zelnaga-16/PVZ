using Model.General;
using Model.General.Entity;
using Model.Zombies.Units;

namespace Model.Plants.Projectile;

public class Projectile : GameEntity
{
    protected Attack Attack { get; private set; }
    private Move _move;

    public Projectile(Game game, Vector2 position, float damage, float moveSpeed) : base(game)
    {
        Transform.Position = position;
        Transform.Size = new Vector2(0.5, 1);
        Attack = new Attack(damage);
        _move = new Move(this, moveSpeed);
    }

    public override void Update()
    {
        base.Update();
        _move.MoveEntity(Game.Tick);
    }

    protected override void HitBoxEnter(GameEntity other)
    {
        base.HitBoxEnter(other);

        if (other is Zombie zombie)
        {
            Attack.AttackEntity(zombie);
            Destroy();
        }
    }

    protected override GameEntity IsHitBoxEnter<T>()
    {
        return base.IsHitBoxEnter<Zombie>();
    }
}