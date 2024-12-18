using Model.General.Entity;
using Model.Plants.Fabrics;
using Model.Zombies.Units;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization.Formatters;
using System.Text;
using System.Threading.Tasks;

namespace Model.General;

public class Game
{
    public EntityList GameEntities { get; private set; }
    public List<GameEntity> ToRemoveList { get; private set; }
    public List<GameEntity> ToAddList { get; private set; }
    public int Suns { get; private set; } = 50;
    public int ZoombiePool { get; private set; } = 100;
    public double Tick = 50 * 0.001;
    private DateTime _lastTick = DateTime.UtcNow;


    public Game()
    {
        GameEntities = new EntityList(this);

        ToRemoveList = new List<GameEntity>();
        ToAddList = new List<GameEntity>();
    }

    private void CalculateTick()
    {
        DateTime tickNow = DateTime.Now;
        Tick = (tickNow - _lastTick).TotalMilliseconds * 0.001;
        _lastTick = tickNow;
    }

    public void GameTick()
    {
        GameEntities.UpdateEntities();
        GameEntities.LateUpdateEntities();
    }

    #region game state methods

    public bool IsAnyZombieOnRow(int row)
    {
        foreach(GameEntity entity in GameEntities)
            if(entity is Zombie && entity.Transform.Position.Y == row)
                return true;

        return false;
    }

    #endregion

    public void IncreaseSun(int suns) => Suns += suns;
    public void DecreaseSun(int suns) => Suns -= suns;

    public void DeacreaseZoombiePool(int value) => ZoombiePool -= value;
}
