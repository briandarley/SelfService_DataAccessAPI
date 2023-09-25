using MediatR;
using UNC.Services.Responses;
using UNC_SelfService_DataAccessAPI_Common.Entities.SelfServiceDb;


namespace UNC_SelfService_DataAccessAPI_Services.SelfServiceDb;
public class AddRouteScheduleDowntimeCommand : IRequest<ServiceResult<RouteScheduleDowntime>>
{
    internal RouteScheduleDowntime Entity { get; }
    public AddRouteScheduleDowntimeCommand(RouteScheduleDowntime entity)
    {
        Entity = entity;
    }
}