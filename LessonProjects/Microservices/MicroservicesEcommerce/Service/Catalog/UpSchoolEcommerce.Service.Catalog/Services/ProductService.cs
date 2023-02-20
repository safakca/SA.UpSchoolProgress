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
        var client = new MongoClient(databaseSettings.ConnectionString);
        var database = client.GetDatabase(databaseSettings.DatabaseName);
        _productCollection = database.GetCollection<Product>(databaseSettings.ProductCollectionName);
    }
    public async Task<ResponseDto<ProductDto>> CreateAsync(CreateProductDto createProductDto)
    {
        var product = _mapper.Map<Product>(createProductDto);
        await _productCollection.InsertOneAsync(product);
        return ResponseDto<ProductDto>.Success(_mapper.Map<ProductDto>(product), 200);
    }

    public async Task<ResponseDto<NoContent>> RemoveAsync(string id)
    {
        var result = await _productCollection.DeleteOneAsync(x => x.Id == id);
        if (result.DeletedCount > 0)
        {
            return ResponseDto<NoContent>.Success(204);
        }
        else
        {
            return ResponseDto<NoContent>.Fail("Silinecek ürün bulunamadı", 404);
        }
    }

    public async Task<ResponseDto<List<ProductDto>>> GetAllAsync()
    {
        var products = await _productCollection.Find(products => true).ToListAsync();
        return ResponseDto<List<ProductDto>>.Success(_mapper.Map<List<ProductDto>>(products), 200);
    }

    public async Task<ResponseDto<ProductDto>> GetAsync(string id)
    {
        var product = await _productCollection.Find<Product>(x => x.Id == id).FirstOrDefaultAsync();
        if (product == null)
        {
            return ResponseDto<ProductDto>.Fail("Ürün Bulunamadı", 400);
        }
        else
        {
            return ResponseDto<ProductDto>.Success(_mapper.Map<ProductDto>(product), 200);
        }
    }

    public async Task<ResponseDto<NoContent>> UpdateAsync(UpdateProductDto updateProductDto)
    {
        var updated = _mapper.Map<Product>(updateProductDto);
        var result = await _productCollection.FindOneAndReplaceAsync(x => x.Id == updateProductDto.Id, updated);
        if (result == null)
        {
            return ResponseDto<NoContent>.Fail("Güncellenecek id değeri bulunamadı", 404);
        }
        else
        {
            return ResponseDto<NoContent>.Success(204);
        }
    }
}
