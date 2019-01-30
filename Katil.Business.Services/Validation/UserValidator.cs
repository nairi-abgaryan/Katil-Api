using FluentValidation;
using Katil.Business.Entities.Models.User;
using Katil.Data.Repositories.UnitOfWork;

namespace Katil.Business.Services.Validation
{
	public class UserValidator : AbstractValidator<UserRegistrationsRequest>
	{
		public IUnitOfWork UnitOfWork { get; set; }
	
		public UserValidator(IUnitOfWork unitOfWork) {
			UnitOfWork = unitOfWork;
			RuleFor(x => x.Email).NotEmpty();
			RuleFor(x => x.Email).Must(BeUniqueEmail).WithMessage("Email already exists");
		}
		
		public bool BeUniqueEmail(string email)
		{
			return UnitOfWork.UserRepository.FindUserByEmail(email) == null;
		}
	}
}
