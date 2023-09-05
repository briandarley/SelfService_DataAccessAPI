using MediatR;
using UNC.Services.Responses;
using UNC_SelfService_DataAccessAPI_Common.Criteria.UtilityDb;
using UNC_SelfService_DataAccessAPI_Common.Entities.UtilityDb;

namespace UNC_SelfService_DataAccessAPI_Services.UtilityDb;

    public class GetProcessesQuery : IRequest<ServiceResult<List<Process>>>
    {
        public ProcessCriteria Criteria {get;}
    
        public GetProcessesQuery(ProcessCriteria criteria)
        {
            Criteria = criteria;
        }
    }