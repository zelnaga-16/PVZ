﻿using Model.General;
using Model.General.Entity;

namespace Model.Plants.Units;

public class SunFlower : Plant
{
    public SunFlower(Game game, Vector2 position) : base(game, position, 25, 10)  { }
    public override void Action()
    {
        base.Action();
        Game.IncreaseSun(25);
    }
}
