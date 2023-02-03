using UpSchoolEcommerce.Service.Catalog.Dtos;
using UpSchoolEcommerce.Shared.Dtos;

namespace UpSchoolEcommerce.Service.Catalog.Services;
public interface IProductService
{
    Task<ResponseDto<ProductDto>> GetAllAsync();
    Task<ResponseDto<ProductDto>> GetByAsync(string id);
    Task<ResponseDto<ProductDto>>CreateAsync(ProductDto productDto);
    Task<ResponseDto<NoContent>> UpdateAsync(UpdateProductDto updateProductDto);
    Task<ResponseDto<NoContent>> DeleteAsync(string id);
}
