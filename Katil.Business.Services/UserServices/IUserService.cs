using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Katil.Data.Model;

namespace Katil.Business.Services.UserServices
{
	public interface IUserService
	{
		Task<ICollection<User>> GetAll();
	}
}