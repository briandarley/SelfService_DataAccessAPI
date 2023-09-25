using Microsoft.EntityFrameworkCore;
using UNC_SelfService_DataAccessAPI_Common.Entities.SelfServiceDb;

namespace UNC_SelfService_DataAccessAPI_Repository
{
    public class SelfServiceDbContext : AuditableDbContext<SelfServiceDbContext>
    {

        public DbSet<MenuItem> MenuItems { get; set; }
        public DbSet<RouteItem> RouteItems { get; set; }
        public DbSet<RouteItemTag> RouteItemTags { get; set; }
        public DbSet<RouteScheduleDowntime> RouteScheduleDowntimes { get; set; }


        public SelfServiceDbContext(DbContextOptions<SelfServiceDbContext> options) : base(options)
        {
        }

        public async Task MigrateDatabase()
        {
        }


        protected override void OnModelCreating(ModelBuilder builder)
        {
            BuildModelForMenuItems(builder);
            BuildModelForRouteItems(builder);
            BuildModelForRouteItemTags(builder);
            BuildModelForRouteScheduleDowntime(builder);
        }

        private void BuildModelForRouteScheduleDowntime(ModelBuilder builder)
        {
            builder.Entity<RouteScheduleDowntime>(entry =>
            {
                entry.ToTable("RouteScheduleDowntime", "SelfService");
                // Primary Key
                entry.HasKey(r => r.Id);

                // Properties
                entry.Property(r => r.ScheduledOnDate).IsRequired();
                entry.Property(r => r.NewRoute).IsRequired().HasMaxLength(255); 
                entry.Property(r => r.CurrentRoute).IsRequired().HasMaxLength(255);
                entry.Property(r => r.Archived).IsRequired();

                // Relationships
                entry.HasOne(r => r.RouteItem)
                    .WithMany() // Assuming RouteItem has a collection of RouteScheduleDowntime
                    .HasForeignKey(r => r.RouteItemId)
                    .OnDelete(DeleteBehavior.Restrict); // Assuming you don't want to cascade delete

            });
        }

        private void BuildModelForMenuItems(ModelBuilder builder)
        {
            builder.Entity<MenuItem>(entry =>
            {
                entry.ToTable("MenuItem", "SelfService");
                entry.HasKey(c => c.Id);
                entry.Property(c => c.MenuText).IsRequired().HasMaxLength(255);
                entry.Property(c => c.Icon).HasMaxLength(255);
                entry.Property(c => c.Category).HasMaxLength(255);


                entry.Property(c => c.CreateDate).HasDefaultValueSql("getdate()");
                entry.Property(c => c.CreateUser).HasMaxLength(50).HasDefaultValue("System");
                entry.Property(c => c.ChangeDate).HasDefaultValueSql("getdate()");
                entry.Property(c => c.ChangeUser).HasMaxLength(50).HasDefaultValue("System");
                entry
                    .HasOne(c => c.ParentMenuItem)
                    .WithMany(c => c.ChildMenuItems)
                    .HasForeignKey(c => c.ParentMenuItemId)
                    .OnDelete(DeleteBehavior.Restrict);

                entry.HasIndex(c=> c.RouteItemId).HasDatabaseName("IX_MenuItem_RouteItemId");

            });
        }

        private void BuildModelForRouteItems(ModelBuilder builder)
        {
            builder.Entity<RouteItem>(entry =>
            {
                entry.ToTable("RouteItem", "SelfService");
                entry.HasKey(c => c.Id);

                entry.Property(c => c.Route).HasMaxLength(255).IsRequired();
                entry.Property(c => c.FilePath).HasMaxLength(255);
                entry.Property(c => c.FileName).HasMaxLength(255);
                entry.Property(c => c.Description).HasMaxLength(255);
                entry.Property(c => c.SearchDescription).HasMaxLength(255);
                entry.Property(c => c.Searchable);
                entry.Property(c => c.LinkText).HasMaxLength(255);
                entry.Property(c => c.RequireAuth);
                entry.Property(c => c.RequireMfa);


                entry.Property(c => c.CreateDate).HasDefaultValueSql("getdate()");
                entry.Property(c => c.CreateUser).HasMaxLength(50).HasDefaultValue("System");
                entry.Property(c => c.ChangeDate).HasDefaultValueSql("getdate()");
                entry.Property(c => c.ChangeUser).HasMaxLength(50).HasDefaultValue("System");
                entry
                .HasMany(c => c.RouteItemTags)
                .WithOne(c => c.RouteItem)
                    .HasForeignKey(c => c.RouteItemId)
                    .OnDelete(DeleteBehavior.Cascade);
              

            });
        }

        private void BuildModelForRouteItemTags(ModelBuilder builder)
        {
            builder.Entity<RouteItemTag>(entry =>
            {
                entry.ToTable("RouteItemTag", "SelfService");
                entry.HasKey(c => c.Id);
                
                entry.Property(c => c.RouteItemId).IsRequired();
                entry.Property(c => c.Tag)
                    .HasMaxLength(50)
                    .IsRequired();

                entry.HasIndex(c => c.RouteItemId).HasDatabaseName("IX_RouteItemTag_RouteItemId");




            });
        }
    }
}
