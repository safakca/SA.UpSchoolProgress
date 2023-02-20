using Microsoft.AspNetCore.Mvc;
using UpSchoolEcommerce.Service.Catalog.Dtos;
using UpSchoolEcommerce.Service.Catalog.Services;
using UpSchoolEcommerce.Shared.ContollerBase;

namespace UpSchoolEcommerce.Service.Catalog.Controllers;

[Route("api/[controller]")]
[ApiController]
public class CategoriesController : CustomBaseController
{
    private readonly ICategoryService _categoryService;

    public CategoriesController(ICategoryService categoryService) => _categoryService = categoryService;

    [HttpGet("getall")]
    public async Task<IActionResult> GetAll() => CreateActionResultInstance(await _categoryService.GetAllAsync());

    [HttpGet("get/{id}")]
    public async Task<IActionResult> Get(string id) => CreateActionResultInstance(await _categoryService.GetAsync(id));

    [HttpPost("create")]
    public async Task<IActionResult> Create(CategoryDto dto) => CreateActionResultInstance(await _categoryService.CreateAsync(dto));
}
