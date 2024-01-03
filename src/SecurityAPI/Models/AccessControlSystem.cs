
namespace UtopikSandcastle.SecurityAPI.Models;

public class AccessControlSystem
{
  public String Id { get; } = Guid.NewGuid().ToString();
  public required string Name { get; set; }
  public List<AccessControlDevice> AccessControlDevices { get; set; } = [];
}