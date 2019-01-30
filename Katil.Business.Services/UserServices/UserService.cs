using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using Katil.Business.Entities.Models.User;
using Katil.Common.Utilities;
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

        public async Task<UserRegistrationResponse> CreateUser(UserRegistrationsRequest request)
        {
            var newUser = Mapper.Map<UserRegistrationsRequest, User>(request);
            newUser.Password = HashHelper.GetHash(request.Password);
            var result = await _unitOfWork.UserRepository.InsertAsync(newUser);
            await _unitOfWork.Complete();
            return Mapper.Map<User, UserRegistrationResponse>(result);
        }
    }
}