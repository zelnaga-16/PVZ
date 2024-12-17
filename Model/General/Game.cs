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
    public int Suns { get; private set; }

    private double _tick = 0;
    private DateTime _lastTick = DateTime.UtcNow;

    public Game() 
    {
        GameEntities = new EntityList();
        CalculateTick(DateTime.Now);
    }
    private void CalculateTick(DateTime tickNow)
    {
        _tick = (tickNow - _lastTick).TotalMilliseconds * 0.001;
        _lastTick = tickNow;
    }

    public void GameTick()
    {
        CalculateTick(DateTime.Now);
        GameEntities.UpdateEntities(_tick);
    }

    public void IncreaseSun(int suns) => Suns += suns;
    public void DecreaseSun(int suns) => Suns -= suns;
}
