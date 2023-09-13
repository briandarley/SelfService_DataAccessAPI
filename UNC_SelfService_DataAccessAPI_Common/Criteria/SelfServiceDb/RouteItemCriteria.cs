using UNC.Services.Criteria;
using UNC_SelfService_DataAccessAPI_Common.Entities.SelfServiceDb;

namespace UNC_SelfService_DataAccessAPI_Common.Criteria.SelfServiceDb
{
    public class RouteItemCriteria:BaseCriteria<RouteItem>
    {
        public int? Id { get; set; }
        public string Route { get; set; }
        public string LinkText { get; set; }
        public bool? RequireAuth { get; set; }
        public bool? RequireMfa { get; set; }
        public bool? Searchable { get; set; }
        public string Filter { get; set; }

        
    }
}
