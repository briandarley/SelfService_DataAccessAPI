using MediatR;
using UNC.Services.Responses;


namespace UNC_SelfService_DataAccessAPI_Services.SelfServiceDb;
public class DeleteRouteScheduleDowntimeCommand : IRequest<ServiceResult<bool>>
{
    internal int EntityId { get; }
    public DeleteRouteScheduleDowntimeCommand(int entityId)
    {
        EntityId = entityId;
    }
}