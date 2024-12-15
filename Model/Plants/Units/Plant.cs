using Model.General.Effects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model.Plants.Units;

public abstract class Plant
{
    protected int Health { get; set; }
    protected int Damage { get; set; }
    protected AttackType.Attack? Attack { get; set; }
    protected IEffect? AppliedEffect { get; set; }  
    protected int Cost { get; set; }
    protected List<IEffect> effects { get; set; } = new List<IEffect>();
}
