using MediatR;
using UNC.Services.Responses;
using Microsoft.Extensions.Logging;
using UNC.Services;
using UNC_SelfService_DataAccessAPI_Common.Entities.UtilityDb;
using UNC_SelfService_DataAccessAPI_Repository;


namespace UNC_SelfService_DataAccessAPI_Services.UtilityDb;

    public class AddOrganizationalUnitHandler: ServiceBase<AddOrganizationalUnitHandler>, IRequestHandler<AddOrganizationalUnitCommand, ServiceResult<OrganizationalUnit>>
    {
        private readonly UtilityDbContext _dbContext;
        public AddOrganizationalUnitHandler(ILogger<AddOrganizationalUnitHandler> logger, UtilityDbContext dbContext) : base(logger)
        {
            _dbContext = dbContext;
        }


         public async Task<ServiceResult<OrganizationalUnit>> Handle(AddOrganizationalUnitCommand request, CancellationToken cancellationToken)
         {
            
            try
            {
                LogBeginRequest();

                _dbContext.OrganizationalUnits.Add(request.Entity);

                 await _dbContext.SaveChangesAsync(cancellationToken);

                 return new ServiceResult<OrganizationalUnit>(request.Entity);

            }
            catch (Exception ex)
            {
                LogException(ex, false);
				
				    return new ServiceResult<OrganizationalUnit>(null){
					     Errors = new List<string> { ex.Message }
				    };
            }
            finally
            {
                LogEndRequest();
            }
          }

    }