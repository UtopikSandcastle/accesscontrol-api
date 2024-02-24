using DotSwashbuckle.AspNetCore.Annotations;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System.ComponentModel.DataAnnotations;

namespace UtopikSandcastle.AccessControlAPI.Models;

public class AccessControlSystem
{
  [BsonId]
  [BsonRepresentation(BsonType.ObjectId)]
  [SwaggerSchema(ReadOnly = true)]
  public string? Id { get; set; }
  [Required]
  public required string Name { get; set; }
  public required Dictionary<string, List<AccessControlSystemComponent>> Components { get; set; }
}
