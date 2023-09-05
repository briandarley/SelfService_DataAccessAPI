using MediatR;
using UNC.Services.Responses;
using UNC_SelfService_DataAccessAPI_Common.Entities.UtilityDb;


namespace UNC_SelfService_DataAccessAPI_Services.UtilityDb;
public class UpdateProcessCommand : IRequest<ServiceResult<bool>>
{
    internal Process Entity { get; }

    public UpdateProcessCommand(Process entity)
    {
        Entity = entity;
    }
}
