using MediatR;
using UNC.Services.Responses;
using UNC_SelfService_DataAccessAPI_Common.Criteria.UtilityDb;
using UNC_SelfService_DataAccessAPI_Common.Entities.UtilityDb;

namespace UNC_SelfService_DataAccessAPI_Services.UtilityDb;

    public class GetOrganizationalUnitsQuery : IRequest<ServiceResult<PagedResponse<OrganizationalUnit>>>
    {
        public OrganizationalUnitCriteria Criteria { get; }
    
        public GetOrganizationalUnitsQuery(OrganizationalUnitCriteria criteria)
        {
            Criteria = criteria;
        }
    }