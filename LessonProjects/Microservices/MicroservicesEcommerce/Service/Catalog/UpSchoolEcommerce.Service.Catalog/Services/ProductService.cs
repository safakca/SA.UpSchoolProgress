using AutoMapper;
using MongoDB.Driver;
using UpSchoolEcommerce.Service.Catalog.Dtos;
using UpSchoolEcommerce.Service.Catalog.Models;
using UpSchoolEcommerce.Service.Catalog.Settings;
using UpSchoolEcommerce.Shared.Dtos;

namespace UpSchoolEcommerce.Service.Catalog.Services;
public class ProductService : IProductService
{
    private readonly IMongoCollection<Product> _productCollection;
    private readonly IMapper _mapper;
    public ProductService(IMapper mapper, IDatabaseSettings databaseSettings)
    {
        _mapper = mapper;
        var client= new MongoClient(databaseSettings.ConnectionString);
        var database = client.GetDatabase(databaseSettings.DatabaseName);
        _productCollection = database.GetCollection<Product>(databaseSettings.ProductCollectionName);
    }
    public Task<ResponseDto<ProductDto>> CreateAsync(ProductDto productDto)
    {
        throw new NotImplementedException();
    }

    public Task<ResponseDto<NoContent>> DeleteAsync(string id)
    {
        throw new NotImplementedException();
    }

    public Task<ResponseDto<ProductDto>> GetAllAsync()
    {
        throw new NotImplementedException();
    }

    public Task<ResponseDto<ProductDto>> GetByAsync(string id)
    {
        throw new NotImplementedException();
    }

    public Task<ResponseDto<NoContent>> UpdateAsync(UpdateProductDto updateProductDto)
    {
        throw new NotImplementedException();
    }
}
