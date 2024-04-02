using UtopikSandcastle.AccessControlAPI.Models;

namespace UtopikSandcastle.AccessControlAPI;

public static class SeedData
{
  public static readonly List<AccessControlDevice> AccessControlDevice = [
    new() {
      Name = "Front Drawbridge",
      Outputs = [false], // Opened
      Inputs = [false] // Open button
    },
    new() {
      Name = "Back Drawbridge",
      Outputs = [false], // Opened
      Inputs = [false] // Open button
    },
    new() {
      Name = "Front Door",
      Outputs = [false], // Opened
      Inputs = [false, false] // Open button, Lock button
    },
    new() {
      Name = "Back Door",
      Outputs = [false], // Opened
      Inputs = [false, true] // Open button, Lock button
    },
    new() {
      Name = "Front Porticullis",
      Outputs = [false], // Opened
      Inputs = [false] // Open button
    },
    new() {
      Name = "Back Porticullis",
      Outputs = [false], // Opened
      Inputs = [false] // Open button
    },
    new() {
      Name = "Postern Gate",
      Outputs = [false], // Opened
      Inputs = [true] // Locked
    },
    new() {
      Name="Garden Gate",
      Outputs=[true], // Opened
      Inputs=[]
    }
  ];
}
