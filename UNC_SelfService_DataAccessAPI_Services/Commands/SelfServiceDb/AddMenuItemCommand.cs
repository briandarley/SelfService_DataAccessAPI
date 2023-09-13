using MediatR;
using UNC.Services.Responses;
using UNC_SelfService_DataAccessAPI_Common.Entities.SelfServiceDb;


namespace UNC_SelfService_DataAccessAPI_Services.SelfServiceDb;
public class AddMenuItemCommand : IRequest<ServiceResult<MenuItem>>
{
    internal MenuItem Entity { get; }
    public AddMenuItemCommand(MenuItem entity)
    {
        Entity = entity;
    }
}