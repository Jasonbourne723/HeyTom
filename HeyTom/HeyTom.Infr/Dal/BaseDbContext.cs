using HeyTom.Domain.Model;
using JetBrains.Annotations;
using Microsoft.EntityFrameworkCore;

namespace HeyTom.Infr.Dal
{
	public class BaseDbContext : DbContext
	{
		public BaseDbContext( DbContextOptions<BaseDbContext> options) : base(options)
		{
		}
		public DbSet<Vip> Vip { get; set; }
		public DbSet<Cat> Vip_Cat { get; set; }

		public DbSet<Photo> Vip_Photo { get; set; }

		public DbSet<SimpleSay> Vip_SimpleSay { get; set; }
	}
}
