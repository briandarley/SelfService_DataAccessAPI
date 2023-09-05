using MediatR;
using UNC.Services.Responses;
using Microsoft.Extensions.Logging;
using UNC.Services;
using UNC_SelfService_DataAccessAPI_Common.Entities.UtilityDb;
using UNC_SelfService_DataAccessAPI_Repository;


namespace UNC_SelfService_DataAccessAPI_Services.UtilityDb;

    public class AddOrganizationalUnitAdminHandler: ServiceBase<AddOrganizationalUnitAdminHandler>, IRequestHandler<AddOrganizationalUnitAdminCommand, ServiceResult<OrganizationalUnitAdmin>>
    {
        private readonly UtilityDbContext _dbContext;
        public AddOrganizationalUnitAdminHandler(ILogger<AddOrganizationalUnitAdminHandler> logger, UtilityDbContext dbContext) : base(logger)
        {
            _dbContext = dbContext;
        }


         public async Task<ServiceResult<OrganizationalUnitAdmin>> Handle(AddOrganizationalUnitAdminCommand request, CancellationToken cancellationToken)
         {
            

            try
            {
                LogBeginRequest();

                _dbContext.OrganizationalUnitAdmins.Add(request.Entity);

                 await _dbContext.SaveChangesAsync(cancellationToken);

                 return new ServiceResult<OrganizationalUnitAdmin>(request.Entity);

            }
            catch (Exception ex)
            {
                LogException(ex, false);
				
				    return new ServiceResult<OrganizationalUnitAdmin>(null){
					     Errors = new List<string> { ex.Message }
				    };
            }
            finally
            {
                LogEndRequest();
            }
          }

    }