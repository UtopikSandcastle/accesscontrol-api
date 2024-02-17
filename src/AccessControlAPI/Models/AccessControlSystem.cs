
using System.ComponentModel.DataAnnotations;
using DotSwashbuckle.AspNetCore.Annotations;
using Microsoft.OpenApi.Any;
using Microsoft.OpenApi.Models;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace UtopikSandcastle.AccessControl.API.Models;

public class AccessControlSystem
{
  [BsonId]
  [BsonRepresentation(BsonType.ObjectId)]
  [SwaggerSchema(ReadOnly = true)]
  public string? Id { get; set; }
  [Required]
  public required string Name { get; set; }
  public List<string> AccessControlDeviceIds { get; set; } = new List<string>() { };
}
