using System.Threading.Tasks;
using Katil.Business.Entities.Models.User;

namespace Katil.Business.Services.UserServices
{
	public interface IAuthenticateService
	{
		Task<AuthenticateResponse> Login(AuthenticateRequest authenticateRequest);
	}
}