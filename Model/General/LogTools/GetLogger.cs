namespace Model.General.LogTools;

public class GetLogger
{
    private static ILogger? _logger;
    public static ILogger GetLoggerInstance() => _logger ??= new BaseConsoleLogger();
}
