using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model.General.Entity;

public struct Health
{
    private float _maxHealth, _health;
    private Action _death;

    public Health(float maxHealth, Action death)
    {
        _maxHealth = maxHealth;
        _health = maxHealth;
        _death = death;
    }

    public void TakeDamage(float damage)
    {
        _health -= damage;

        if(_health <= 0)
        {
            _death.Invoke();
        }
    }
}
