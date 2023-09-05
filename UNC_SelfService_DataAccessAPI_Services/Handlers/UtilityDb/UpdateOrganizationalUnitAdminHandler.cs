using MediatR;
using UNC.Services.Responses;
using Microsoft.Extensions.Logging;
using UNC.Services;
using UNC_SelfService_DataAccessAPI_Repository;


namespace UNC_SelfService_DataAccessAPI_Services.UtilityDb;

public class UpdateOrganizationalUnitAdminHandler: ServiceBase<UpdateOrganizationalUnitAdminHandler>, IRequestHandler<UpdateOrganizationalUnitAdminCommand, ServiceResult<bool>>
    {
        private readonly UtilityDbContext _dbContext;
        public UpdateOrganizationalUnitAdminHandler(ILogger<UpdateOrganizationalUnitAdminHandler> logger, UtilityDbContext dbContext) : base(logger)
        {
            _dbContext = dbContext;
        }


         public async Task<ServiceResult<bool>> Handle(UpdateOrganizationalUnitAdminCommand request, CancellationToken cancellationToken)
         {
            try
            {
                LogBeginRequest();

                _dbContext.OrganizationalUnitAdmins.Update(request.Entity);
                 
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