using MediatR;
using UNC_SelfService_DataAccessAPI_Common.Criteria.UtilityDb;
using UNC_SelfService_DataAccessAPI_Common.Entities.UtilityDb;

namespace UNC_SelfService_DataAccessAPI_Services.Queries.UtilityDb
{
    public class GetAppSettingsQuery : IRequest<List<AppSetting>>
    {

        public GetAppSettingsQuery(AppSettingsCriteria criteria)
        {
            Criteria = criteria;
        }

        public AppSettingsCriteria Criteria { get; }
    }
}