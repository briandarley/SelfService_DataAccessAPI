using MediatR;
using UNC.Services.Responses;
using UNC_SelfService_DataAccessAPI_Common.Entities.UtilityDb;


namespace UNC_SelfService_DataAccessAPI_Services.UtilityDb;
public class AddProcessHistoryCommand : IRequest<ServiceResult<ProcessHistory>>
{
    internal ProcessHistory Entity { get; }
    public AddProcessHistoryCommand(ProcessHistory entity)
    {
        Entity = entity;
    }
}