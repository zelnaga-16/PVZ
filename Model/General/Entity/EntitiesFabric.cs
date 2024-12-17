using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model.General.Entity;

public abstract class EntitiesFabric
{
    protected Game Game { get; set; }

    public EntitiesFabric(Game game)
    {
        Game = game;
    }
}
