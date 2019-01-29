using Microsoft.EntityFrameworkCore;

namespace Katil.Data.Model.EntityFramework
{
	public class DbContextDesignTimeDbContextFactory : DesignTimeDbContextFactoryBase<AppDbContext>
	{
		protected override AppDbContext CreateNewInstance(
			DbContextOptions<AppDbContext> options)
		{
			return new AppDbContext(options);
		}
	}
}