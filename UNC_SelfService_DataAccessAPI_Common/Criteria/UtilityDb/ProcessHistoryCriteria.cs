using UNC.Services.Criteria;
using UNC_SelfService_DataAccessAPI_Common.Entities.UtilityDb;

namespace UNC_SelfService_DataAccessAPI_Common.Criteria.UtilityDb
{
    public class ProcessHistoryCriteria : BasePagingCriteria<ProcessHistory>
    {
        public int? Id { get; set; }
        public DateTime? StartDateFrom { get; set; }
        public DateTime? StartDateThru { get; set; }
        public string Source { get; set; }
        public string MachineName { get; set; }
        public bool? Failed { get; set; }
    }
}
