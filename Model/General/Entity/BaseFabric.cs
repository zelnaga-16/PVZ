using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model.General.Entity;

public abstract class BaseFabric : GameEntity
{
    public BaseFabric(Game game) : base(game)
    {
        Game = game;
    }

    public abstract GameEntity? TryCreate(Vector2 position);
}
