using MediatR;
using Microsoft.Extensions.Logging;
using UNC.Services;
using UNC.Services.Responses;
using UNC_SelfService_DataAccessAPI_Common.Entities.UtilityDb;
using UNC_SelfService_DataAccessAPI_Repository;
using UNC_SelfService_DataAccessAPI_Services.Commands.UtilityDb;

namespace UNC_SelfService_DataAccessAPI_Services.Handlers.UtilityDb
{
    public class AddAppSettingHandler : ServiceBase<AddAppSettingHandler>, IRequestHandler<AddAppSettingCommand, ServiceResult<AppSetting>>
    {
        private readonly UtilityDbContext _dbContext;

        public AddAppSettingHandler(ILogger<AddAppSettingHandler> logger, UtilityDbContext dbContext) : base(logger)
        {
            _dbContext = dbContext;
        }

        public async Task<ServiceResult<AppSetting>> Handle(AddAppSettingCommand request, CancellationToken cancellationToken)
        {

            _dbContext.AppSettings.Add(request.Entity);

            await _dbContext.SaveChangesAsync(cancellationToken);

            return new ServiceResult<AppSetting>(request.Entity);

        }
    }
}
