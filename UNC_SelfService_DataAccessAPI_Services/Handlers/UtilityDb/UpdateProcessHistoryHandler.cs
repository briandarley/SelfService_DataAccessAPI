using MediatR;
using UNC.Services.Responses;
using Microsoft.Extensions.Logging;
using UNC.Services;
using UNC_SelfService_DataAccessAPI_Repository;


namespace UNC_SelfService_DataAccessAPI_Services.UtilityDb;

public class UpdateProcessHistoryHandler: ServiceBase<UpdateProcessHistoryHandler>, IRequestHandler<UpdateProcessHistoryCommand, ServiceResult<bool>>
    {
        private readonly UtilityDbContext _dbContext;
        public UpdateProcessHistoryHandler(ILogger<UpdateProcessHistoryHandler> logger, UtilityDbContext dbContext) : base(logger)
        {
            _dbContext = dbContext;
        }


         public async Task<ServiceResult<bool>> Handle(UpdateProcessHistoryCommand request, CancellationToken cancellationToken)
         {
            try
            {
                LogBeginRequest();

                _dbContext.ProcessHistories.Update(request.Entity);
                 
                 await _dbContext.SaveChangesAsync(cancellationToken);

                 return new ServiceResult<bool>(true);

            }
            catch (Exception ex)
            {
                LogException(ex, false);
				
				return new ServiceResult<bool>(false){
					 Errors = new List<string> { ex.Message }
				};
            }
            finally
            {
                LogEndRequest();
            }
          }

    }