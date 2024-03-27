using DotSwashbuckle.AspNetCore.Annotations;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System.ComponentModel.DataAnnotations;

namespace UtopikSandcastle.AccessControlAPI.Models;

public class AccessControlDevice
{
  [BsonId]
  [BsonRepresentation(BsonType.ObjectId)]
  [SwaggerSchema(ReadOnly = true)]
  public string? Id { get; set; }

  [Required]
  public required string Name { get; set; }

  public required bool[] Inputs { get; set; }

  [SwaggerSchema(ReadOnly = true)]
  public required bool[] Outputs { get; set; }
}
