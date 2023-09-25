using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UNC_SelfService_DataAccessAPI_Common.Entities.UtilityDb;
using UNC_SelfService_DataAccessAPI_Repository;

namespace XUnitTest_Repository.UtilityDb
{
    public class OrganizationalUnitAdminTests
    {
        private readonly ILogger<OrganizationalUnitAdminTests> _logger;

        public OrganizationalUnitAdminTests()
        {
            _logger = TestLoggerFactory.CreateLogger<OrganizationalUnitAdminTests>();
        }

        public UtilityDbContext CreateInMemoryDbContext()
        {
            var options = new DbContextOptionsBuilder<UtilityDbContext>()
                .UseInMemoryDatabase(Guid.NewGuid().ToString())
                .Options;

            return new UtilityDbContext(options);
        }

        [Fact]
        public void AddOrganizationalUnitAdmin_ShouldWork()
        {
            using var context = CreateInMemoryDbContext();

            var orgUnitAdmin = new OrganizationalUnitAdmin
            {
                SamAccountName = "TestAdmin",
                Name = "Test Admin",
                // ... other properties
            };

            context.OrganizationalUnitAdmins.Add(orgUnitAdmin);
            context.SaveChanges();

            var savedOrgUnitAdmin = context.OrganizationalUnitAdmins.FirstOrDefault();

            Assert.NotNull(savedOrgUnitAdmin);
            Assert.Equal("TestAdmin", savedOrgUnitAdmin.SamAccountName);
            // ... other assertions
        }

        [Fact]
        public void UpdateOrganizationalUnitAdmin_ShouldWork()
        {
            using var context = CreateInMemoryDbContext();

            var orgUnitAdmin = new OrganizationalUnitAdmin
            {
                SamAccountName = "InitialAdmin",
                // ... other initial values
            };

            context.OrganizationalUnitAdmins.Add(orgUnitAdmin);
            context.SaveChanges();

            orgUnitAdmin.SamAccountName = "UpdatedAdmin";
            context.OrganizationalUnitAdmins.Update(orgUnitAdmin);
            context.SaveChanges();

            var updatedOrgUnitAdmin = context.OrganizationalUnitAdmins.FirstOrDefault();
            Assert.NotNull(updatedOrgUnitAdmin);
            Assert.Equal("UpdatedAdmin", updatedOrgUnitAdmin.SamAccountName);
            // ... other assertions
        }

        [Fact]
        public void RemoveOrganizationalUnitAdmin_ShouldWork()
        {
            using var context = CreateInMemoryDbContext();

            var orgUnitAdmin = new OrganizationalUnitAdmin
            {
                SamAccountName = "TestAdmin",
                // ... other values
            };

            context.OrganizationalUnitAdmins.Add(orgUnitAdmin);
            context.SaveChanges();

            context.OrganizationalUnitAdmins.Remove(orgUnitAdmin);
            context.SaveChanges();

            var savedOrgUnitAdmin = context.OrganizationalUnitAdmins.FirstOrDefault();
            Assert.Null(savedOrgUnitAdmin);
        }
    }
}
