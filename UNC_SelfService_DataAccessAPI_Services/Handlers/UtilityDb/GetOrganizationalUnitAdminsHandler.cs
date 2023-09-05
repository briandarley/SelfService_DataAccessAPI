using MediatR;
using UNC.Services.Responses;
using UNC.Services;
using Microsoft.Extensions.Logging;
using UNC_SelfService_DataAccessAPI_Common.Entities.UtilityDb;
using UNC_SelfService_DataAccessAPI_Repository;
using Microsoft.EntityFrameworkCore;
using UNC.Extensions.General;

namespace UNC_SelfService_DataAccessAPI_Services.UtilityDb;

public class GetOrganizationalUnitAdminsHandler : ServiceBase<GetOrganizationalUnitAdminsHandler>, IRequestHandler<GetOrganizationalUnitAdminsQuery, ServiceResult<List<OrganizationalUnitAdmin>>>
{
    private readonly UtilityDbContext _dbContext;
    public GetOrganizationalUnitAdminsHandler(ILogger<GetOrganizationalUnitAdminsHandler> logger, UtilityDbContext dbContext) : base(logger)
    {
        _dbContext = dbContext;
    }


    public async Task<ServiceResult<List<OrganizationalUnitAdmin>>> Handle(GetOrganizationalUnitAdminsQuery request, CancellationToken cancellationToken)
    {

        try
        {
            LogBeginRequest();

            var query = _dbContext.OrganizationalUnitAdmins.Include(c => c.OrganizationalUnit).AsNoTracking().AsQueryable();

            if (request.Criteria is null)
            {
                return new ServiceResult<List<OrganizationalUnitAdmin>>(await query.ToListAsync(cancellationToken));
            }

            if (request.Criteria.OuName.HasValue())
            {
                query = query.Where(c => c.OrganizationalUnit.Ou == request.Criteria.OuName);
            }
            if (request.Criteria.Id.HasValue)
            {
                query = query.Where(c => c.Id == request.Criteria.Id.Value);
            }

            if (request.Criteria.OrganizationalUnitId.HasValue)
            {
                query = query.Where(c => c.OrganizationalUnitId == request.Criteria.OrganizationalUnitId.Value);
            }

            if (!request.Criteria.SamAccountName.IsEmpty())
            {
                query = query.Where(c => c.SamAccountName == request.Criteria.SamAccountName);
            }


            return new ServiceResult<List<OrganizationalUnitAdmin>>(await query.ToListAsync(cancellationToken));

        }
        catch (Exception ex)
        {
            LogException(ex, false);

            return new ServiceResult<List<OrganizationalUnitAdmin>>(null)
            {
                Errors = new List<string> { ex.Message }
            };
        }
        finally
        {
            LogEndRequest();
        }

    }

}