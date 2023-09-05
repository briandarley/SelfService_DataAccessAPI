using MediatR;
using UNC.Services.Responses;
using UNC.Services;
using Microsoft.Extensions.Logging;
using UNC_SelfService_DataAccessAPI_Common.Entities.UtilityDb;
using UNC_SelfService_DataAccessAPI_Repository;
using Microsoft.EntityFrameworkCore;
using UNC.Extensions.General;

namespace UNC_SelfService_DataAccessAPI_Services.UtilityDb;

public class GetApiEndpointsHandler : ServiceBase<GetApiEndpointsHandler>, IRequestHandler<GetApiEndpointsQuery, ServiceResult<List<ApiEndpoint>>>
{
    private readonly UtilityDbContext _dbContext;
    public GetApiEndpointsHandler(ILogger<GetApiEndpointsHandler> logger, UtilityDbContext dbContext) : base(logger)
    {
        _dbContext = dbContext;
    }


    public async Task<ServiceResult<List<ApiEndpoint>>> Handle(GetApiEndpointsQuery request, CancellationToken cancellationToken)
    {

        try
        {
            LogBeginRequest();

            var query = _dbContext.ApiEndpoints.AsNoTracking().AsQueryable();

            if (request.Criteria != null)
            {
                if (request.Criteria.Id > 0)
                {
                    query = query.Where(a => a.Id == request.Criteria.Id);
                }

                if (request.Criteria.Name.HasValue())
                {
                    query = query.Where(a => a.Name.Contains(request.Criteria.Name));
                }

                if (request.Criteria.Uri.HasValue())
                {
                    query = query.Where(a => a.Uri.Contains(request.Criteria.Uri));
                }

                if (request.Criteria.Environment.HasValue())
                {
                    query = query.Where(a => a.Environment == request.Criteria.Environment);
                }
            }

            return new ServiceResult<List<ApiEndpoint>>(await query.ToListAsync(cancellationToken));
        }
        catch (Exception ex)
        {
            LogException(ex, false);

            return new ServiceResult<List<ApiEndpoint>>(null)
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