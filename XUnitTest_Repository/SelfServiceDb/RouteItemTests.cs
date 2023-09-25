using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using UNC_SelfService_DataAccessAPI_Common.Entities.SelfServiceDb;
using UNC_SelfService_DataAccessAPI_Repository;

namespace XUnitTest_Repository.SelfServiceDb
{
    public class RouteItemTests
    {
        private readonly ILogger<RouteItemTests> _logger;

        public RouteItemTests()
        {
            _logger = TestLoggerFactory.CreateLogger<RouteItemTests>();
        }

        public SelfServiceDbContext CreateInMemoryDbContext()
        {
            var options = new DbContextOptionsBuilder<SelfServiceDbContext>()
                .UseInMemoryDatabase(Guid.NewGuid().ToString())
                .Options;

            return new SelfServiceDbContext(options);
        }

        [Fact]
        public void AddRouteItem_ShouldWork()
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
        }

        [Fact]
        public void GetRouteItem_ShouldWork()
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

            var routeItemFromDb = context.RouteItems.Find(routeItem.Id);

            Assert.NotNull(routeItemFromDb);
            Assert.Equal(routeItem.Route, routeItemFromDb.Route);
            Assert.Equal(routeItem.FilePath, routeItemFromDb.FilePath);
            Assert.Equal(routeItem.FileName, routeItemFromDb.FileName);
            // ... other properties
        }
        [Fact]
        public void UpdateRouteItem_ShouldWork()
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

            var routeItemFromDb = context.RouteItems.Find(routeItem.Id);

            Assert.NotNull(routeItemFromDb);
            Assert.Equal(routeItem.Route, routeItemFromDb.Route);
            Assert.Equal(routeItem.FilePath, routeItemFromDb.FilePath);
            Assert.Equal(routeItem.FileName, routeItemFromDb.FileName);
            // ... other properties

            routeItemFromDb.Route = "/test2";
            routeItemFromDb.FilePath = "/path/to/file2";
            routeItemFromDb.FileName = "test2.html";
            // ... other properties

            context.RouteItems.Update(routeItemFromDb);
            context.SaveChanges();

            var updatedRouteItemFromDb = context.RouteItems.Find(routeItem.Id);

            Assert.NotNull(updatedRouteItemFromDb);
            Assert.Equal(routeItemFromDb.Route, updatedRouteItemFromDb.Route);
            Assert.Equal(routeItemFromDb.FilePath, updatedRouteItemFromDb.FilePath);
            Assert.Equal(routeItemFromDb.FileName, updatedRouteItemFromDb.FileName);
            // ... other properties
        }
        [Fact]
        public void DeleteRouteItem_ShouldWork()
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

            var routeItemFromDb = context.RouteItems.Find(routeItem.Id);

            Assert.NotNull(routeItemFromDb);
            Assert.Equal(routeItem.Route, routeItemFromDb.Route);
            Assert.Equal(routeItem.FilePath, routeItemFromDb.FilePath);
            Assert.Equal(routeItem.FileName, routeItemFromDb.FileName);
            // ... other properties

            context.RouteItems.Remove(routeItemFromDb);
            context.SaveChanges();

            var deletedRouteItemFromDb = context.RouteItems.Find(routeItem.Id);

            Assert.Null(deletedRouteItemFromDb);
        }
        [Fact]
        public void AddRouteItemTag_ShouldWork()
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

            var routeItemTag = new RouteItemTag
            {
                RouteItemId = routeItem.Id,
                Tag = "test-tag"
            };

            context.RouteItemTags.Add(routeItemTag);
            context.SaveChanges();
        }
        [Fact]
        public void GetRouteItemTag_ShouldWork()
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

            var routeItemTag = new RouteItemTag
            {
                RouteItemId = routeItem.Id,
                Tag = "test-tag"
            };

            context.RouteItemTags.Add(routeItemTag);
            context.SaveChanges();

            var routeItemTagFromDb = context.RouteItemTags.Find(routeItemTag.Id);

            Assert.NotNull(routeItemTagFromDb);
            Assert.Equal(routeItemTag.RouteItemId, routeItemTagFromDb.RouteItemId);
            Assert.Equal(routeItemTag.Tag, routeItemTagFromDb.Tag);
        }
        [Fact]
        public void UpdateRouteItemTag_ShouldWork()
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

            var routeItemTag = new RouteItemTag
            {
                RouteItemId = routeItem.Id,
                Tag = "test-tag"
            };

            context.RouteItemTags.Add(routeItemTag);
            context.SaveChanges();

            var routeItemTagFromDb = context.RouteItemTags.Find(routeItemTag.Id);

            Assert.NotNull(routeItemTagFromDb);
            Assert.Equal(routeItemTag.RouteItemId, routeItemTagFromDb.RouteItemId);
            Assert.Equal(routeItemTag.Tag, routeItemTagFromDb.Tag);

            routeItemTagFromDb.Tag = "test-tag2";

            context.RouteItemTags.Update(routeItemTagFromDb);
            context.SaveChanges();

            var updatedRouteItemTagFromDb = context.RouteItemTags.Find(routeItemTag.Id);

            Assert.NotNull(updatedRouteItemTagFromDb);
            Assert.Equal(routeItemTagFromDb.RouteItemId, updatedRouteItemTagFromDb.RouteItemId);
            Assert.Equal(routeItemTagFromDb.Tag, updatedRouteItemTagFromDb.Tag);
        }
        [Fact]
        public void DeleteRouteItemTag_ShouldWork()
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

            var routeItemTag = new RouteItemTag
            {
                RouteItemId = routeItem.Id,
                Tag = "test-tag"
            };

            context.RouteItemTags.Add(routeItemTag);
            context.SaveChanges();

            var routeItemTagFromDb = context.RouteItemTags.Find(routeItemTag.Id);

            Assert.NotNull(routeItemTagFromDb);
            Assert.Equal(routeItemTag.RouteItemId, routeItemTagFromDb.RouteItemId);
            Assert.Equal(routeItemTag.Tag, routeItemTagFromDb.Tag);

            context.RouteItemTags.Remove(routeItemTagFromDb);
            context.SaveChanges();

            var deletedRouteItemTagFromDb = context.RouteItemTags.Find(routeItemTag.Id);

            Assert.Null(deletedRouteItemTagFromDb);
        }
        
    }
}
