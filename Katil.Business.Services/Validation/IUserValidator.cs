namespace Katil.Business.Services.Validation
{
	public interface IUserValidator
	{
		bool BeUniqueUrl(string url);
	}
}
