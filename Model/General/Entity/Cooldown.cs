using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model.General.Entity;

public struct Cooldown
{
    public event Action? OnCooldown;
    public bool IsActive { get; set; }
    private double _trueCooldown, _cooldown;

    public Cooldown(double cooldown, Action onCooldown)
    {
        _cooldown = cooldown;
        _trueCooldown = cooldown;
        IsActive = true;
        OnCooldown += onCooldown;
    }
    
    public void Tick(double tick)
    {
        if (!IsActive)
            return;

        if (_trueCooldown <= 0)
        {
            _trueCooldown += _cooldown;
            OnCooldown?.Invoke();
        }
        else
        {
            _trueCooldown -= tick;
        }
    }
}
