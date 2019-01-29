using System.Threading.Tasks;
using Katil.Business.Entities.Models.User;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Katil.Business.Services.UserServices;

namespace Katil.WebApi.Controllers
{
    [Authorize]
    [ApiController]
    [Route("[controller]")]
    public class UsersController : ControllerBase
    {
        private readonly IAuthenticateService _authenticateService;
        private readonly IUserService _userService;

        public UsersController(IAuthenticateService authenticationService, IUserService userService)
        {
            _authenticateService = authenticationService;
            _userService = userService;
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            var users =  _userService.GetAll();
            return Ok(users);
        }
    }
}
