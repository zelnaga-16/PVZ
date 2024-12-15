namespace Model.Zombies.Units;

public class BasicZombie : Zombie
{
    public BasicZombie()
    {

        InnitialCost = 1;
        Damage = 0;
        AppliedEffect = null;
        Health = 100;
    }
}
