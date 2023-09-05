using MediatR;
using UNC.Services.Responses;
using Microsoft.Extensions.Logging;
using UNC.Services;
using UNC_SelfService_DataAccessAPI_Common.Entities.UtilityDb;
using UNC_SelfService_DataAccessAPI_Repository;


namespace UNC_SelfService_DataAccessAPI_Services.UtilityDb;

    public class AddProcessHandler: ServiceBase<AddProcessHandler>, IRequestHandler<AddProcessCommand, ServiceResult<Process>>
    {
        private readonly UtilityDbContext _dbContext;
        public AddProcessHandler(ILogger<AddProcessHandler> logger, UtilityDbContext dbContext) : base(logger)
        {
            _dbContext = dbContext;
        }


         public async Task<ServiceResult<Process>> Handle(AddProcessCommand request, CancellationToken cancellationToken)
         {
            

            try
            {
                LogBeginRequest();

                _dbContext.Processes.Add(request.Entity);

                 await _dbContext.SaveChangesAsync(cancellationToken);

                 return new ServiceResult<Process>(request.Entity);

            }
            catch (Exception ex)
            {
                LogException(ex, false);
				
				    return new ServiceResult<Process>(null){
					     Errors = new List<string> { ex.Message }
				    };
            }
            finally
            {
                LogEndRequest();
            }
          }

    }