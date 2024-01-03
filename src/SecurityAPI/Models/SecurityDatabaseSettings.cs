namespace UtopikSandcastle.SecurityAPI.Models;

public class SecurityDatabaseSettings
{
    public string ConnectionString { get; set; } = null!;

    public string DatabaseName { get; set; } = null!;

    public string AccessControlDevicesCollectionName { get; set; } = null!;
}