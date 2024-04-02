using Microsoft.AspNetCore.Mvc;
using UtopikSandcastle.AccessControlAPI.Models;
using UtopikSandcastle.AccessControlAPI.Services;

namespace UtopikSandcastle.AccessControlAPI.Controllers;

[ApiController]
[Route("v1/[controller]")]
public class AccessControlDeviceController(AccessControlDevicesService accessControlDevicesService) : ControllerBase
{
  private readonly AccessControlDevicesService _accessControlDevicesService = accessControlDevicesService;

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

    [HttpPost("{id:length(24)}/Open")]
  public async Task<IActionResult> PostOpen(string id)
  {
    await _accessControlDevicesService.OpenAsync(id);

    return Ok();
  }

  [HttpPost("{id:length(24)}/Lock")]
  public async Task<IActionResult> PostLock(string id)
  {
    bool result = await _accessControlDevicesService.LockAsync(id);

    if (!result)
    {
      return Problem("Cannot be locked.");
    }
    return Ok();
  }
}