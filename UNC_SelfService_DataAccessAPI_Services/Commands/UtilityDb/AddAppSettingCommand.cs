using MediatR;
using UNC.Services.Responses;
using UNC_SelfService_DataAccessAPI_Common.Entities.UtilityDb;

namespace UNC_SelfService_DataAccessAPI_Services.Commands.UtilityDb
{
    public class AddAppSettingCommand : IRequest<ServiceResult<AppSetting>>
    {

        public AddAppSettingCommand(AppSetting entity)
        {
            Entity = entity;
        }

        public AppSetting Entity { get; }
    }
}