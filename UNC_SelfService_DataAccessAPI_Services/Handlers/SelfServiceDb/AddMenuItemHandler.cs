using Microsoft.EntityFrameworkCore;
using MediatR;
using UNC.Services.Responses;
using Microsoft.Extensions.Logging;
using UNC.Services;
using UNC_SelfService_DataAccessAPI_Common.Entities.SelfServiceDb;
using UNC_SelfService_DataAccessAPI_Repository;


namespace UNC_SelfService_DataAccessAPI_Services.SelfServiceDb;

public class AddMenuItemHandler : ServiceBase<AddMenuItemHandler>, IRequestHandler<AddMenuItemCommand, ServiceResult<MenuItem>>
{
    private readonly SelfServiceDbContext _dbContext;
    public AddMenuItemHandler(ILogger<AddMenuItemHandler> logger, SelfServiceDbContext dbContext) : base(logger)
    {
        _dbContext = dbContext;
    }


    public async Task<ServiceResult<MenuItem>> Handle(AddMenuItemCommand request, CancellationToken cancellationToken)
    {


        try
        {
            LogBeginRequest();

            _dbContext.MenuItems.Add(request.Entity);

            await _dbContext.SaveChangesAsync(cancellationToken);

            return new ServiceResult<MenuItem>(request.Entity);

        }
        catch (Exception ex)
        {
            LogException(ex, false);

            return new ServiceResult<MenuItem>(null)
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