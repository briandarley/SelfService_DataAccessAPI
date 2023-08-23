using Microsoft.EntityFrameworkCore;
using UNC_SelfService_DataAccessAPI_Common.Entities;

namespace UNC_SelfService_DataAccessAPI_Repository
{
    public abstract class AuditableDbContext<T> : DbContext where T : DbContext
    {
        public AuditableDbContext(DbContextOptions<T> options) : base(options)
        {
        }
        public override int SaveChanges()
        {
            var currentUsername = "system"; // Replace with your actual logic to get the current user

            // Handle entities that are being added
            var addedAuditedEntities = ChangeTracker.Entries<IAuditable>()
                .Where(p => p.State == EntityState.Added)
                .Select(p => p.Entity);

            foreach (var entity in addedAuditedEntities)
            {
                entity.CreateDate = DateTime.UtcNow;
                entity.CreateUser = entity.CreateUser ?? currentUsername;
                entity.ChangeDate = DateTime.UtcNow;
                entity.ChangeUser = entity.ChangeUser ?? currentUsername;
            }

            // Handle entities that are being modified
            var modifiedAuditedEntities = ChangeTracker.Entries<IAuditable>()
                .Where(p => p.State == EntityState.Modified)
                .Select(p => p.Entity);

            foreach (var entity in modifiedAuditedEntities)
            {
                // Only update the ChangeDate and ChangeUser for modified entities
                entity.ChangeDate = DateTime.UtcNow;
                entity.ChangeUser = entity.ChangeUser ?? currentUsername;

                // Ensure the original values for CreateDate and CreateUser are not changed
                var originalValues = this.Entry(entity).OriginalValues;
                entity.CreateDate = (DateTime)originalValues["CreateDate"];
                entity.CreateUser = (string)originalValues["CreateUser"];
            }

            return base.SaveChanges();
        }
    }
}
