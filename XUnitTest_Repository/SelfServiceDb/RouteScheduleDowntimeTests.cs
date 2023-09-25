using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using UNC_SelfService_DataAccessAPI_Common.Entities.SelfServiceDb;
using UNC_SelfService_DataAccessAPI_Repository;

namespace XUnitTest_Repository.SelfServiceDb
{
    
    public class RouteScheduleDowntimeTests
    {
        private readonly ILogger<RouteScheduleDowntimeTests> _logger;

        public RouteScheduleDowntimeTests()
        {
            _logger = TestLoggerFactory.CreateLogger<RouteScheduleDowntimeTests>();
        }

        public SelfServiceDbContext CreateInMemoryDbContext()
        {
            var options = new DbContextOptionsBuilder<SelfServiceDbContext>()
                .UseInMemoryDatabase(Guid.NewGuid().ToString())
                .Options;

            return new SelfServiceDbContext(options);
        }

        [Fact]
        public void AddRouteScheduleDowntime_ShouldWork()
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

            var routeScheduleDowntime = new RouteScheduleDowntime
            {
                RouteItemId = routeItem.Id,
                ScheduledOnDate = DateTimeOffset.Now,
                ScheduledOffDate = DateTimeOffset.Now.AddHours(1),
                NewRoute = "/test2",
                CurrentRoute = "/test",
                Archived = false,
                // ... other properties
            };

            context.RouteScheduleDowntimes.Add(routeScheduleDowntime);
            context.SaveChanges();

            var savedRouteScheduleDowntime = context.RouteScheduleDowntimes.Include(r => r.RouteItem).FirstOrDefault();

            Assert.NotNull(savedRouteScheduleDowntime);
            Assert.Equal("/test", savedRouteScheduleDowntime.RouteItem.Route);
            Assert.Equal("/test2", savedRouteScheduleDowntime.NewRoute);
        }
        [Fact]
        public void UpdateRouteScheduleDowntime_ShouldWork()
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

            var routeScheduleDowntime = new RouteScheduleDowntime
            {
                RouteItemId = routeItem.Id,
                ScheduledOnDate = DateTimeOffset.Now,
                ScheduledOffDate = DateTimeOffset.Now.AddHours(1),
                NewRoute = "/test2",
                CurrentRoute = "/test",
                Archived = false,
                // ... other properties
            };

            context.RouteScheduleDowntimes.Add(routeScheduleDowntime);
            context.SaveChanges();

            var savedRouteScheduleDowntime = context.RouteScheduleDowntimes.Include(r => r.RouteItem).FirstOrDefault();

            Assert.NotNull(savedRouteScheduleDowntime);
            Assert.Equal("/test", savedRouteScheduleDowntime.RouteItem.Route);
            Assert.Equal("/test2", savedRouteScheduleDowntime.NewRoute);

            savedRouteScheduleDowntime.NewRoute = "/test3";
            context.RouteScheduleDowntimes.Update(savedRouteScheduleDowntime);
            context.SaveChanges();

            var updatedRouteScheduleDowntime = context.RouteScheduleDowntimes.Include(r => r.RouteItem).FirstOrDefault();

            Assert.NotNull(updatedRouteScheduleDowntime);
            Assert.Equal("/test", updatedRouteScheduleDowntime.RouteItem.Route);
            Assert.Equal("/test3", updatedRouteScheduleDowntime.NewRoute);
        }
        [Fact]
        public void DeleteRouteScheduleDowntime_ShouldWork()
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

            var routeScheduleDowntime = new RouteScheduleDowntime
            {
                RouteItemId = routeItem.Id,
                ScheduledOnDate = DateTimeOffset.Now,
                ScheduledOffDate = DateTimeOffset.Now.AddHours(1),
                NewRoute = "/test2",
                CurrentRoute = "/test",
                Archived = false,
                // ... other properties
            };

            context.RouteScheduleDowntimes.Add(routeScheduleDowntime);
            context.SaveChanges();

            var savedRouteScheduleDowntime = context.RouteScheduleDowntimes.Include(r => r.RouteItem).FirstOrDefault();

            Assert.NotNull(savedRouteScheduleDowntime);
            Assert.Equal("/test", savedRouteScheduleDowntime.RouteItem.Route);
            Assert.Equal("/test2", savedRouteScheduleDowntime.NewRoute);

            context.RouteScheduleDowntimes.Remove(savedRouteScheduleDowntime);
            context.SaveChanges();

            var deletedRouteScheduleDowntime = context.RouteScheduleDowntimes.Include(r => r.RouteItem).FirstOrDefault();

            Assert.Null(deletedRouteScheduleDowntime);
        }
        [Fact]
        public void GetRouteScheduleDowntime_ShouldWork()
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

            var routeScheduleDowntime = new RouteScheduleDowntime
            {
                RouteItemId = routeItem.Id,
                ScheduledOnDate = DateTimeOffset.Now,
                ScheduledOffDate = DateTimeOffset.Now.AddHours(1),
                NewRoute = "/test2",
                CurrentRoute = "/test",
                Archived = false,
                // ... other properties
            };

            context.RouteScheduleDowntimes.Add(routeScheduleDowntime);
            context.SaveChanges();

            var savedRouteScheduleDowntime = context.RouteScheduleDowntimes.Include(r => r.RouteItem).FirstOrDefault();

            Assert.NotNull(savedRouteScheduleDowntime);
            Assert.Equal("/test", savedRouteScheduleDowntime.RouteItem.Route);
            Assert.Equal("/test2", savedRouteScheduleDowntime.NewRoute);

            var routeScheduleDowntimeFromDb = context.RouteScheduleDowntimes.Include(r => r.RouteItem).FirstOrDefault();

            Assert.NotNull(routeScheduleDowntimeFromDb);
            Assert.Equal("/test", routeScheduleDowntimeFromDb.RouteItem.Route);
            Assert.Equal("/test2", routeScheduleDowntimeFromDb.NewRoute);
        }
    }
}
