using Model.General;
using Model.General.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model.Zombies.Units;

public  class BasicZombie : Zombie
{
    public BasicZombie(Game game, Vector2 position, float maxHealth, float moveSpeed, int cost) : base(game, position, maxHealth, moveSpeed, cost)
    {

    }
    public override void Update(double tick)
    {
        base.Update(tick);
        Logger.Log("x: " + Transform.Position.X);
    }
}
