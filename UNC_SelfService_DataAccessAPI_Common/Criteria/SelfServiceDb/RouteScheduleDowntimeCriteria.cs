using UNC.Services.Criteria;
using UNC_SelfService_DataAccessAPI_Common.Entities.SelfServiceDb;

namespace UNC_SelfService_DataAccessAPI_Common.Criteria.SelfServiceDb
{
    public class RouteScheduleDowntimeCriteria : BaseCriteria<RouteItem>
    {
        public int? Id { get; set; }
        public DateTimeOffset? ScheduledOnDateFrom { get; set; }
        public DateTimeOffset? ScheduledOnDateThru { get; set; }
        public bool? Archived { get; set; }

        public string Filter { get; set; }
    }
}
