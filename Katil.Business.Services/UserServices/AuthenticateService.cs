using System.Threading.Tasks;
using Katil.Business.Entities.Models.User;
using Katil.Data.Model;
using Katil.Data.Repositories.UnitOfWork;
using Katil.Business.Services.TokenServices;
using Katil.Common.Utilities;

namespace Katil.Business.Services.UserServices
{
    public class AuthenticateService : IAuthenticateService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IJwtTokenService _jwtTokenService;

        public AuthenticateService(IUnitOfWork unitOfWork, IJwtTokenService jwtTokenService)
        {
            _unitOfWork = unitOfWork;
            _jwtTokenService = jwtTokenService;
        }

        public async Task<AuthenticateResponse> Login(AuthenticateRequest authenticateRequest)
        {
            var user = await _unitOfWork.UserRepository.GetUser(authenticateRequest.Email, HashHelper.GetHash(authenticateRequest.Password));

            if (user == null) return null;
            var token =  _jwtTokenService.GetJwtToken(user);
            var authToken = new AuthenticateResponse(){AuthToken = token};

            return authToken;
        }

        public Task<User> Login()
        {
            throw new System.NotImplementedException();
        }
    }
}
