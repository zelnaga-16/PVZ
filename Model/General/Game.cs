﻿using Model.General.Entity;
using Model.Plants.Fabrics;
using Model.Zombies.Fabric;
using Model.Zombies.Fabrics;

namespace Model.General;

public class Game
{
    public EntityList GameEntities { get; private set; }
    public List<GameEntity> ToRemoveList { get; private set; }
    public List<GameEntity> ToAddList { get; private set; }
    private List<ZombieFabric> _zombieFabrics { get; set; }
    public Dictionary<string, PlantFabric> PlantFabrics { get; set; }
    public List<int> zombieCount { get; set; }
    public int Suns { get; private set; } = 100;
    public int ZombiePool { get; private set; } = 50;
    public int WavePool { get; private set; } = 1;
    public double Tick = 20 * 0.001;
    private DateTime _lastTick = DateTime.UtcNow;

    public bool IsGameEnded = false;
    public bool IsGameWinned = false;


    public Game(List<string> plantNames)
    {
        GameEntities = new EntityList(this);

        ToRemoveList = new List<GameEntity>();
        ToAddList = new List<GameEntity>();

        _zombieFabrics = [
            new BasicZombieFabric(this),
            new ConeheadZombieFabric(this),
            new BucketheadZombieFabric(this)
        ];

        zombieCount = new List<int>()
        {0,0,0,0};

        PlantFabrics = new Dictionary<string, PlantFabric>();
        foreach (string plantName in plantNames)
        {
            PlantFabric fabric = SelectFabric(plantName);
            if (fabric == null)
            {
                continue;
            }
            PlantFabrics.Add(plantName.ToLower(), fabric);
        }
    }
    private PlantFabric SelectFabric(string plantName)
    {
        switch (plantName.ToLower())
        {
            case "sunflower":
                return new SunFlowerFabric(this);
            case "peashooter":
                return new PeashooterFabric(this);
            case "wallnut":
                return new WallNutFabric(this);
        }

        return null;
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
        if (!IsAnyZombieOnRow(1) && !IsAnyZombieOnRow(2) && !IsAnyZombieOnRow(3) && !IsAnyZombieOnRow(4))
        {
            CreateWave();
        }
    }
    public void CreateWave()
    {
        if (ZombiePool <= 0)
        {
            IsGameWinned = true;
            IsGameEnded = true;
            return;
        }
        Random random = new Random();
        int prevPool = WavePool * 2;
        while (WavePool > 0)
        {
            int zombieId = int.MaxValue;
            while (WavePool < zombieId)
            {
                zombieId = random.Next(_zombieFabrics.Count > WavePool ? WavePool : _zombieFabrics.Count);
            }
            _zombieFabrics[zombieId].TryCreate(new Vector2((random.NextDouble() * 2) + 11, random.Next(1, 5)));
        }
        WavePool = ZombiePool - prevPool > 0 ? prevPool : ZombiePool;
        ZombiePool -= prevPool;
    }

    #region game state methods

    public bool IsAnyZombieOnRow(int row)
    {
        if (zombieCount[row - 1] > 0)
        {
            return true;
        }
        return false;
    }

    #endregion

    public void IncreaseSun(int suns) => Suns += suns;
    public void DecreaseSun(int suns) => Suns -= suns;

    public void DeacreaseZoombiePool(int value) => WavePool -= value;
}
