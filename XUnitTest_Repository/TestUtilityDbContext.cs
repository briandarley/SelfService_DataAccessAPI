using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UNC_SelfService_DataAccessAPI_Repository;

namespace XUnitTest_Repository
{
    
    internal class TestUtilityDbContext
    {
        public UtilityDbContext CreateInMemoryDbContext()
        {
            var options = new DbContextOptionsBuilder<UtilityDbContext>()
                .UseInMemoryDatabase(databaseName: Guid.NewGuid().ToString()) // Unique name to ensure a fresh database for each test
                .Options;

            var dbContext = new UtilityDbContext(options);

            return dbContext;
        }
        public TestUtilityDbContext()
        {
            
        }
    }
}
