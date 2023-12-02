using System;

public class ConfigurationManager
{
    private static ConfigurationManager instance;
    private string loggingMode;
    private string databaseConnection;

    private ConfigurationManager()
    {
        // Private constructor to prevent instantiation
    }

    public static ConfigurationManager Instance
    {
        get
        {
            if (instance == null)
            {
                instance = new ConfigurationManager();
            }
            return instance;
        }
    }

    public void SetLoggingMode(string mode)
    {
        loggingMode = mode;
        Console.WriteLine($"Logging mode set to: {mode}");
    }

    public void SetDatabaseConnection(string connection)
    {
        databaseConnection = connection;
        Console.WriteLine($"Database connection set to: {connection}");
    }

    public void DisplayConfiguration()
    {
        Console.WriteLine($"Logging Mode: {loggingMode}");
        Console.WriteLine($"Database Connection: {databaseConnection}");
    }
}

class Program
{
    static void Main()
    {
        ConfigurationManager configManager = ConfigurationManager.Instance;

        // Example usage
        configManager.SetLoggingMode("Verbose");
        configManager.SetDatabaseConnection("ConnectionString1");

        // Display configuration
        Console.WriteLine("Current Configuration:");
        configManager.DisplayConfiguration();
    }
}
