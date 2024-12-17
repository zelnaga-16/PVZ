namespace Model.General.Entity;

public interface IAction
{
    event Action? OnAction;
    void Action();
}