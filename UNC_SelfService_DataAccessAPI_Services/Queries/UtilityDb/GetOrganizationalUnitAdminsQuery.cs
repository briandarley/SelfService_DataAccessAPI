using MediatR;
using UNC.Services.Responses;
using UNC_SelfService_DataAccessAPI_Common.Criteria.UtilityDb;
using UNC_SelfService_DataAccessAPI_Common.Entities.UtilityDb;

namespace UNC_SelfService_DataAccessAPI_Services.UtilityDb;

    public class GetOrganizationalUnitAdminsQuery : IRequest<ServiceResult<List<OrganizationalUnitAdmin>>>
    {
        public OrganizationalUnitAdminCriteria Criteria { get; }
    
        public GetOrganizationalUnitAdminsQuery(OrganizationalUnitAdminCriteria criteria)
        {
            Criteria = criteria;
        }
    }