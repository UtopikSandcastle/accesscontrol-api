using System.ComponentModel.DataAnnotations;
using UtopikSandcastle.AccessControlAPI.Services;

namespace UtopikSandcastle.AccessControlAPI.Models;

public enum AccessControlSystemComponentType
{
  Door,
  Drawbridge,
  Gate,
  Portcullis,
  PosternGate,
}

public class AccessControlSystemComponent(AccessControlDevicesService accessControlDevicesService)
{
  private readonly AccessControlDevicesService _accessControlDevicesService = accessControlDevicesService;

  private AccessControlDevice? _accessControlDevice;

  public string? AccessControlDeviceId
  {
    get { return _accessControlDevice?.Id; }
    set
    {
      if (value != null)
      {
        _ = SetAccessControlDeviceAsync(value);
      }
    }
  }

  private async Task SetAccessControlDeviceAsync(string deviceId)
  {
    _accessControlDevice = await _accessControlDevicesService.GetAsync(deviceId);
  }

  public string? Name => _accessControlDevice?.Name;

  [Required]
  public AccessControlSystemComponentType Type { get; set; }

  public bool IsOpenable
  {
    get
    {
      return Type switch
      {
        AccessControlSystemComponentType.Door => true,
        AccessControlSystemComponentType.Drawbridge => true,
        AccessControlSystemComponentType.Gate => false,
        AccessControlSystemComponentType.Portcullis => true,
        AccessControlSystemComponentType.PosternGate => true,
        _ => false,
      };
    }
  }

  public bool? Opened
  {
    get
    {
      return Type switch
      {
        AccessControlSystemComponentType.Door => _accessControlDevice?.Outputs[0],
        AccessControlSystemComponentType.Drawbridge => _accessControlDevice?.Outputs[0],
        AccessControlSystemComponentType.Gate => _accessControlDevice?.Outputs[0],
        AccessControlSystemComponentType.Portcullis => _accessControlDevice?.Outputs[0],
        AccessControlSystemComponentType.PosternGate => _accessControlDevice?.Outputs[0],
        _ => null,
      };
    }
  }

  public bool IsLockable
  {
    get
    {
      return Type switch
      {
        AccessControlSystemComponentType.Door => true,
        AccessControlSystemComponentType.Drawbridge => false,
        AccessControlSystemComponentType.Gate => false,
        AccessControlSystemComponentType.Portcullis => false,
        AccessControlSystemComponentType.PosternGate => true,
        _ => false,
      };
    }
  }
  public bool? Locked
  {
    get
    {
      return Type switch
      {
        AccessControlSystemComponentType.Door => _accessControlDevice?.Inputs[1],
        AccessControlSystemComponentType.Drawbridge => null,
        AccessControlSystemComponentType.Gate => null,
        AccessControlSystemComponentType.Portcullis => null,
        AccessControlSystemComponentType.PosternGate => _accessControlDevice?.Inputs[0],
        _ => null,
      };
    }
  }
}
