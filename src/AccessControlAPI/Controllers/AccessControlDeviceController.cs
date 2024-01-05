using System.Security.Cryptography.X509Certificates;
using Microsoft.AspNetCore.Mvc;
using UtopikSandcastle.AccessControl.API.Models;
using UtopikSandcastle.AccessControl.API.Services;

namespace UtopikSandcastle.AccessControl.API.Controllers;

[ApiController]
[Route("api/v1/[controller]")]
public class AccessControlDeviceController : ControllerBase
{
  private readonly AccessControlDevicesService _accessControlDevicesService;

  public AccessControlDeviceController(AccessControlDevicesService accessControlDevicesService)
  {
    _accessControlDevicesService = accessControlDevicesService;
  }

  [HttpGet]
  public async Task<List<AccessControlDevice>> Get() =>
    await _accessControlDevicesService.GetAsync();

  [HttpGet("{id:length(24)}")]
  public async Task<ActionResult<AccessControlDevice>> Get(string id)
  {
    var accessControlDeviceFound = await _accessControlDevicesService.GetAsync(id);

    if (accessControlDeviceFound is null)
    {
      return NotFound();
    }

    return accessControlDeviceFound;
  }

  [HttpPost]
  public async Task<IActionResult> Post(AccessControlDevice accessControlDevice)
  {
    await _accessControlDevicesService.CreateAsync(accessControlDevice);

    return CreatedAtAction(nameof(Get), new { id = accessControlDevice.Id }, accessControlDevice);
  }

  [HttpPut("{id:length(24)}")]
  public async Task<IActionResult> Update(string id, AccessControlDevice accessControlDevice)
  {
    var accessControlDeviceFound = await _accessControlDevicesService.GetAsync(id);

    if (accessControlDeviceFound is null)
    {
      return NotFound();
    }

    accessControlDevice.Id = accessControlDeviceFound.Id;

    await _accessControlDevicesService.UpdateAsync(id, accessControlDevice);

    return NoContent();
  }

  [HttpDelete("{id:length(24)}")]
  public async Task<IActionResult> Delete(string id)
  {
    var accessControlDeviceFound = await _accessControlDevicesService.GetAsync(id);

    if (accessControlDeviceFound is null)
    {
      return NotFound();
    }

    await _accessControlDevicesService.RemoveAsync(id);

    return NoContent();
  }
}