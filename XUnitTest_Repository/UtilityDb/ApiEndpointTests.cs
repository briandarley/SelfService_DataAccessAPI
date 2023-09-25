using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using UNC_SelfService_DataAccessAPI_Common.Entities.UtilityDb;
using UNC_SelfService_DataAccessAPI_Repository;

namespace XUnitTest_Repository.UtilityDb
{
    public class ApiEndpointTests
    {
        private readonly ILogger<ApiEndpointTests> _logger;

        public ApiEndpointTests()
        {
            _logger = TestLoggerFactory.CreateLogger<ApiEndpointTests>();
        }

        public UtilityDbContext CreateInMemoryDbContext()
        {
            var options = new DbContextOptionsBuilder<UtilityDbContext>()
                .UseInMemoryDatabase(Guid.NewGuid().ToString())
                .Options;

            return new UtilityDbContext(options);
        }

        [Fact]
        public void AddApiEndpoint_ShouldWork()
        {
            using var context = CreateInMemoryDbContext();

            var apiEndpoint = new ApiEndpoint
            {
                Name = "TestEndpoint",
                Description = "TestDescription",
                Notes = "TestNotes",
                Uri = "http://test.uri",
                Environment = "TestEnvironment"
            };

            context.ApiEndpoints.Add(apiEndpoint);
            context.SaveChanges();

            var savedEndpoint = context.ApiEndpoints.FirstOrDefault();

            _logger.LogWarning("ChangeUser: {0}", savedEndpoint.ChangeUser);

            Assert.Equal($"{DateTime.Now.Date.Date}", savedEndpoint.CreateDate.Date.ToString());
            Assert.Equal($"{DateTime.Now.Date.Date}", savedEndpoint.ChangeDate.Value.Date.ToString());
            Assert.Equal("system", savedEndpoint.CreateUser);
            Assert.Equal("system", savedEndpoint.ChangeUser);

            Assert.NotNull(savedEndpoint);
            Assert.Equal("TestEndpoint", savedEndpoint.Name);
            // ... other assertions
        }

        [Fact]
        public void UpdateApiEndpoint_ShouldWork()
        {
            using var context = CreateInMemoryDbContext();

            var apiEndpoint = new ApiEndpoint
            {
                Name = "InitialEndpoint",
                Description = "InitialDescription",
                // ... other initial values
            };

            context.ApiEndpoints.Add(apiEndpoint);
            context.SaveChanges();

            apiEndpoint.Name = "UpdatedEndpoint";
            context.ApiEndpoints.Update(apiEndpoint);
            context.SaveChanges();

            var updatedEndpoint = context.ApiEndpoints.FirstOrDefault();
            Assert.NotNull(updatedEndpoint);
            Assert.Equal("UpdatedEndpoint", updatedEndpoint.Name);

            _logger.LogWarning("ChangeUser: {0}", updatedEndpoint.ChangeUser);

            Assert.Equal($"{DateTime.Now.Date.Date}", updatedEndpoint.CreateDate.Date.ToString());
            Assert.Equal($"{DateTime.Now.Date.Date}", updatedEndpoint.ChangeDate.Value.Date.ToString());
            Assert.Equal("system", updatedEndpoint.CreateUser);
            Assert.Equal("system", updatedEndpoint.ChangeUser);
            Assert.NotNull(updatedEndpoint.ChangeUser);
        }

        [Fact]
        public void RemoveApiEndpoint_ShouldWork()
        {
            using var context = CreateInMemoryDbContext();

            var apiEndpoint = new ApiEndpoint
            {
                Name = "TestEndpoint",
                Description = "TestDescription",
                // ... other values
            };

            context.ApiEndpoints.Add(apiEndpoint);
            context.SaveChanges();

            context.ApiEndpoints.Remove(apiEndpoint);
            context.SaveChanges();

            var savedEndpoint = context.ApiEndpoints.FirstOrDefault();
            Assert.Null(savedEndpoint);
        }
    }

}
