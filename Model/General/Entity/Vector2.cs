namespace Model.General.Entity;

public struct Vector2
{
    public double X { get; set; }
    public int Y { get; set; }

    public Vector2()
    {
        X = 0;
        Y = 0;
    }

    public Vector2(double x, int y)
    {
        X = x;
        Y = y;
    }

    public static double GetDistanceBeetweenVectors(Vector2 a, Vector2 b) => Math.Sqrt(Math.Pow(a.X - b.X, 2) + Math.Pow(a.Y - b.Y, 2));
}
