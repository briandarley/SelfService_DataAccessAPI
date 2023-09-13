using MediatR;
using UNC.Services.Responses;
using UNC_SelfService_DataAccessAPI_Common.Entities.SelfServiceDb;


namespace UNC_SelfService_DataAccessAPI_Services.SelfServiceDb;
public class UpdateMenuItemCommand : IRequest<ServiceResult<bool>>
{
    internal MenuItem Entity { get; }
    public UpdateMenuItemCommand(MenuItem entity)
    {
        Entity = entity;
    }
}