using Microsoft.AspNetCore.Mvc;
using UpSchoolEcommerce.Shared.Dtos;

namespace UpSchoolEcommerce.Shared.ContollerBase;
public class CustomBaseController :ControllerBase
{
    public IActionResult CreateActionResultInstance<T>(ResponseDto<T> response)
    {
        return new ObjectResult(response)
        {
            StatusCode=response.StatusCode
        };
    }
}
