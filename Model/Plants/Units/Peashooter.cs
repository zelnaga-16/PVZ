using Model.General;
using Model.General.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model.Plants.Units;

public class Peashooter : Plant, IShoot
{


    public Peashooter(Game game, Vector2 position) : base(game, position, 25, 3, 10, 100)
    {

    }

    public void Shoot()
    {
        
    }
}
