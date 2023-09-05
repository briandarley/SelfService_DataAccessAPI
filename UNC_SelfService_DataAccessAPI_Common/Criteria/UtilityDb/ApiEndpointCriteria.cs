using UNC.Services.Criteria;
using UNC_SelfService_DataAccessAPI_Common.Entities.UtilityDb;

namespace UNC_SelfService_DataAccessAPI_Common.Criteria.UtilityDb
{
    public class ApiEndpointCriteria:BaseCriteria<ApiEndpoint>
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Uri { get; set; }
        public string Environment { get; set; }
    }
}
