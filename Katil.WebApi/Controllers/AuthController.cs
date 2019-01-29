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
	public class AuthController : ControllerBase
	{
		private readonly IAuthenticateService _authenticateService;
		private readonly IUserService _userService;

		public AuthController(IAuthenticateService authenticationService, IUserService userService)
		{
			_authenticateService = authenticationService;
			_userService = userService;
		}

		[AllowAnonymous]
		[HttpPost("login")]
		public async Task<IActionResult> Authenticate([FromBody]AuthenticateRequest authParam)
		{
			var authToken = await _authenticateService.Login(authParam);

			if (authToken == null)
				return BadRequest(new { message = "Username or password is incorrect" });

			return Ok(authToken);
		}
	}
}
