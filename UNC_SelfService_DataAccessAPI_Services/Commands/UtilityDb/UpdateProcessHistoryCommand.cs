using MediatR;
using UNC.Services.Responses;
using UNC_SelfService_DataAccessAPI_Common.Entities.UtilityDb;


namespace UNC_SelfService_DataAccessAPI_Services.UtilityDb;
public class UpdateProcessHistoryCommand : IRequest<ServiceResult<bool>>
{
    internal ProcessHistory Entity { get; }
    public UpdateProcessHistoryCommand(ProcessHistory entity)
    {
        Entity = entity;
    }
}