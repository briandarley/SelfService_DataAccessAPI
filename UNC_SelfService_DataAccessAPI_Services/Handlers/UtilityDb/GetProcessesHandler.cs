using MediatR;
using UNC.Services.Responses;
using UNC.Services;
using Microsoft.Extensions.Logging;
using UNC_SelfService_DataAccessAPI_Common.Entities.UtilityDb;
using UNC_SelfService_DataAccessAPI_Repository;
using Microsoft.EntityFrameworkCore;
using UNC.Extensions.General;

namespace UNC_SelfService_DataAccessAPI_Services.UtilityDb;

public class GetProcessesHandler : ServiceBase<GetProcessesHandler>, IRequestHandler<GetProcessesQuery, ServiceResult<List<Process>>>
{
    private readonly UtilityDbContext _dbContext;
    public GetProcessesHandler(ILogger<GetProcessesHandler> logger, UtilityDbContext dbContext) : base(logger)
    {
        _dbContext = dbContext;
    }


    public async Task<ServiceResult<List<Process>>> Handle(GetProcessesQuery request, CancellationToken cancellationToken)
    {

        try
        {
            LogBeginRequest();

            var query = _dbContext.Processes.Include(c => c.ProcessSchedules).AsNoTracking().AsQueryable();

            if (request.Criteria is null)
            {
                return new ServiceResult<List<Process>>(await query.ToListAsync(cancellationToken));
            }


            if (request.Criteria.Id.HasValue)
            {
                query = query.Where(c => c.Id == request.Criteria.Id.Value);
            }

            if (request.Criteria.Name.HasValue())
            {
                query = query.Where(c => c.Name == request.Criteria.Name);
            }

            if (request.Criteria.ProcessType.HasValue())
            {
                query = query.Where(c => c.ProcessType == request.Criteria.ProcessType);
            }
            if (request.Criteria.AppDomain.HasValue())
            {
                query = query.Where(c => c.AppDomain == request.Criteria.AppDomain);
            }

            if (request.Criteria.Enabled.HasValue)
            {
                query = query.Where(c => c.Enabled == request.Criteria.Enabled);
            }


            return new ServiceResult<List<Process>>(await query.ToListAsync(cancellationToken));

        }
        catch (Exception ex)
        {
            LogException(ex, false);

            return new ServiceResult<List<Process>>(null)
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