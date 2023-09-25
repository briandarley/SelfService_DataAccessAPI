using MediatR;
using UNC.Services.Responses;
using UNC_SelfService_DataAccessAPI_Common.Entities.SelfServiceDb;


namespace UNC_SelfService_DataAccessAPI_Services.SelfServiceDb;
public class UpdateRouteScheduleDowntimeCommand : IRequest<ServiceResult<bool>>
{
    internal RouteScheduleDowntime Entity { get; }
    public UpdateRouteScheduleDowntimeCommand(RouteScheduleDowntime entity)
    {
        Entity = entity;
    }
}