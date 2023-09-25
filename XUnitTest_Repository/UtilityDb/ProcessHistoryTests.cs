using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using UNC_SelfService_DataAccessAPI_Common.Entities.UtilityDb;
using UNC_SelfService_DataAccessAPI_Repository;

namespace XUnitTest_Repository.UtilityDb
{
    public class ProcessHistoryTests
    {
        private readonly ILogger<ProcessHistoryTests> _logger;

        public ProcessHistoryTests()
        {
            _logger = TestLoggerFactory.CreateLogger<ProcessHistoryTests>();
        }

        public UtilityDbContext CreateInMemoryDbContext()
        {
            var options = new DbContextOptionsBuilder<UtilityDbContext>()
                .UseInMemoryDatabase(Guid.NewGuid().ToString())
                .Options;

            return new UtilityDbContext(options);
        }

        [Fact]
        public void AddProcessHistory_ShouldWork()
        {
            using var context = CreateInMemoryDbContext();

            var processHistory = new ProcessHistory
            {
                Name = "TestHistory",
                StartDate = DateTime.Now,
                MachineName = "TestMachine",
                // ... other properties
            };

            context.ProcessHistories.Add(processHistory);
            context.SaveChanges();

            var savedProcessHistory = context.ProcessHistories.FirstOrDefault();

            Assert.NotNull(savedProcessHistory);
            Assert.Equal("TestHistory", savedProcessHistory.Name);
            // ... other assertions
        }

        [Fact]
        public void UpdateProcessHistory_ShouldWork()
        {
            using var context = CreateInMemoryDbContext();

            var processHistory = new ProcessHistory
            {
                Name = "InitialHistory",
                StartDate = DateTime.Now,
                // ... other initial values
            };

            context.ProcessHistories.Add(processHistory);
            context.SaveChanges();

            processHistory.Name = "UpdatedHistory";
            context.ProcessHistories.Update(processHistory);
            context.SaveChanges();

            var updatedProcessHistory = context.ProcessHistories.FirstOrDefault();
            Assert.NotNull(updatedProcessHistory);
            Assert.Equal("UpdatedHistory", updatedProcessHistory.Name);
            // ... other assertions
        }

        [Fact]
        public void RemoveProcessHistory_ShouldWork()
        {
            using var context = CreateInMemoryDbContext();

            var processHistory = new ProcessHistory
            {
                Name = "TestHistory",
                StartDate = DateTime.Now,
                // ... other values
            };

            context.ProcessHistories.Add(processHistory);
            context.SaveChanges();

            context.ProcessHistories.Remove(processHistory);
            context.SaveChanges();

            var savedProcessHistory = context.ProcessHistories.FirstOrDefault();
            Assert.Null(savedProcessHistory);
        }
    }

}
