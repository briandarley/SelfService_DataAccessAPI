using MediatR;
using Microsoft.Extensions.Logging;
using UNC.Services;
using UNC.Services.Responses;
using UNC_SelfService_DataAccessAPI_Repository;
using UNC_SelfService_DataAccessAPI_Services.Commands.UtilityDb;

namespace UNC_SelfService_DataAccessAPI_Services.Handlers.UtilityDb
{
    public class UpdateAppSettingHandler : ServiceBase<UpdateAppSettingHandler>, IRequestHandler<UpdateAppSettingCommand, ServiceResult<bool>>
    {
        private UtilityDbContext _dbContext;

        public UpdateAppSettingHandler(ILogger<UpdateAppSettingHandler> logger, UtilityDbContext dbContext) : base(logger)
        {
            _dbContext = dbContext;
        }

        public async Task<ServiceResult<bool>> Handle(UpdateAppSettingCommand request, CancellationToken cancellationToken)
        {

            try
            {
                LogBeginRequest();

                _dbContext.AppSettings.Update(request.Entity);

                await _dbContext.SaveChangesAsync(cancellationToken);

                return new ServiceResult<bool>(true);

            }
            catch (Exception ex)
            {
                LogException(ex, false);

                return new ServiceResult<bool>(false)
                {
                    Errors = new List<string> { ex.Message }
                };
            }
            finally
            {
                LogEndRequest();
            }

        }
    }
}
