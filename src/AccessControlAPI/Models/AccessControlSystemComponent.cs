namespace UtopikSandcastle.AccessControlAPI.Models;

public enum AccessControlSystemComponentType
{
  Door,
  Drawbridge,
  Gate,
  Portcullis,
  PosternGate,
}

public class AccessControlSystemComponent(AccessControlDevice accessControlDevice)
{
  private readonly AccessControlDevice _accessControlDevice = accessControlDevice;

  public string? AccessControlDeviceId => _accessControlDevice.Id;

  public string Name => _accessControlDevice.Name;

  public AccessControlSystemComponentType Type { get; set; }

  public bool IsOpenable
  {
    get
    {
      switch (Type)
      {
        case AccessControlSystemComponentType.Door:
          return true;
        case AccessControlSystemComponentType.Drawbridge:
          return true;
        case AccessControlSystemComponentType.Gate:
          return false;
        case AccessControlSystemComponentType.Portcullis:
          return true;
        case AccessControlSystemComponentType.PosternGate:
          return true;
      }
      return false;
    }
  }

  public bool? Opened
  {
    get
    {
      switch (Type)
      {
        case AccessControlSystemComponentType.Door:
          return _accessControlDevice.Outputs[0];
        case AccessControlSystemComponentType.Drawbridge:
          return _accessControlDevice.Outputs[0];
        case AccessControlSystemComponentType.Gate:
          return _accessControlDevice.Outputs[0];
        case AccessControlSystemComponentType.Portcullis:
          return _accessControlDevice.Outputs[0];
        case AccessControlSystemComponentType.PosternGate:
          return _accessControlDevice.Outputs[0];
      }
      return null;
    }
  }

  public bool IsLockable
  {
    get
    {
      switch (Type)
      {
        case AccessControlSystemComponentType.Door:
          return true;
        case AccessControlSystemComponentType.Drawbridge:
          return false;
        case AccessControlSystemComponentType.Gate:
          return false;
        case AccessControlSystemComponentType.Portcullis:
          return false;
        case AccessControlSystemComponentType.PosternGate:
          return true;
      }
      return false;
    }
  }
  public bool? Locked
  {
    get
    {
      switch (Type)
      {
        case AccessControlSystemComponentType.Door:
          return _accessControlDevice.Inputs[1];
        case AccessControlSystemComponentType.Drawbridge:
          return null;
        case AccessControlSystemComponentType.Gate:
          return null;
        case AccessControlSystemComponentType.Portcullis:
          return null;
        case AccessControlSystemComponentType.PosternGate:
          return _accessControlDevice.Inputs[0];
      }
      return null;
    }
  }
}
