using Microsoft.EntityFrameworkCore;

namespace WebHocTap.Models
{
    public class AppDbContext: DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {

        }

		public DbSet<Permission> Permission { get; set; }
		public DbSet<User> User { get; set; }
		public DbSet<MonHoc> Mon { get; set; }
		public DbSet<KhoaHoc> KhoaHoc { get; set; }
		public DbSet<LopHoc> Lop { get; set; }
		public DbSet<Lop_MonHoc> Lop_MonHoc { get; set; }
		public DbSet<Lop_SinhVien> Lop_SinhVien { get; set; }
		public DbSet<ThiKiemTra> HinhThuc_Thi_KiemTra { get; set; }
		public DbSet<HinhThuc> HinhThuc { get; set; }
		public DbSet<DiemSinhVien> Diem { get; set; }


		protected override void OnModelCreating(ModelBuilder builder)
		{
			base.OnModelCreating(builder);
			builder.Entity<DiemSinhVien>().HasOne<User>(p => p.SinhVien).WithMany().OnDelete(DeleteBehavior.NoAction);
			builder.Entity<Lop_SinhVien>().HasOne<User>(p => p.SinhVien).WithMany().OnDelete(DeleteBehavior.NoAction);
		}
		protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
		{
			if (!optionsBuilder.IsConfigured)
			{
				IConfigurationRoot configuration = new ConfigurationBuilder()
					.SetBasePath(Directory.GetCurrentDirectory())
					.AddJsonFile("appsettings.json")
					.Build();

				var connectionString = configuration.GetConnectionString("DefaultConnection");
				optionsBuilder.UseSqlServer(connectionString);
			}
		}
	}
}
