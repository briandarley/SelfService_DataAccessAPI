using Microsoft.EntityFrameworkCore;
using UNC_SelfService_DataAccessAPI_Common.Entities.UtilityDb;

namespace UNC_SelfService_DataAccessAPI_Repository
{
    public class UtilityDbContext: AuditableDbContext<UtilityDbContext>
    {
        public UtilityDbContext(DbContextOptions<UtilityDbContext> options) : base(options)
        {
        }
        
        public DbSet<AppSetting> AppSettings { get; set; }

        public async Task MigrateDatabase()
        {

        }
              

        protected override void OnModelCreating(ModelBuilder builder)
        {
        
            BuildModelForAppSettings(builder);

            //SeedDatabase(builder);

        }

        private void BuildModelForAppSettings(ModelBuilder builder)
        {
            builder.Entity<AppSetting>(entry =>
            {
                entry.ToTable("AppSettings");
                entry.HasKey(c => c.Id);
                entry.Property(c => c.Name).HasMaxLength(50);
                entry.Property(c => c.Value).HasColumnType("nvarchar(max)");
                entry.Property(c => c.AppDomain).HasMaxLength(255);
                entry.Property(c => c.OverLoad).HasColumnType("nvarchar(max)");
                entry.Property(c => c.CreateDate).HasDefaultValueSql("getdate()");
                entry.Property(c => c.CreateUser).HasMaxLength(50).HasDefaultValue("System");
                entry.Property(c => c.ChangeDate).HasDefaultValueSql("getdate()");
                entry.Property(c => c.ChangeUser).HasMaxLength(50).HasDefaultValue("System");


            });
        }
    }
}
