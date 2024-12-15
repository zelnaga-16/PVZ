namespace Model.General;

public static class Constants
{
    public static double Tick = 0.01f;
    private static DateTime _lastTick = DateTime.UtcNow;

    public static void CalculateTick(DateTime tickNow) 
    {
        Tick = (tickNow - _lastTick).TotalMilliseconds * 0.001f;
        _lastTick = tickNow;
        
    }
}
