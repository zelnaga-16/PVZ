namespace Model.General.Entity;

public class Transform
{
    public Vector2 Position { get; set; }
    public Vector2 Size { get; set; }

    public Transform()
    {
        Position = new Vector2();
        Size = new Vector2();
    }

    public bool isInside(Transform other)
    {

        if (Position.Y != other.Position.Y) return false;

        if (Position.X == other.Position.X)
            return true;

        if (Position.X < other.Position.X && (Position.X + Size.X / 2) >= (other.Position.X - other.Size.X / 2))
            return true;

        if (Position.X > other.Position.X && (other.Position.X + other.Size.X / 2) >= (Position.X - Size.X / 2))
            return true;

        return false;
    }
}
