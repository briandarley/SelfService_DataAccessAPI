using MediatR;
using UNC.Services.Responses;
using Microsoft.Extensions.Logging;
using UNC.Services;
using UNC_SelfService_DataAccessAPI_Common.Entities.SelfServiceDb;
using UNC_SelfService_DataAccessAPI_Repository;


namespace UNC_SelfService_DataAccessAPI_Services.SelfServiceDb;

public class AddRouteItemHandler : ServiceBase<AddRouteItemHandler>, IRequestHandler<AddRouteItemCommand, ServiceResult<RouteItem>>
{
    private readonly SelfServiceDbContext _dbContext;
    public AddRouteItemHandler(ILogger<AddRouteItemHandler> logger, SelfServiceDbContext dbContext) : base(logger)
    {
        _dbContext = dbContext;
    }


    public async Task<ServiceResult<RouteItem>> Handle(AddRouteItemCommand request, CancellationToken cancellationToken)
    {


        try
        {
            LogBeginRequest();

            _dbContext.RouteItems.Add(request.Entity);

            await _dbContext.SaveChangesAsync(cancellationToken);

            return new ServiceResult<RouteItem>(request.Entity);

        }
        catch (Exception ex)
        {
            LogException(ex, false);

            return new ServiceResult<RouteItem>(null)
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