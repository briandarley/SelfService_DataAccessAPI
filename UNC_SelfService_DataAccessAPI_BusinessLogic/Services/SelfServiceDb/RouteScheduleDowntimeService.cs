using Microsoft.Extensions.Logging;
using UNC.Services;
using UNC.Services.Responses;
using UNC_SelfService_DataAccessAPI_BusinessLogic.Interfaces.Services.SelfServiceDb;
using UNC_SelfService_DataAccessAPI_Common.Criteria.SelfServiceDb;
using UNC_SelfService_DataAccessAPI_Common.Entities.SelfServiceDb;

namespace UNC_SelfService_DataAccessAPI_BusinessLogic.Services.SelfServiceDb;

public class RouteScheduleDowntimeService : ServiceBase<RouteScheduleDowntimeService>, IRouteScheduleDowntimeService
{
    private readonly UNC_SelfService_DataAccessAPI_Services.Interfaces.Services.SelfServiceDb.IRouteScheduleDowntimeService _service;

    public RouteScheduleDowntimeService(ILogger<RouteScheduleDowntimeService> logger, UNC_SelfService_DataAccessAPI_Services.Interfaces.Services.SelfServiceDb.IRouteScheduleDowntimeService service) : base(logger)
    {
        _service = service;
    }

    public Task<ServiceResult<List<RouteScheduleDowntime>>> GetRouteScheduleDowntimes(RouteScheduleDowntimeCriteria criteria, CancellationToken cancellationToken)
    {
        return _service.GetRouteScheduleDowntimes(criteria, cancellationToken);
    }
    public Task<ServiceResult<RouteScheduleDowntime>> AddRouteScheduleDowntime(RouteScheduleDowntime entity, CancellationToken cancellationToken)
    {
        var validationErrors = ValidateModel(entity, out var isValid);

        if (!isValid)
        {
            return Task.FromResult(new ServiceResult<RouteScheduleDowntime>(null) { Errors = validationErrors.Select(c => c.ErrorMessage).ToList() });
        }

        return _service.AddRouteScheduleDowntime(entity, cancellationToken);
    }
    public async Task<ServiceResult<bool>> UpdateRouteScheduleDowntime(RouteScheduleDowntime entity, CancellationToken cancellationToken)
    {
        var validationErrors = ValidateModel(entity, out var isValid);

        if (!isValid)
        {
            return new ServiceResult<bool>(false) { Errors = validationErrors.Select(c => c.ErrorMessage).ToList() };
        }

        var request = await _service.GetRouteScheduleDowntimes(new RouteScheduleDowntimeCriteria { Id = entity.Id }, cancellationToken);
        if (request.Success)
        {
            var routeScheduleDowntime = request.Data.FirstOrDefault();
            if (routeScheduleDowntime != null)
            {
                return await _service.UpdateRouteScheduleDowntime(entity, cancellationToken);
            }
            else
            {
                return new ServiceResult<bool>(false, "ResourceNotFound");
            }
        }
        return new ServiceResult<bool>(false) { Errors = request.Errors };
    }
    public async Task<ServiceResult<bool>> DeleteRouteScheduleDowntime(int entityId, CancellationToken cancellationToken)
    {

        var request = await _service.GetRouteScheduleDowntimes(new RouteScheduleDowntimeCriteria { Id = entityId }, cancellationToken);
        if (request.Success)
        {
            var appSetting = request.Data.FirstOrDefault();
            if (appSetting != null)
            {
                return await _service.DeleteRouteScheduleDowntime(entityId, cancellationToken);
            }
            else
            {
                return new ServiceResult<bool>(false, "ResourceNotFound");
            }
        }

        return new ServiceResult<bool>(false) { Errors = request.Errors };
    }
}


