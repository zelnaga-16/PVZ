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
}
