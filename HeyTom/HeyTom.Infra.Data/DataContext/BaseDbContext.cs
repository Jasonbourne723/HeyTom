using HeyTom.Domain.Models;
using JetBrains.Annotations;
using Microsoft.EntityFrameworkCore;

namespace HeyTom.Infra.DataContext
{
	public partial class HeyTomContext : DbContext
	{
		public HeyTomContext()
		{
		}

		public HeyTomContext(DbContextOptions<HeyTomContext> options)
			: base(options)
		{
		}

		public virtual DbSet<Vip> Vip { get; set; }
		public virtual DbSet<VipCat> VipCat { get; set; }
		public virtual DbSet<VipPhoto> VipPhoto { get; set; }
		public virtual DbSet<VipSimpleSay> VipSimpleSay { get; set; }

		protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
		{
			if (!optionsBuilder.IsConfigured)
			{
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
				optionsBuilder.UseMySql("server=192.168.0.126;userid=test1;password=123456;database=HeyTom;charset=utf8;sslMode=None;");
			}
		}

		protected override void OnModelCreating(ModelBuilder modelBuilder)
		{
			modelBuilder.Entity<Vip>(entity => {
				entity.Property(e => e.Id).HasColumnType("bigint(20)");

				entity.Property(e => e.Address)
					.IsRequired()
					.HasColumnType("varchar(200)")
					.HasDefaultValueSql("''");

				entity.Property(e => e.Birthday).HasColumnType("datetime");

				entity.Property(e => e.City)
					.IsRequired()
					.HasColumnType("varchar(50)")
					.HasDefaultValueSql("''");

				entity.Property(e => e.Email)
					.IsRequired()
					.HasColumnName("EMail")
					.HasColumnType("varchar(255)")
					.HasDefaultValueSql("''");

				entity.Property(e => e.GitHubId)
					.HasColumnType("bigint(12)")
					.HasDefaultValueSql("'0'");

				entity.Property(e => e.Icon)
					.IsRequired()
					.HasColumnType("varchar(500)")
					.HasDefaultValueSql("''");

				entity.Property(e => e.Mark).HasColumnType("varchar(500)");

				entity.Property(e => e.Mobile)
					.IsRequired()
					.HasColumnType("varchar(50)")
					.HasDefaultValueSql("''");

				entity.Property(e => e.Name)
					.IsRequired()
					.HasColumnType("varchar(200)")
					.HasDefaultValueSql("''");

				entity.Property(e => e.NickName)
					.IsRequired()
					.HasColumnType("varchar(200)")
					.HasDefaultValueSql("''");

				entity.Property(e => e.PassWord)
					.IsRequired()
					.HasColumnType("varchar(255)")
					.HasDefaultValueSql("''");

				entity.Property(e => e.Province)
					.IsRequired()
					.HasColumnType("varchar(50)")
					.HasDefaultValueSql("''");

				entity.Property(e => e.Sex)
					.HasColumnType("tinyint(4)")
					.HasDefaultValueSql("'1'");

				entity.Property(e => e.WxOpenId)
					.IsRequired()
					.HasColumnType("varchar(200)")
					.HasDefaultValueSql("''");
			});

			modelBuilder.Entity<VipCat>(entity => {
				entity.ToTable("Vip_Cat");

				entity.Property(e => e.Id).HasColumnType("bigint(20)");

				entity.Property(e => e.Birthday).HasColumnType("datetime");

				entity.Property(e => e.BreedId)
					.HasColumnType("int(11)")
					.HasDefaultValueSql("'0'");

				entity.Property(e => e.Icon)
					.IsRequired()
					.HasColumnType("varchar(500)")
					.HasDefaultValueSql("''");

				entity.Property(e => e.Name)
					.IsRequired()
					.HasColumnType("varchar(200)")
					.HasDefaultValueSql("''");

				entity.Property(e => e.Sex)
					.HasColumnType("tinyint(4)")
					.HasDefaultValueSql("'1'");

				entity.Property(e => e.VipId)
					.HasColumnType("bigint(20)")
					.HasDefaultValueSql("'0'");
			});

			modelBuilder.Entity<VipPhoto>(entity => {
				entity.ToTable("Vip_Photo");

				entity.Property(e => e.Id).HasColumnType("bigint(20)");

				entity.Property(e => e.PhotoUrl)
					.IsRequired()
					.HasColumnType("varchar(500)")
					.HasDefaultValueSql("''");

				entity.Property(e => e.SimpleSayId)
					.HasColumnType("bigint(20)")
					.HasDefaultValueSql("'0'");

				entity.Property(e => e.VipId)
					.HasColumnType("bigint(20)")
					.HasDefaultValueSql("'0'");
			});

			modelBuilder.Entity<VipSimpleSay>(entity => {
				entity.ToTable("Vip_SimpleSay");

				entity.Property(e => e.Id).HasColumnType("bigint(20)");

				entity.Property(e => e.Body).HasColumnType("text");

				entity.Property(e => e.CreateTime).HasColumnType("datetime");

				entity.Property(e => e.VipId)
					.HasColumnType("bigint(20)")
					.HasDefaultValueSql("'0'");
			});
		}
	}
}
