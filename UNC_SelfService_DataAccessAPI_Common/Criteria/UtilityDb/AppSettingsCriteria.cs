using UNC.Services.Criteria;
using UNC_SelfService_DataAccessAPI_Common.Entities.UtilityDb;

namespace UNC_SelfService_DataAccessAPI_Common.Criteria.UtilityDb
{
    public class AppSettingsCriteria:BaseCriteria<AppSetting>
    {
        public int? Id { get; set; }
        public string Name { get; set; }
        public string AppDomain { get; set; }
        public string Filter { get; set; }
    }
}
