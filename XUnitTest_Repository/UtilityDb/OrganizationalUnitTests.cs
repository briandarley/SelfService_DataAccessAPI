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
    public class OrganizationalUnitTests
    {
        private readonly ILogger<OrganizationalUnitTests> _logger;

        public OrganizationalUnitTests()
        {
            _logger = TestLoggerFactory.CreateLogger<OrganizationalUnitTests>();
        }

        public UtilityDbContext CreateInMemoryDbContext()
        {
            var options = new DbContextOptionsBuilder<UtilityDbContext>()
                .UseInMemoryDatabase(Guid.NewGuid().ToString())
                .Options;

            return new UtilityDbContext(options);
        }

        [Fact]
        public void AddOrganizationalUnit_ShouldWork()
        {
            using var context = CreateInMemoryDbContext();

            var orgUnit = new OrganizationalUnit
            {
                Name = "TestOU",
                DistinguishedName = "DN=TestOU,DC=example,DC=com",
                // ... other properties
            };

            context.OrganizationalUnits.Add(orgUnit);
            context.SaveChanges();

            var savedOrgUnit = context.OrganizationalUnits.FirstOrDefault();

            Assert.NotNull(savedOrgUnit);
            Assert.Equal("TestOU", savedOrgUnit.Name);
            // ... other assertions
        }

        [Fact]
        public void UpdateOrganizationalUnit_ShouldWork()
        {
            using var context = CreateInMemoryDbContext();

            var orgUnit = new OrganizationalUnit
            {
                Name = "InitialOU",
                // ... other initial values
            };

            context.OrganizationalUnits.Add(orgUnit);
            context.SaveChanges();

            orgUnit.Name = "UpdatedOU";
            context.OrganizationalUnits.Update(orgUnit);
            context.SaveChanges();

            var updatedOrgUnit = context.OrganizationalUnits.FirstOrDefault();
            Assert.NotNull(updatedOrgUnit);
            Assert.Equal("UpdatedOU", updatedOrgUnit.Name);
            // ... other assertions
        }

        [Fact]
        public void RemoveOrganizationalUnit_ShouldWork()
        {
            using var context = CreateInMemoryDbContext();

            var orgUnit = new OrganizationalUnit
            {
                Name = "TestOU",
                // ... other values
            };

            context.OrganizationalUnits.Add(orgUnit);
            context.SaveChanges();

            context.OrganizationalUnits.Remove(orgUnit);
            context.SaveChanges();

            var savedOrgUnit = context.OrganizationalUnits.FirstOrDefault();
            Assert.Null(savedOrgUnit);
        }
    }

    

}
