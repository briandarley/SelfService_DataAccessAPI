using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using UNC_SelfService_DataAccessAPI_Common.Entities.UtilityDb;
using UNC_SelfService_DataAccessAPI_Repository;

namespace XUnitTest_Repository.UtilityDb
{
    public class ProcessScheduleTests
    {
        private readonly ILogger<ProcessScheduleTests> _logger;

        public ProcessScheduleTests()
        {
            _logger = TestLoggerFactory.CreateLogger<ProcessScheduleTests>();
        }

        public UtilityDbContext CreateInMemoryDbContext()
        {
            var options = new DbContextOptionsBuilder<UtilityDbContext>()
                .UseInMemoryDatabase(Guid.NewGuid().ToString())
                .Options;

            return new UtilityDbContext(options);
        }

        [Fact]
        public void AddProcessSchedule_ShouldWork()
        {
            using var context = CreateInMemoryDbContext();

            var process = new Process
            {
                Name = "TestProcess",
                // ... other properties
            };

            context.Processes.Add(process);
            context.SaveChanges();

            var processSchedule = new ProcessSchedule
            {
                ProcessId = process.Id,
                StartTime = "08:00",
                // ... other properties
            };

            context.ProcessSchedules.Add(processSchedule);
            context.SaveChanges();

            var savedProcessSchedule = context.ProcessSchedules.FirstOrDefault();

            Assert.NotNull(savedProcessSchedule);
            Assert.Equal("08:00", savedProcessSchedule.StartTime);
            // ... other assertions
        }

        [Fact]
        public void UpdateProcessSchedule_ShouldWork()
        {
            using var context = CreateInMemoryDbContext();

            var process = new Process
            {
                Name = "TestProcess",
                // ... other properties
            };

            context.Processes.Add(process);
            context.SaveChanges();

            var processSchedule = new ProcessSchedule
            {
                ProcessId = process.Id,
                StartTime = "08:00",
                // ... other initial values
            };

            context.ProcessSchedules.Add(processSchedule);
            context.SaveChanges();

            processSchedule.StartTime = "09:00";
            context.ProcessSchedules.Update(processSchedule);
            context.SaveChanges();

            var updatedProcessSchedule = context.ProcessSchedules.FirstOrDefault();
            Assert.NotNull(updatedProcessSchedule);
            Assert.Equal("09:00", updatedProcessSchedule.StartTime);
            // ... other assertions
        }

        [Fact]
        public void RemoveProcessSchedule_ShouldWork()
        {
            using var context = CreateInMemoryDbContext();

            var process = new Process
            {
                Name = "TestProcess",
                // ... other properties
            };

            context.Processes.Add(process);
            context.SaveChanges();

            var processSchedule = new ProcessSchedule
            {
                ProcessId = process.Id,
                StartTime = "08:00",
                // ... other values
            };

            context.ProcessSchedules.Add(processSchedule);
            context.SaveChanges();

            context.ProcessSchedules.Remove(processSchedule);
            context.SaveChanges();

            var savedProcessSchedule = context.ProcessSchedules.FirstOrDefault();
            Assert.Null(savedProcessSchedule);
        }
    }
}
