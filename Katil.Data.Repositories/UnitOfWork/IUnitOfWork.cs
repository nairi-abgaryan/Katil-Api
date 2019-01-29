using System.Threading.Tasks;
using Katil.Data.Repositories.AppUser;

namespace Katil.Data.Repositories.UnitOfWork
{
    public interface IUnitOfWork
    {
        IUserRepository UserRepository { get; }
        Task<int> Complete();
    }
}
