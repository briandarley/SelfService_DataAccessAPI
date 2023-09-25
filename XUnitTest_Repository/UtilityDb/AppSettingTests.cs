using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using UNC_SelfService_DataAccessAPI_Common.Entities.UtilityDb;
using UNC_SelfService_DataAccessAPI_Repository;

namespace XUnitTest_Repository.UtilityDb
{
    public class AppSettingTests
    {
        private readonly ILogger<AppSettingTests> _logger;

        public AppSettingTests()
        {
            _logger = TestLoggerFactory.CreateLogger<AppSettingTests>();
        }
        public UtilityDbContext CreateInMemoryDbContext()
        {
            var options = new DbContextOptionsBuilder<UtilityDbContext>()
                .UseInMemoryDatabase(Guid.NewGuid().ToString())
                .Options;

            return new UtilityDbContext(options);
        }



        [Fact]
        public void AddAppSetting_ShouldWork()
        {
            using var context = CreateInMemoryDbContext();

            var appSetting = new AppSetting
            {
                Name = "TestName",
                Value = "TestValue",
                Description = "TestDescription",
                AppDomain = "TestDomain",
                OverLoad = "TestOverload"
            };

            context.AppSettings.Add(appSetting);
            context.SaveChanges();

            var savedSetting = context.AppSettings.FirstOrDefault();


            _logger.LogWarning("ChangeUser: {0}", savedSetting.ChangeUser);

            Assert.Equal($"{DateTime.Now.Date.Date}", savedSetting.CreateDate.Date.ToString());
            Assert.Equal($"{DateTime.Now.Date.Date}", savedSetting.ChangeDate.Value.Date.ToString());
            Assert.Equal("system", savedSetting.CreateUser);
            Assert.Equal("system", savedSetting.ChangeUser);

            Assert.NotNull(savedSetting);
            Assert.Equal("TestName", savedSetting.Name);
            // ... other assertions
        }

        [Fact]
        public void UpdateAppSetting_ShouldWork()
        {
            using var context = CreateInMemoryDbContext();

            var appSetting = new AppSetting
            {
                Name = "InitialName",
                Value = "InitialValue",
                // ... other initial values
            };

            context.AppSettings.Add(appSetting);
            context.SaveChanges();

            appSetting.Name = "UpdatedName";
            context.AppSettings.Update(appSetting);
            context.SaveChanges();

            var updatedSetting = context.AppSettings.FirstOrDefault();
            Assert.NotNull(updatedSetting);
            Assert.Equal("UpdatedName", updatedSetting.Name);

            _logger.LogWarning("ChangeUser: {0}", updatedSetting.ChangeUser);

            Assert.Equal($"{DateTime.Now.Date.Date}", updatedSetting.CreateDate.Date.ToString());
            Assert.Equal($"{DateTime.Now.Date.Date}", updatedSetting.ChangeDate.Value.Date.ToString());
            Assert.Equal("system", updatedSetting.CreateUser);
            Assert.Equal("system", updatedSetting.ChangeUser);
            Assert.NotNull(updatedSetting.ChangeUser);
        }

        [Fact]
        public void RemoveAppSetting_ShouldWork()
        {
            using var context = CreateInMemoryDbContext();

            var appSetting = new AppSetting
            {
                Name = "TestName",
                Value = "TestValue",
                // ... other values
            };

            context.AppSettings.Add(appSetting);
            context.SaveChanges();

            context.AppSettings.Remove(appSetting);
            context.SaveChanges();

            var savedSetting = context.AppSettings.FirstOrDefault();
            Assert.Null(savedSetting);
        }

    }
}
