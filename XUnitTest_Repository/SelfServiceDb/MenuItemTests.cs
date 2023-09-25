using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using UNC_SelfService_DataAccessAPI_Common.Entities.SelfServiceDb;
using UNC_SelfService_DataAccessAPI_Repository;

namespace XUnitTest_Repository.SelfServiceDb
{

    public class MenuItemTests
    {
        private readonly ILogger<MenuItemTests> _logger;

        public MenuItemTests()
        {
            _logger = TestLoggerFactory.CreateLogger<MenuItemTests>();
        }

        public SelfServiceDbContext CreateInMemoryDbContext()
        {
            var options = new DbContextOptionsBuilder<SelfServiceDbContext>()
                .UseInMemoryDatabase(Guid.NewGuid().ToString())
                .Options;

            return new SelfServiceDbContext(options);
        }

        [Fact]
        public void AddMenuItem_ShouldWork()
        {
            using var context = CreateInMemoryDbContext();

            var routeItem = new RouteItem
            {
                Route = "/test",
                FilePath = "/path/to/file",
                FileName = "test.html",
                // ... other properties
            };

            context.RouteItems.Add(routeItem);
            context.SaveChanges();

            var menuItem = new MenuItem
            {
                RouteItemId = routeItem.Id,
                MenuText = "Test Menu",
                Icon = "test-icon",
                Category = "Test",
                Order = 1,
                // ... other properties
            };

            context.MenuItems.Add(menuItem);
            context.SaveChanges();

            var savedMenuItem = context.MenuItems.Include(m => m.RouteItem).FirstOrDefault();

            Assert.NotNull(savedMenuItem);
            Assert.Equal("Test Menu", savedMenuItem.MenuText);
            Assert.Equal("/test", savedMenuItem.RouteItem.Route);
            // ... other assertions
        }

        [Fact]
        public void UpdateMenuItem_ShouldWork()
        {
            using var context = CreateInMemoryDbContext();

            var routeItem = new RouteItem
            {
                Route = "/test",
                FilePath = "/path/to/file",
                FileName = "test.html",
                // ... other properties
            };

            context.RouteItems.Add(routeItem);
            context.SaveChanges();

            var menuItem = new MenuItem
            {
                RouteItemId = routeItem.Id,
                MenuText = "Initial Menu",
                Icon = "initial-icon",
                Category = "Initial",
                Order = 1,
                // ... other properties
            };

            context.MenuItems.Add(menuItem);
            context.SaveChanges();

            menuItem.MenuText = "Updated Menu";
            menuItem.Icon = "updated-icon";
            menuItem.Category = "Updated";
            menuItem.Order = 2;
            context.MenuItems.Update(menuItem);
            context.SaveChanges();

            var savedMenuItem = context.MenuItems.Include(m => m.RouteItem).FirstOrDefault();

            Assert.NotNull(savedMenuItem);
            Assert.Equal("Updated Menu", savedMenuItem.MenuText);
            Assert.Equal("updated-icon", savedMenuItem.Icon);
            Assert.Equal("Updated", savedMenuItem.Category);
            Assert.Equal(2, savedMenuItem.Order);
            // ... other assertions
        }
        
        [Fact]
        public void RemoveMenuItem_ShouldWork()
        {
            using var context = CreateInMemoryDbContext();

            var menuItem = new MenuItem
            {
                Category = "Test",
                Icon = "test-icon",
                MenuText = "Test Menu",
                Order = 1
                // ... other values
            };

            context.MenuItems.Add(menuItem);
            context.SaveChanges();

            context.MenuItems.Remove(menuItem);
            context.SaveChanges();

            var savedEntity = context.MenuItems.FirstOrDefault();
            Assert.Null(savedEntity);

        }
        

      
    }

}
