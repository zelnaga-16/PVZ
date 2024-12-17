using Model.General.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model.General;

public class Game
{
    public EntityList GameEntities { get; private set; }
    public List<GameEntity> ToRemoveList { get; private set; }
    public List<GameEntity> ToAddList { get; private set; }
    public int Suns { get; private set; }

    public double Tick = 0;
    private DateTime _lastTick = DateTime.UtcNow;

    public Game()
    {
        GameEntities = new EntityList(this);
        ToRemoveList = new List<GameEntity>();
        ToAddList = new List<GameEntity>();
        CalculateTick(DateTime.Now);
    }

    private void CalculateTick(DateTime tickNow)
    {
        //tickNow = DateTime.Now; // just to have backup
        Tick = (tickNow - _lastTick).TotalMilliseconds * 0.001;
        _lastTick = tickNow;
    }

    public void GameTick(DateTime tickNow)
    {
        CalculateTick(tickNow);
        GameEntities.UpdateEntities();
        GameEntities.RemoveList(ToRemoveList);
        GameEntities.AddList(ToAddList);
    }

    public void IncreaseSun(int suns) => Suns += suns;
    public void DecreaseSun(int suns) => Suns -= suns;
}
