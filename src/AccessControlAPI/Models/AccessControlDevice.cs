using System.ComponentModel.DataAnnotations;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using Swashbuckle.AspNetCore.Annotations;

namespace UtopikSandcastle.AccessControl.API.Models;

public enum AccessControlDeviceType
{
  Door,
  Drawbridge,
  Gate,
  Portcullis,
  PosternGate,
}

public class AccessControlDevice
{
  [BsonId]
  [BsonRepresentation(BsonType.ObjectId)]
  [SwaggerSchema(ReadOnly = true)]
  public string? Id { get; set; }

  [Required]
  public required string Name { get; set; }

  public AccessControlDeviceType Type { get; set; }

  public List<bool>? Outputs { get; set; }

  public List<bool>? Inputs { get; set; }
}
