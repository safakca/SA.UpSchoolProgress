using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace SA.MongoDbCRUD.Models;
public class MobileDeviceEntity
{
    [BsonId]
    [BsonRepresentation(BsonType.ObjectId)]
    public string _id { get; set; }
    public string Name { get; set; }
    public string Company { get; set; } 
    public string Color { get; set; } 
    public double Cost { get; set; } 
}
