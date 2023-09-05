using MediatR;
using UNC.Services.Responses;
using UNC_SelfService_DataAccessAPI_Common.Entities.UtilityDb;


namespace UNC_SelfService_DataAccessAPI_Services.UtilityDb;
public class AddProcessCommand : IRequest<ServiceResult<Process>>
{
    internal Process Entity { get; }
    public AddProcessCommand(Process entity)
    {
        Entity = entity;
    }
}