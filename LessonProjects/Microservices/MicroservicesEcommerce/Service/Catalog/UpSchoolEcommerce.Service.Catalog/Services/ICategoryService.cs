using UpSchoolEcommerce.Service.Catalog.Dtos;
using UpSchoolEcommerce.Shared.Dtos;

namespace UpSchoolEcommerce.Service.Catalog.Services;
public interface ICategoryService
{
    Task<ResponseDto<List<CategoryDto>>> GetAllAsync();
    Task<ResponseDto<CategoryDto>> CreateAsync(CategoryDto categoryDto);
    Task<ResponseDto<CategoryDto>> GetAsync(string id);
}
