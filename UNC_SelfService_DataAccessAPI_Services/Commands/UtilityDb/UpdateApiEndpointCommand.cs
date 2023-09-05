using MediatR;
using UNC.Services.Responses;
using UNC_SelfService_DataAccessAPI_Common.Entities.UtilityDb;
namespace UNC_SelfService_DataAccessAPI_Services.UtilityDb;

public class UpdateApiEndpointCommand : IRequest<ServiceResult<bool>>
{
    internal ApiEndpoint Entity;

    public UpdateApiEndpointCommand(ApiEndpoint entity)
    {
        Entity = entity;
    }
}