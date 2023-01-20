using Microsoft.Extensions.Options;
using MongoDB.Driver;
using SA.MongoDbCRUD.Interfaces;
using SA.MongoDbCRUD.Models; 

namespace SA.MongoDbCRUD.Data;
public class MobileStoreService : IMobileStoreService
{
    public readonly IMongoDatabase _db;
    public MobileStoreService(IOptions<Settings> options)
    {
        var client = new MongoClient(options.Value.ConnectionString);
        _db = client.GetDatabase(options.Value.Database);
    }
    public IMongoCollection<MobileDeviceEntity> mobileDeviceCollection => _db.GetCollection<MobileDeviceEntity>("mobiledevice");

    public IEnumerable<MobileDeviceEntity> GetAll()
    {
        return mobileDeviceCollection.Find(a => true).ToList();
    }

    public MobileDeviceEntity GetDetails(string Name)
    {
        var mobileDeviceDetails = mobileDeviceCollection.Find(x => x.Name == Name).FirstOrDefault();
        return mobileDeviceDetails;
    }

    public void Create(MobileDeviceEntity entity)
    {
        mobileDeviceCollection.InsertOne(entity);
    } 
     
    public void Update(string _id, MobileDeviceEntity entity)
    {
        var filter = Builders<MobileDeviceEntity>.Filter.Eq(x => x._id, _id);
        var update = Builders<MobileDeviceEntity>.Update
            .Set("Name", entity.Name)
            .Set("Company", entity.Company)
            .Set("Color", entity.Color)
            .Set("Cost", entity.Cost);
        mobileDeviceCollection.UpdateOne(filter, update);
    }

    public void Delete(string Name)
    {
        var filter = Builders<MobileDeviceEntity>.Filter.Eq(x => x.Name, Name);
        mobileDeviceCollection.DeleteOne(filter);
    }
}
