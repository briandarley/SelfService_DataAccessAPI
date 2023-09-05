using MediatR;
using UNC.Services.Responses;
using UNC_SelfService_DataAccessAPI_Common.Entities.UtilityDb;

namespace UNC_SelfService_DataAccessAPI_Services.UtilityDb;

public class AddApiEndpointCommand : IRequest<ServiceResult<ApiEndpoint>>
{
    internal ApiEndpoint Entity;

    public AddApiEndpointCommand(ApiEndpoint entity)
    {
        Entity = entity;
    }
}