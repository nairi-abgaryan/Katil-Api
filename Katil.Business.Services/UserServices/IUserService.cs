using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Katil.Business.Entities.Models.User;
using Katil.Data.Model;

namespace Katil.Business.Services.UserServices
{
	public interface IUserService
	{
		Task<UserRegistrationResponse> CreateUser(UserRegistrationsRequest request);

		Task<ICollection<User>> GetAll();
	}
}