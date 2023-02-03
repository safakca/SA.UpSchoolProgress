using MediatR;
using Microsoft.AspNetCore.Mvc;
using Onion.ApiConsume.Application.Features.CQRS.Queries;

namespace Onion.ApiConsume.API.Controllers;

[Route("api/[controller]")]
[ApiController]
public class CategoriesController : ControllerBase
{
    private readonly IMediator _mediator;
    public CategoriesController(IMediator mediator) => _mediator = mediator;

    [HttpGet("[action]")]
    public async Task<IActionResult> GetAll() => Ok(await _mediator.Send(new GetCategoriesQueryRequest()));
}

