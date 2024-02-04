using UtopikSandcastle.AccessControl.API.Models;

namespace UtopikSandcastle.AccessControl.API;

public static class SeedData
{
  public static List<AccessControlDevice> AccessControlDevice = new() {
    new() {
      Name = "Front Drawbridge",
      Type = AccessControlDeviceType.Drawbridge,
      Outputs = new List<bool> {true, true},
      Inputs = new List<bool> {false}
    },
    new() {
      Name = "Back Drawbridge",
      Type = AccessControlDeviceType.Drawbridge,
      Outputs = new List<bool> {true, true},
      Inputs = new List<bool> {false}
    },
    new() {
      Name = "Front Gate",
      Type = AccessControlDeviceType.Gate,
      Outputs = new List<bool> {true},
      Inputs = new List<bool> {false}
    },
    new() {
      Name = "Back Gate",
      Type = AccessControlDeviceType.Gate,
      Outputs = new List<bool> {true},
      Inputs = new List<bool> {false}
    },
    new() {
      Name = "Front Porticullis",
      Type = AccessControlDeviceType.Portcullis,
      Outputs = new List<bool> {true},
      Inputs = new List<bool> {false}
    },
    new() {
      Name = "Back Porticullis",
      Type = AccessControlDeviceType.Portcullis,
      Outputs = new List<bool> {true},
      Inputs = new List<bool> {false}
    },
    new() {
      Name = "Postern Gate",
      Type = AccessControlDeviceType.PosternGate,
      Outputs = new List<bool> {true}
    },
  };
}
