﻿using Microsoft.AspNetCore.Mvc;
using UtopikSandcastle.AccessControlAPI.Models;
using UtopikSandcastle.AccessControlAPI.Services;

namespace UtopikSandcastle.AccessControlAPI.Controllers;

[ApiController]
[Route("v1/[controller]")]
public class AccessControlSystemController(AccessControlSystemsService accessControlSystemsService) : ControllerBase
{
  private readonly AccessControlSystemsService _accessControlSystemsService = accessControlSystemsService;

  [HttpGet]
  public async Task<List<AccessControlSystem>> Get() =>
  await _accessControlSystemsService.GetAsync();

  [HttpGet("{id:length(24)}")]
  public async Task<ActionResult<AccessControlSystem>> Get(string id)
  {
    var accessControlSystemFound = await _accessControlSystemsService.GetAsync(id);

    if (accessControlSystemFound is null)
    {
      return NotFound();
    }

    return accessControlSystemFound;
  }

  [HttpPost]
  public async Task<IActionResult> Post(AccessControlSystem accessControlSystem)
  {
    await _accessControlSystemsService.CreateAsync(accessControlSystem);

    return CreatedAtAction(nameof(Get), new { id = accessControlSystem.Id }, accessControlSystem);
  }

  [HttpPut("{id:length(24)}")]
  public async Task<IActionResult> Update(string id, AccessControlSystem accessControlSystem)
  {
    var accessControlSystemFound = await _accessControlSystemsService.GetAsync(id);

    if (accessControlSystemFound is null)
    {
      return NotFound();
    }

    accessControlSystem.Id = accessControlSystemFound.Id;

    await _accessControlSystemsService.UpdateAsync(id, accessControlSystem);

    return NoContent();
  }

  [HttpDelete("{id:length(24)}")]
  public async Task<IActionResult> Delete(string id)
  {
    var accessControlSystemFound = await _accessControlSystemsService.GetAsync(id);

    if (accessControlSystemFound is null)
    {
      return NotFound();
    }

    await _accessControlSystemsService.RemoveAsync(id);

    return NoContent();
  }
}
