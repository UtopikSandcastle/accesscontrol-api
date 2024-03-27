namespace UtopikSandcastle.AccessControlAPI.Models;

public class AccessControlDatabaseSettings
{
    public string ConnectionString { get; set; } = null!;

    public string DatabaseName { get; set; } = null!;

    public string AccessControlDevicesCollectionName { get; set; } = null!;
    
    public string AccessControlDeviceIOsCollectionName { get; set; } = null!;

    public string AccessControlSystemsCollectionName { get; set; } = null!;
}