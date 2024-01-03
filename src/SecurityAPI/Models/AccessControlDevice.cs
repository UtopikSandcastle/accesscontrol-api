using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using Swashbuckle.AspNetCore.Annotations;

namespace UtopikSandcastle.SecurityAPI.Models;

public class AccessControlDevice
{
  [BsonId]
  [BsonRepresentation(BsonType.ObjectId)]
  [SwaggerSchema(ReadOnly = true)]
  public string? Id { get; set; }

  public required string Name { get; set; }
  
}