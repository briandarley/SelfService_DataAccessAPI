using MediatR;
using UNC.Services.Responses;
using UNC_SelfService_DataAccessAPI_Common.Criteria.UtilityDb;
using UNC_SelfService_DataAccessAPI_Common.Entities.UtilityDb;

namespace UNC_SelfService_DataAccessAPI_Services.UtilityDb;

    public class GetProcessHistoriesQuery : IRequest<ServiceResult<PagedResponse<ProcessHistory>>>
    {
        public ProcessHistoryCriteria Criteria {get;}
    
        public GetProcessHistoriesQuery(ProcessHistoryCriteria criteria)
        {
            Criteria = criteria;
        }
    }