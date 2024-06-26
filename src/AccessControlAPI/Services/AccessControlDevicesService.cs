﻿using Microsoft.Extensions.Options;
using MongoDB.Driver;
using UtopikSandcastle.AccessControlAPI.Models;

namespace UtopikSandcastle.AccessControlAPI.Services;

public class AccessControlDevicesService
{
  private readonly IMongoCollection<AccessControlDevice> _accesControlDevicesCollection;

  public AccessControlDevicesService(IOptions<AccessControlDatabaseSettings> accessControlDatabaseSettings)
  {
    var mongoClient = new MongoClient(
      accessControlDatabaseSettings.Value.ConnectionString);

    var mongoDatabase = mongoClient.GetDatabase(
      accessControlDatabaseSettings.Value.DatabaseName);

    _accesControlDevicesCollection = mongoDatabase.GetCollection<AccessControlDevice>(
      accessControlDatabaseSettings.Value.AccessControlDevicesCollectionName);
  }

  public async Task<List<AccessControlDevice>> GetAsync() =>
    await _accesControlDevicesCollection.Find(_ => true).ToListAsync();

  public async Task<AccessControlDevice?> GetAsync(string id) =>
    await _accesControlDevicesCollection.Find(x => x.Id == id).FirstOrDefaultAsync();

  public async Task CreateAsync(AccessControlDevice accessControlDevice) =>
    await _accesControlDevicesCollection.InsertOneAsync(accessControlDevice);

  public async Task UpdateAsync(string id, AccessControlDevice accessControlDevice) =>
    await _accesControlDevicesCollection.ReplaceOneAsync(x => x.Id == id, accessControlDevice);

  public async Task RemoveAsync(string id) =>
    await _accesControlDevicesCollection.DeleteOneAsync(x => x.Id == id);

  public async Task OpenAsync(string id)
  {
    AccessControlDevice accessControlDevice = await _accesControlDevicesCollection.Find(x => x.Id == id).FirstOrDefaultAsync();
    accessControlDevice.Outputs[0] = true;
    await _accesControlDevicesCollection.ReplaceOneAsync(x => x.Id == id, accessControlDevice);
  }

  public async Task<bool> LockAsync(string id)
  {
    AccessControlDevice accessControlDevice = await _accesControlDevicesCollection.Find(x => x.Id == id).FirstOrDefaultAsync();

    if (accessControlDevice.Inputs.Length > 1)
    {
      accessControlDevice.Inputs[1] = true;
      await _accesControlDevicesCollection.ReplaceOneAsync(x => x.Id == id, accessControlDevice);
      
      return true;
    }

    return false;
  }

  public async Task SeedDataAsync()
  {
    var existingDataCount = await _accesControlDevicesCollection.CountDocumentsAsync(FilterDefinition<AccessControlDevice>.Empty);
    if (existingDataCount == 0)
    {
      await _accesControlDevicesCollection.InsertManyAsync(SeedData.AccessControlDevice);
    }
  }
}
