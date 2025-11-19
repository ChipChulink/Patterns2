public interface ILogger
{
    public void Log(string message);
}

public class FileLogger : ILogger
{
    public void Log(string message)
    {
        Console.WriteLine($"File: {message}");
    }
}

public class ConsoleLogger : ILogger
{
    public void Log(string message)
    {
        Console.WriteLine($"Console: {message}");
    }
}

public abstract class StoreLogger
{
    protected ILogger _logger;

    public StoreLogger(ILogger logger)
    {
        _logger = logger;
    }

    public abstract void LogAction(string action);
}

public class OrderLogger : StoreLogger
{
    public OrderLogger(ILogger logger) : base(logger) { }

    public override void LogAction(string action)
    {
        _logger.Log($"[ORDER] {action}");
    }
}

public class UserLogger : StoreLogger
{
    public UserLogger(ILogger logger) : base(logger) { }

    public override void LogAction(string action)
    {
        _logger.Log($"[USER] {action}");
    }
}

class Program
{
    static void Main(string[] args)
    {

        var fileLogger = new FileLogger();
        var consoleLogger = new ConsoleLogger();


        var orderFileLogger = new OrderLogger(fileLogger);
        var userConsoleLogger = new UserLogger(consoleLogger);


        orderFileLogger.LogAction("Order #1 created");
        userConsoleLogger.LogAction("User Ivan logged in");


        var orderConsoleLogger = new OrderLogger(consoleLogger);
        orderConsoleLogger.LogAction("Order #1 paid");
    }
}