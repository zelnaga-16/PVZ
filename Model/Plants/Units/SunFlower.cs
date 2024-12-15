﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model.Plants.Units;

public class SunFlower : Plant
{
    public SunFlower() 
    {
        Cost = 25;
        Damage = 0;
        Attack = null;
        AppliedEffect = null;
        Health = 100;
    }
}
