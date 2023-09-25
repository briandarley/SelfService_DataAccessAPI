using MediatR;
using UNC.Services.Responses;
using Microsoft.Extensions.Logging;
using UNC.Services;
using UNC_SelfService_DataAccessAPI_Common.Entities.SelfServiceDb;
using UNC_SelfService_DataAccessAPI_Repository;


namespace UNC_SelfService_DataAccessAPI_Services.SelfServiceDb;

public class AddRouteScheduleDowntimeHandler : ServiceBase<AddRouteScheduleDowntimeHandler>, IRequestHandler<AddRouteScheduleDowntimeCommand, ServiceResult<RouteScheduleDowntime>>
{
    private readonly SelfServiceDbContext _dbContext;
    public AddRouteScheduleDowntimeHandler(ILogger<AddRouteScheduleDowntimeHandler> logger, SelfServiceDbContext dbContext) : base(logger)
    {
        _dbContext = dbContext;
    }


    public async Task<ServiceResult<RouteScheduleDowntime>> Handle(AddRouteScheduleDowntimeCommand request, CancellationToken cancellationToken)
    {
        try
        {
            LogBeginRequest();

            _dbContext.RouteScheduleDowntimes.Add(request.Entity);

            await _dbContext.SaveChangesAsync(cancellationToken);

            return new ServiceResult<RouteScheduleDowntime>(request.Entity);

        }
        catch (Exception ex)
        {
            LogException(ex, false);

            return new ServiceResult<RouteScheduleDowntime>(null)
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