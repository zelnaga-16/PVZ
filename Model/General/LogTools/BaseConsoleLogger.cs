namespace Model.General.LogTools;

public class BaseConsoleLogger : ILogger
{
    public void Log(string message) => Console.WriteLine(message);
}
