using Model.Plants.AttackType;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Net.Mime.MediaTypeNames;

namespace Model.Zombies.Units;

public class BasicZombie : Zombie
{
    public BasicZombie() 
    {

        InnitialCost = 1;
        Damage = 0;
        AppliedEffect = null;
        Health = 100;
    }
}
