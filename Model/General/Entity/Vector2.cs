namespace Model.General.Entity;

public struct Vector2 : IEquatable<Vector2>
{
    public double X { get; set; }
    public int Y { get; set; }

    public Vector2(double x, int y)
    {
        X = x;
        Y = y;
    }

    public static double GetDistanceBeetweenVectors(Vector2 a, Vector2 b) => Math.Sqrt(Math.Pow(a.X - b.X, 2) + Math.Pow(a.Y - b.Y, 2));

    public static bool operator ==(Vector2 a, Vector2 b) 
    {

        if (a.X != b.X || a.Y != b.Y) return false;
        return true;
    }
    public static bool operator !=(Vector2 a, Vector2 b) 
    {
        if (a.X == b.X || a.Y == b.Y) return false;
        return true;
    }
    public bool Equals(Vector2 other)
    {
        if(X != other.X || Y != other.Y) return false;
        return true;
    }
}
