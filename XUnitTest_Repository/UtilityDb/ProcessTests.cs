using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using UNC_SelfService_DataAccessAPI_Common.Entities.UtilityDb;
using UNC_SelfService_DataAccessAPI_Repository;

namespace XUnitTest_Repository.UtilityDb
{
    public class ProcessTests
    {
        private readonly ILogger<ProcessTests> _logger;

        public ProcessTests()
        {
            _logger = TestLoggerFactory.CreateLogger<ProcessTests>();
        }

        public UtilityDbContext CreateInMemoryDbContext()
        {
            var options = new DbContextOptionsBuilder<UtilityDbContext>()
                .UseInMemoryDatabase(Guid.NewGuid().ToString())
                .Options;

            return new UtilityDbContext(options);
        }

        [Fact]
        public void AddProcess_ShouldWork()
        {
            using var context = CreateInMemoryDbContext();

            var process = new Process
            {
                Name = "TestProcess",
                ProcessType = "TypeA",
                // ... other properties
            };

            context.Processes.Add(process);
            context.SaveChanges();

            var savedProcess = context.Processes.FirstOrDefault();

            Assert.NotNull(savedProcess);
            Assert.Equal("TestProcess", savedProcess.Name);
            // ... other assertions
        }

        [Fact]
        public void UpdateProcess_ShouldWork()
        {
            using var context = CreateInMemoryDbContext();

            var process = new Process
            {
                Name = "InitialProcess",
                // ... other initial values
            };

            context.Processes.Add(process);
            context.SaveChanges();

            process.Name = "UpdatedProcess";
            context.Processes.Update(process);
            context.SaveChanges();

            var updatedProcess = context.Processes.FirstOrDefault();
            Assert.NotNull(updatedProcess);
            Assert.Equal("UpdatedProcess", updatedProcess.Name);
            // ... other assertions
        }

        [Fact]
        public void RemoveProcess_ShouldWork()
        {
            using var context = CreateInMemoryDbContext();

            var process = new Process
            {
                Name = "TestProcess",
                // ... other values
            };

            context.Processes.Add(process);
            context.SaveChanges();

            context.Processes.Remove(process);
            context.SaveChanges();

            var savedProcess = context.Processes.FirstOrDefault();
            Assert.Null(savedProcess);
        }
    }

    

}
