using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using MediatR;
using UNC.Services.Responses;
using UNC.Services;
using UNC.Extensions.General;
using UNC_SelfService_DataAccessAPI_Common.Entities.SelfServiceDb;
using UNC_SelfService_DataAccessAPI_Repository;


namespace UNC_SelfService_DataAccessAPI_Services.SelfServiceDb;

public class GetRouteScheduleDowntimesHandler : ServiceBase<GetRouteScheduleDowntimesHandler>, IRequestHandler<GetRouteScheduleDowntimesQuery, ServiceResult<List<RouteScheduleDowntime>>>
{
    private readonly SelfServiceDbContext _dbContext;
    public GetRouteScheduleDowntimesHandler(ILogger<GetRouteScheduleDowntimesHandler> logger, SelfServiceDbContext dbContext) : base(logger)
    {
        _dbContext = dbContext;
    }


    public async Task<ServiceResult<List<RouteScheduleDowntime>>> Handle(GetRouteScheduleDowntimesQuery request, CancellationToken cancellationToken)
    {

        try
        {
            LogBeginRequest();

            var query = _dbContext.RouteScheduleDowntimes.AsNoTracking().AsQueryable();

            if (request.Criteria == null)
            {
                return new ServiceResult<List<RouteScheduleDowntime>>(await query.ToListAsync(cancellationToken));
            }

            if (request.Criteria.Id.HasValue)
            {
                query = query.Where(c => c.Id == request.Criteria.Id.Value);
            }

            if (request.Criteria.ScheduledOnDateFrom.HasValue)
            {
                query = query.Where(c => c.ScheduledOnDate >= request.Criteria.ScheduledOnDateFrom.Value);
            }
            if (request.Criteria.ScheduledOnDateThru.HasValue)
            {
                query = query.Where(c => c.ScheduledOnDate <= request.Criteria.ScheduledOnDateThru.Value);
            }
            if (!request.Criteria.Filter.IsEmpty())
            {
                query = query.Where(c => c.CurrentRoute.Contains(request.Criteria.Filter));
            }
            if (request.Criteria.Archived.HasValue)
            {
                query = query.Where(c => c.Archived == request.Criteria.Archived.Value);
            }


            return new ServiceResult<List<RouteScheduleDowntime>>(await query.ToListAsync(cancellationToken));

        }
        catch (Exception ex)
        {
            LogException(ex, false);

            return new ServiceResult<List<RouteScheduleDowntime>>(null)
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