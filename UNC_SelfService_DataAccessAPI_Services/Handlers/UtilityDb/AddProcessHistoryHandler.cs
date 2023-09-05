using MediatR;
using UNC.Services.Responses;
using Microsoft.Extensions.Logging;
using UNC.Services;
using UNC_SelfService_DataAccessAPI_Common.Entities.UtilityDb;
using UNC_SelfService_DataAccessAPI_Repository;


namespace UNC_SelfService_DataAccessAPI_Services.UtilityDb;

public class AddProcessHistoryHandler: ServiceBase<AddProcessHistoryHandler>, IRequestHandler<AddProcessHistoryCommand, ServiceResult<ProcessHistory>>
    {
        private readonly UtilityDbContext _dbContext;
        public AddProcessHistoryHandler(ILogger<AddProcessHistoryHandler> logger, UtilityDbContext dbContext) : base(logger)
        {
            _dbContext = dbContext;
        }


         public async Task<ServiceResult<ProcessHistory>> Handle(AddProcessHistoryCommand request, CancellationToken cancellationToken)
         {
            

            try
            {
                LogBeginRequest();

                _dbContext.ProcessHistories.Add(request.Entity);

                 await _dbContext.SaveChangesAsync(cancellationToken);

                 return new ServiceResult<ProcessHistory>(request.Entity);

            }
            catch (Exception ex)
            {
                LogException(ex, false);
				
				    return new ServiceResult<ProcessHistory>(null){
					     Errors = new List<string> { ex.Message }
				    };
            }
            finally
            {
                LogEndRequest();
            }
          }

    }