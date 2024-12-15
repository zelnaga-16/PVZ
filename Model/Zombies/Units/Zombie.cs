using Model.General.Effects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model.Zombies.Units;

public abstract class Zombie
{
    protected int Health { get; set; }
    protected int Damage { get; set; }
    protected IEffect? AppliedEffect { get; set; }
    protected int InnitialCost { get; set; }
    protected List<IEffect> effects { get; set; } = new List<IEffect>();
}
