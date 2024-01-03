
namespace UtopikSandcastle.SecurityAPI.Models;

public class AccessControlDevice
{
  public String Id { get; } = Guid.NewGuid().ToString();
  public required string Name { get; set; }
}