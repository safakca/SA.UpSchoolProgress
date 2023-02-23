using Microsoft.AspNetCore.Mvc;
using UpSchoolEcommerce.Service.Catalog.Dtos;
using UpSchoolEcommerce.Service.Catalog.Services;
using UpSchoolEcommerce.Shared.ContollerBase;

namespace UpSchoolEcommerce.Service.Catalog.Controllers;

[Route("api/[controller]")]
[ApiController]
public class ProductsController : CustomBaseController
{
    private readonly IProductService _productService;

    public ProductsController(IProductService productService) => _productService = productService;

    [HttpGet("getall")]
    public async Task<IActionResult> GetAll() => CreateActionResultInstance(await _productService.GetAllAsync());

    [HttpGet("get/{id}")]
    public async Task<IActionResult> Get(string id) => CreateActionResultInstance(await _productService.GetAsync(id));

    [HttpPost("create")]
    public async Task<IActionResult> Create(CreateProductDto dto) => CreateActionResultInstance(await _productService.CreateAsync(dto));

    [HttpPut("update")]
    public async Task<IActionResult> Update(UpdateProductDto dto) => CreateActionResultInstance(await _productService.UpdateAsync(dto));

    [HttpDelete("remove/{id}")]
    public async Task<IActionResult> Remove(string id) => CreateActionResultInstance(await _productService.RemoveAsync(id));
}
