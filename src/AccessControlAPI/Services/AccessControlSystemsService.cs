using Microsoft.Extensions.Options;
using MongoDB.Driver;
using UtopikSandcastle.AccessControl.API.Models;

namespace UtopikSandcastle.AccessControl.API;

public class AccessControlSystemsService
{
  private readonly IMongoCollection<AccessControlSystem> _accesControlSystemsCollection;

  public AccessControlSystemsService(IOptions<SecurityDatabaseSettings> securityDatabaseSettings)
  {
    var mongoClient = new MongoClient(
      securityDatabaseSettings.Value.ConnectionString);

    var mongoDatabase = mongoClient.GetDatabase(
      securityDatabaseSettings.Value.DatabaseName);

    _accesControlSystemsCollection = mongoDatabase.GetCollection<AccessControlSystem>(
      securityDatabaseSettings.Value.AccessControlSystemsCollectionName);
  }

  public async Task<List<AccessControlSystem>> GetAsync() =>
    await _accesControlSystemsCollection.Find(_ => true).ToListAsync();

  public async Task<AccessControlSystem?> GetAsync(string id) =>
    await _accesControlSystemsCollection.Find(x => x.Id == id).FirstOrDefaultAsync();

  public async Task CreateAsync(AccessControlSystem accessControlSystem) =>
    await _accesControlSystemsCollection.InsertOneAsync(accessControlSystem);

  public async Task UpdateAsync(string id, AccessControlSystem accessControlSystem) =>
    await _accesControlSystemsCollection.ReplaceOneAsync(x => x.Id == id, accessControlSystem);

  public async Task RemoveAsync(string id) =>
    await _accesControlSystemsCollection.DeleteOneAsync(x => x.Id == id);
}
