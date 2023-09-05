using MediatR;
using UNC.Services.Responses;
using Microsoft.Extensions.Logging;
using UNC.Services;
using UNC_SelfService_DataAccessAPI_Repository;


namespace UNC_SelfService_DataAccessAPI_Services.UtilityDb;

public class UpdateApiEndpointHandler: ServiceBase<UpdateApiEndpointHandler>, IRequestHandler<UpdateApiEndpointCommand, ServiceResult<bool>>
    {
        private readonly UtilityDbContext _dbContext;
        public UpdateApiEndpointHandler(ILogger<UpdateApiEndpointHandler> logger, UtilityDbContext dbContext) : base(logger)
        {
            _dbContext = dbContext;
        }


         public async Task<ServiceResult<bool>> Handle(UpdateApiEndpointCommand request, CancellationToken cancellationToken)
         {
            
            try
            {
                LogBeginRequest();

                _dbContext.ApiEndpoints.Update(request.Entity);
                 
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