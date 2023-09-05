using MediatR;
using UNC.Services.Responses;
using Microsoft.Extensions.Logging;
using UNC.Services;
using UNC_SelfService_DataAccessAPI_Common.Entities.UtilityDb;
using UNC_SelfService_DataAccessAPI_Repository;


namespace UNC_SelfService_DataAccessAPI_Services.UtilityDb;

    public class AddApiEndpointHandler: ServiceBase<AddApiEndpointHandler>, IRequestHandler<AddApiEndpointCommand, ServiceResult<ApiEndpoint>>
    {
        private readonly UtilityDbContext _dbContext;
        public AddApiEndpointHandler(ILogger<AddApiEndpointHandler> logger, UtilityDbContext dbContext) : base(logger)
        {
            _dbContext = dbContext;
        }


         public async Task<ServiceResult<ApiEndpoint>> Handle(AddApiEndpointCommand request, CancellationToken cancellationToken)
         {
            

            try
            {
                LogBeginRequest();

                _dbContext.ApiEndpoints.Add(request.Entity);

                 await _dbContext.SaveChangesAsync(cancellationToken);

                 return new ServiceResult<ApiEndpoint>(request.Entity);

            }
            catch (Exception ex)
            {
                LogException(ex, false);
				
				    return new ServiceResult<ApiEndpoint>(null){
					     Errors = new List<string> { ex.Message }
				    };
            }
            finally
            {
                LogEndRequest();
            }
          }

    }