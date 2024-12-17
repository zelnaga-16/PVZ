using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model.General.Entity;

public class Move
{
    private GameEntity _gameEntity;
    private float _moveSpeed;

    public Move(GameEntity gameEntity, float moveSpeed)
    {
        _gameEntity = gameEntity;
        _moveSpeed = moveSpeed;
    }

    public void MoveEntity(double tick)
    {
        _gameEntity.Transform.Position = new Vector2(_gameEntity.Transform.Position.X + _moveSpeed * tick, _gameEntity.Transform.Position.Y);
    }
}
