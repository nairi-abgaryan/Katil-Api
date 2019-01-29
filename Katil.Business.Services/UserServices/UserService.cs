using System.Collections.Generic;
using System.Threading.Tasks;
using Katil.Data.Model;
using Katil.Data.Repositories.UnitOfWork;

namespace Katil.Business.Services.UserServices
{
    public class UserService : IUserService
    {
        private readonly IUnitOfWork _unitOfWork;

        public UserService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<ICollection<User>> GetAll()
        {
            var users = await _unitOfWork.UserRepository.GetAllAsync();

            return users;
        }
    }
}