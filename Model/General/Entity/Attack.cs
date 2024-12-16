namespace Model.General.Entity;

public struct Attack
{
    private float _damage;
    public Attack(float damage) => _damage = damage;

    public void AttackEntity(GameEntity entity)
    {
        if(entity is IHittable hittable)
            hittable.Hit(_damage);   
    }
}