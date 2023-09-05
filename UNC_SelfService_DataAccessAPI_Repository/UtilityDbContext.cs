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
        public DbSet<ApiEndpoint> ApiEndpoints { get; set; }
        public DbSet<OrganizationalUnit> OrganizationalUnits { get; set; }
        public DbSet<OrganizationalUnitAdmin> OrganizationalUnitAdmins { get; set; }
        public DbSet<Process> Processes { get; set; }
        public DbSet<ProcessSchedule> ProcessSchedules { get; set; }
        public DbSet<ProcessHistory> ProcessHistories { get; set; }


        public async Task MigrateDatabase()
        {

        }
              

        protected override void OnModelCreating(ModelBuilder builder)
        {
        
            BuildModelForAppSettings(builder);
            BuildModelForApiEndpoint(builder);
            BuildModelForOrganizationalUnit(builder);
            BuildModelForOrganizationalUnitAdmin(builder);
            BuildModelForProcess(builder);
            BuildModelForProcessSchedule(builder);
            BuildModelForProcessHistory(builder);
            //SeedDatabase(builder);

        }

        private void BuildModelForProcess(ModelBuilder builder)
        {
            builder.Entity<Process>(entry =>
            {

                entry.ToTable("Process", "UtilityDb", c => c.HasTrigger("Process_Change"));
                entry.HasKey(c => c.Id);
                entry.Property(c => c.Name).HasMaxLength(255);
                entry.Property(c => c.ProcessType).HasMaxLength(50);
                entry.Property(c => c.Description).HasMaxLength(255);
                entry.Property(c => c.AppDomain).HasMaxLength(255);
                entry.Property(c => c.QueueName).HasMaxLength(50);
                entry.Property(c => c.Arguments);
                entry.Property(c => c.CreateDate).HasDefaultValueSql("getdate()");
                entry.Property(c => c.CreateUser).HasMaxLength(50).HasDefaultValue("System");
                entry.Property(c => c.ChangeDate).HasDefaultValueSql("getdate()");
                entry.Property(c => c.ChangeUser).HasMaxLength(50).HasDefaultValue("System");
                entry
                    .HasMany(c => c.ProcessSchedules)
                    .WithOne(c => c.Process)
                    .HasForeignKey(c => c.ProcessId);

            });
        }

        private void BuildModelForProcessSchedule(ModelBuilder builder)
        {
            builder.Entity<ProcessSchedule>(entry =>
            {

                entry.ToTable("ProcessSchedule", "UtilityDb", c => c.HasTrigger("ProcessSchedule_Change"));
                entry.HasKey(c => c.Id);
                entry.Property(c => c.Comments);
                entry.Property(c => c.RepeatCycle).HasMaxLength(5);
                entry.Property(c => c.StartTime).HasMaxLength(12);
                entry.Property(c => c.CreateDate).HasDefaultValueSql("getdate()");
                entry.Property(c => c.CreateUser).HasMaxLength(50).HasDefaultValue("System");
                entry.Property(c => c.ChangeDate).HasDefaultValueSql("getdate()");
                entry.Property(c => c.ChangeUser).HasMaxLength(50).HasDefaultValue("System");
                entry
                    .HasOne(c => c.Process)
                    .WithMany(c => c.ProcessSchedules)
                    .HasForeignKey(c => c.ProcessId);
            });
        }

        private void BuildModelForProcessHistory(ModelBuilder builder)
        {
            builder.Entity<ProcessHistory>(entry =>
            {
                entry.ToTable("ProcessHistory", "UtilityDb");
                entry.HasKey(c => c.Id);
                entry.Property(c => c.Name).HasMaxLength(100);
                entry.Property(c => c.Source).HasMaxLength(100);
                entry.Property(c => c.MachineName).HasMaxLength(255);
                entry.Property(c => c.Remarks);
                entry.Property(c => c.Arguments);
                entry.Property(c => c.Arguments);
                entry.Property(c => c.ErrorMessage);
                entry.Property(c => c.StartDate);
                entry.Property(c => c.EndDate);
            });
        }

        private void BuildModelForOrganizationalUnitAdmin(ModelBuilder builder)
        {
            builder.Entity<OrganizationalUnitAdmin>(entry =>
            {
                entry.ToTable("OrganizationalUnitAdmin", "UtilityDb");
                entry.HasKey(c => c.Id);
                entry.Property(c => c.SamAccountName).HasMaxLength(50);
                entry.Property(c => c.Name).HasMaxLength(50);
                entry.Property(c => c.Mail).HasMaxLength(50);
                entry.Property(c => c.Phone).HasMaxLength(50);
                entry.Property(c => c.Note).HasMaxLength(255);
                entry.Property(c => c.CreateDate).HasDefaultValueSql("getdate()");
                entry.Property(c => c.CreateUser).HasMaxLength(50).HasDefaultValue("System");
                entry.Property(c => c.ChangeDate).HasDefaultValueSql("getdate()");
                entry.Property(c => c.ChangeUser).HasMaxLength(50).HasDefaultValue("System");

                entry.HasOne(c => c.OrganizationalUnit)
                    .WithMany(c => c.OrganizationalUnitAdmins)
                    .HasForeignKey(c => c.OrganizationalUnitId)
                    .OnDelete(DeleteBehavior.Cascade);
            });
        }

        private void BuildModelForOrganizationalUnit(ModelBuilder builder)
        {
            builder.Entity<OrganizationalUnit>(entry =>
            {
                entry.ToTable("OrganizationalUnit", "UtilityDb");
                entry.HasKey(c => c.Id);
                entry.Property(c => c.Name).HasMaxLength(255);
                entry.Property(c => c.DistinguishedName).HasMaxLength(255);
                entry.Property(c => c.AdsPath).HasMaxLength(255);
                entry.Property(c => c.Department);
                entry.Property(c => c.ObjectCategory).HasMaxLength(255);
                entry.Property(c => c.ObjectGuid).HasMaxLength(255);
                entry.Property(c => c.OuAdminGroup).HasMaxLength(255);

                entry.Property(c => c.CreateDate).HasDefaultValueSql("getdate()");
                entry.Property(c => c.CreateUser).HasMaxLength(50).HasDefaultValue("System");
                entry.Property(c => c.ChangeDate).HasDefaultValueSql("getdate()");
                entry.Property(c => c.ChangeUser).HasMaxLength(50).HasDefaultValue("System");
                entry
                    .HasMany(c => c.OrganizationalUnitAdmins)
                    .WithOne(c => c.OrganizationalUnit)
                    .HasForeignKey(c => c.OrganizationalUnitId);


            });
        }

        private void BuildModelForAppSettings(ModelBuilder builder)
        {
            builder.Entity<AppSetting>(entry =>
            {
                entry.ToTable("AppSetting", "UtilityDb");
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
        private void BuildModelForApiEndpoint(ModelBuilder builder)
        {
            builder.Entity<ApiEndpoint>(entry =>
            {
                entry.ToTable("ApiEndpoint", "UtilityDb");
                entry.HasKey(c => c.Id);
                entry.Property(c => c.Name).HasMaxLength(50);
                entry.Property(c => c.Description).HasMaxLength(255);
                entry.Property(c => c.Uri).HasMaxLength(255);
                entry.Property(c => c.Environment).HasMaxLength(255);
                entry.Property(c => c.CreateDate).HasDefaultValueSql("getdate()");
                entry.Property(c => c.CreateUser).HasMaxLength(50).HasDefaultValue("System");
                entry.Property(c => c.ChangeDate).HasDefaultValueSql("getdate()");
                entry.Property(c => c.ChangeUser).HasMaxLength(50).HasDefaultValue("System");

            });
        }
    }
}
