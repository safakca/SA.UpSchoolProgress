using MediatR;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using UpSchool_CQRS_DesignPatterns.CQRS.Commands.UniversityCommands;
using UpSchool_CQRS_DesignPatterns.CQRS.Queries.UniversityQueries;

namespace UpSchool_CQRS_DesignPatterns.Controllers;

public class UniversityController : Controller
{
    private readonly IMediator _mediator;
    public UniversityController(IMediator mediator)
    {
        _mediator = mediator;
    }

    public IActionResult Index()
    {
        return View();
    }
    public async Task<IActionResult> GetAllUniversities()
    {
        var values = await _mediator.Send(new GetAllUniversityQuery());
        return View(values);

    }

    [HttpGet]
    public async Task<IActionResult> UpdateUniversity(int id)
    {
        var values = await _mediator.Send(new GetUniversityByIDQuery(id));
        return View(values);
    }
 
    [HttpPost]
    public async Task<IActionResult> UpdateUniversity(UpdateUniversityCommand command)
    {
        var values = await _mediator.Send(command);
        return RedirectToAction("GetAllUniversities");
    }
   
    [HttpGet]
    public IActionResult AddUniversity()
    {
        return View();
    }

    [HttpPost]
    public async Task<IActionResult> AddUniversity(CreateUniversityCommand command)
    {
        await _mediator.Send(command);
        return RedirectToAction("GetAllUniversities");

    }
 
    public async Task<IActionResult> DeleteUniversity(int id)
    {
        await _mediator.Send(new RemoveUniversityCommand(id));
        return RedirectToAction("GetAllUniversities");

    }

}
