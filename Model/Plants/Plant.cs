using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model.Plants;

public abstract class Plant
{
    protected int Health {  get; set; }
    protected int Damage { get; set; }
    protected AttackType.Attack Attack { get; set; }
}
