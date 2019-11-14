using HeyTom.Domain.Model;
using Microsoft.EntityFrameworkCore;

namespace HeyTom.Infr.Dal
{
	public class VipDbContext : BaseDbContext<Vip>
	{
		public VipDbContext(DbContextOptions<BaseDbContext<Vip>> options) : base(options)
		{
		}

		protected override void OnModelCreating(ModelBuilder modelBuilder)
		{
			modelBuilder.Entity<Vip>().ToTable("Vip");
		}
	}

	public class BaseDbContext<T> : DbContext where T : class, new()
	{
		public BaseDbContext(DbContextOptions<BaseDbContext<T>> options) : base(options)
		{
		}
		public DbSet<T> List { get; set; }
	}
}
