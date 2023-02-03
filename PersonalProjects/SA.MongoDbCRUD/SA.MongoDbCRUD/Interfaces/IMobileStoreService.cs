using MongoDB.Driver;
using SA.MongoDbCRUD.Models;

namespace SA.MongoDbCRUD.Interfaces;
public interface IMobileStoreService
{
    IMongoCollection<MobileDeviceEntity> mobileDeviceCollection { get; }
    IEnumerable<MobileDeviceEntity> GetAll();

    MobileDeviceEntity GetDetails(string Name);
    void Create(MobileDeviceEntity entity);
    void Update(string _id, MobileDeviceEntity entity);
    void Delete(string Name);
}
