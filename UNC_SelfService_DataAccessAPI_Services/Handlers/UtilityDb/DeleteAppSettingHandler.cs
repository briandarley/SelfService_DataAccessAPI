using MediatR;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using UNC.Services;
using UNC.Services.Responses;
using UNC_SelfService_DataAccessAPI_Common.Entities.UtilityDb;
using UNC_SelfService_DataAccessAPI_Repository;
using UNC_SelfService_DataAccessAPI_Services.Commands.UtilityDb;

namespace UNC_SelfService_DataAccessAPI_Services.Handlers.UtilityDb
{
    public class DeleteAppSettingHandler : ServiceBase<DeleteAppSettingHandler>, IRequestHandler<DeleteAppSettingCommand, ServiceResult<bool>>
    {
        private UtilityDbContext _dbContext;

        public DeleteAppSettingHandler(ILogger<DeleteAppSettingHandler> logger, UtilityDbContext dbContext) : base(logger)
        {
            _dbContext = dbContext;
        }

        public async Task<ServiceResult<bool>> Handle(DeleteAppSettingCommand request, CancellationToken cancellationToken)
        {

            try
            {
                LogBeginRequest();

                _dbContext.AppSettings.Remove(await _dbContext.AppSettings.SingleAsync(c => c.Id == request.EntityId, cancellationToken));

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
