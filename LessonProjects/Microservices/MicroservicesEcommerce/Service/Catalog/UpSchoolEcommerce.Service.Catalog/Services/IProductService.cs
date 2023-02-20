using UpSchoolEcommerce.Service.Catalog.Dtos;
using UpSchoolEcommerce.Shared.Dtos;

namespace UpSchoolEcommerce.Service.Catalog.Services;
public interface IProductService
{
    Task<ResponseDto<List<ProductDto>>> GetAllAsync();
    Task<ResponseDto<ProductDto>> GetAsync(string id);
    Task<ResponseDto<ProductDto>> CreateAsync(CreateProductDto productDto);
    Task<ResponseDto<NoContent>> UpdateAsync(UpdateProductDto updateProductDto);
    Task<ResponseDto<NoContent>> RemoveAsync(string id);
}
