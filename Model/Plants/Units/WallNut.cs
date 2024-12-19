using Model.General;
using Model.General.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model.Plants.Units;

public class WallNut : Plant
{
    public WallNut(Game game, Vector2 position) : base(game, position, 70, 999)
    {
    }
}
