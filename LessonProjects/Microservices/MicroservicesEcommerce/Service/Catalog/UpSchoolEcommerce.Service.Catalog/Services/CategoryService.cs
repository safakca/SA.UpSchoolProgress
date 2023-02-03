using AutoMapper;
using MongoDB.Driver;
using UpSchoolEcommerce.Service.Catalog.Dtos;
using UpSchoolEcommerce.Service.Catalog.Models;
using UpSchoolEcommerce.Service.Catalog.Settings;
using UpSchoolEcommerce.Shared.Dtos;

namespace UpSchoolEcommerce.Service.Catalog.Services;
public class CategoryService : ICategoryService
{
    private readonly IMongoCollection<Category> _categoryCollection;
    private readonly IMapper _mapper;

    public CategoryService(IDatabaseSettings databaseSettings, IMapper mapper)
    {
        var client = new MongoClient(databaseSettings.ConnectionString);
        var database = client.GetDatabase(databaseSettings.DatabaseName);
        _categoryCollection = database.GetCollection<Category>(databaseSettings.CategoryCollectionName);
        _mapper = mapper;
    }

    public Task<ResponseDto<CategoryDto>> CreateAsync(CategoryDto categoryDto)
    {
        throw new NotImplementedException();
    }

    public Task<ResponseDto<List<CategoryDto>>> GetAllAsync()
    {
        throw new NotImplementedException();
    }

    public Task<ResponseDto<CategoryDto>> GetByIdAsync(string id)
    {
        throw new NotImplementedException();
    }
}
