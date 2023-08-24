using MediatR;
using UNC.Services.Responses;

namespace UNC_SelfService_DataAccessAPI_Services.Commands.UtilityDb
{
    public class DeleteAppSettingCommand : IRequest<ServiceResult<bool>>
    {

        public DeleteAppSettingCommand(int entityId)
        {
            EntityId = entityId;
        }

        public int EntityId { get; }
        
    }
}