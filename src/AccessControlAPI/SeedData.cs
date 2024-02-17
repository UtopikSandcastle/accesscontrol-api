using UtopikSandcastle.AccessControl.API.Models;

namespace UtopikSandcastle.AccessControl.API;

public static class SeedData
{
  public static List<AccessControlDevice> AccessControlDevice = [
    new() {
      Name = "Front Drawbridge",
      Type = AccessControlDeviceType.Drawbridge,
      Outputs = [true], // Closed
      Inputs = [false] // Open button
    },
    new() {
      Name = "Back Drawbridge",
      Type = AccessControlDeviceType.Drawbridge,
      Outputs = [false], // Closed
      Inputs = [false] // Open button
    },
    new() {
      Name = "Front Door",
      Type = AccessControlDeviceType.Door,
      Outputs = [true, false], // Closed, Locked
      Inputs = [false] // Open button
    },
    new() {
      Name = "Back Door",
      Type = AccessControlDeviceType.Door,
      Outputs = [true, true], // Closed, Locked
      Inputs = [false] // Open button
    },
    new() {
      Name = "Front Porticullis",
      Type = AccessControlDeviceType.Portcullis,
      Outputs = [true], // Closed
      Inputs = [false] // Open button
    },
    new() {
      Name = "Back Porticullis",
      Type = AccessControlDeviceType.Portcullis,
      Outputs = [true], // Closed
      Inputs = [false] // Open button
    },
    new() {
      Name = "Postern Gate",
      Type = AccessControlDeviceType.PosternGate,
      Outputs = [true, true] // Closed, Locked
    },
    new() {
      Name="Garden Gate",
      Type=AccessControlDeviceType.Gate,
      Outputs=[true] // Closed
    }
  ];
}
