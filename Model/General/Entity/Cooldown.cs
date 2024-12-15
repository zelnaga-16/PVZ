using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model.General.Entity;

public struct Cooldown
{
    public event Action? OnCooldown;
    private float _trueCooldown, _cooldown;

    public Cooldown(float cooldown, Action onCooldown)
    {
        _cooldown = cooldown;
        _trueCooldown = cooldown;
        OnCooldown += onCooldown;
    }

    public void Tick()
    {
        if (_trueCooldown <= 0)
        {
            _trueCooldown = _cooldown;
            OnCooldown?.Invoke();
        }
        else
            _trueCooldown -= Constants.Tick;
    }
}
