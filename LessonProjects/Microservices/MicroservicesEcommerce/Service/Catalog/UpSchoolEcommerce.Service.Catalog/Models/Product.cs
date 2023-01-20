using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace UpSchoolEcommerce.Service.Catalog.Models;
public class Product
{
    [BsonId]
    [BsonRepresentation(BsonType.ObjectId)]
    public string Id { get; set; }
    public string Name { get; set; }
    public string Description { get; set; }

    [BsonRepresentation(BsonType.Decimal128)]
    public decimal Price { get; set; }
    public int Stock { get; set; }
    public string Image { get; set; }

    [BsonRepresentation(BsonType.ObjectId)]
    public string CategoryId { get; set; }

    [BsonIgnore]
    public Category Category { get; set; }
}
