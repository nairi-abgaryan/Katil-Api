using System;
using System.Data.Common;
using System.Diagnostics;
using System.Threading.Tasks;
using Katil.Data.Model;
using Katil.Data.Repositories.AppUser;
using Microsoft.EntityFrameworkCore;

namespace Katil.Data.Repositories.UnitOfWork
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly AppDbContext _context;
        private IUserRepository userRepository = null;

        public UnitOfWork(AppDbContext context)
        {
            _context = context;
        }

        public IUserRepository UserRepository => userRepository ?? new UserRepository(_context);

        public async Task<int> Complete()
        {
            using (var scope = _context.Database.BeginTransaction())
            {
                try
                {
                    var res = await _context.SaveChangesAsync();
                    scope.Commit();
                    return res;
                }
                catch (DbException ex)
                {
                    scope.Rollback();
                    Debug.WriteLine(ex.Message);
                    return await Task.FromResult(ex.ErrorCode);
                }
                catch (InvalidOperationException ex)
                {
                    Debug.WriteLine(ex.Message);
                    throw;
                }
                catch (DbUpdateConcurrencyException ex)
                {
                    Debug.WriteLine(ex.Message);
                    throw;
                }
                catch (Exception ex)
                {
                    Debug.WriteLine(ex.Message);
                    throw;
                }
            }
        }
    }
}
