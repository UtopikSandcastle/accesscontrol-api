using System.Security.Cryptography.X509Certificates;
using Microsoft.AspNetCore.Mvc;
using UtopikSandcastle.SecurityAPI.Models;
using UtopikSandcastle.SecurityAPI.Services;

namespace UtopikSandcastle.SecurityAPI.Controllers;

[ApiController]
[Route("[controller]")]
public class AccessControlDeviceController(AccessControlService accessControlService) : ControllerBase
{
  private readonly AccessControlService _accessControlService = accessControlService;

  [HttpGet]
  public async Task<List<AccessControlDevice>> Get() => 
    await _accessControlService.GetAsync();
}