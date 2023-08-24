using MediatR;
using UNC.Services.Responses;
using UNC_SelfService_DataAccessAPI_Common.Entities.UtilityDb;

namespace UNC_SelfService_DataAccessAPI_Services.Commands.UtilityDb
{
    public class UpdateAppSettingCommand : IRequest<ServiceResult<bool>>
    {

        public UpdateAppSettingCommand(AppSetting entity)
        {
            Entity = entity;
        }

        public AppSetting Entity { get; }
    }
}