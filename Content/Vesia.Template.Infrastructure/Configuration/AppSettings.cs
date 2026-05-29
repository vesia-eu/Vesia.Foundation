namespace Vesia.Template.Infrastructure.Configuration;

public class AppSettings
{
    public ConnectionStrings ConnectionStrings { get; init; } = new ();
}

public class ConnectionStrings
{
    public string DatabaseConnectionString { get; set; } = string.Empty;
}

