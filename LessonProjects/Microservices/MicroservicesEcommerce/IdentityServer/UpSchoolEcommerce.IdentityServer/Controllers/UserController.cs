using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using UpSchoolEcommerce.IdentityServer.Dtos;
using UpSchoolEcommerce.IdentityServer.Models;

namespace UpSchoolEcommerce.IdentityServer.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly UserManager<ApplicationUser> _userManager;

        public UserController(UserManager<ApplicationUser> userManager) => _userManager = userManager;

        [HttpPost]
        public async Task<IActionResult> SignUp(SignUpDto dto)
        {
            var user = new ApplicationUser()
            {
                UserName = dto.UserName,
                Email = dto.Email,
                City= dto.City
            };
            var result = await _userManager.CreateAsync(user, dto.Password);
            if (!result.Succeeded)
            {
                return BadRequest();
            }
            return NoContent();
        }
    }
}
