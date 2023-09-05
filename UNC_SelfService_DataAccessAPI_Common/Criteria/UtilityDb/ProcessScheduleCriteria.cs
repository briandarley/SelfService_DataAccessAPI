using UNC.Services.Criteria;
using UNC_SelfService_DataAccessAPI_Common.Entities.UtilityDb;

namespace UNC_SelfService_DataAccessAPI_Common.Criteria.UtilityDb
{
    public class ProcessScheduleCriteria: BaseCriteria<ProcessSchedule>
    {
        public int? Id { get; set; }
        public int? ProcessId { get; set; }
        public bool? Enabled { get; set; }
    }
}
