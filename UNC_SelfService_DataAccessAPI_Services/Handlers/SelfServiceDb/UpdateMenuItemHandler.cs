using MediatR;
using UNC.Services.Responses;
using Microsoft.Extensions.Logging;
using UNC.Services;
using UNC_SelfService_DataAccessAPI_Repository;


namespace UNC_SelfService_DataAccessAPI_Services.SelfServiceDb;

public class UpdateMenuItemHandler : ServiceBase<UpdateMenuItemHandler>, IRequestHandler<UpdateMenuItemCommand, ServiceResult<bool>>
{
    private readonly SelfServiceDbContext _dbContext;
    public UpdateMenuItemHandler(ILogger<UpdateMenuItemHandler> logger, SelfServiceDbContext dbContext) : base(logger)
    {
        _dbContext = dbContext;
    }


    public async Task<ServiceResult<bool>> Handle(UpdateMenuItemCommand request, CancellationToken cancellationToken)
    {


        try
        {
            LogBeginRequest();

            _dbContext.MenuItems.Update(request.Entity);

            await _dbContext.SaveChangesAsync(cancellationToken);

            return new ServiceResult<bool>(true);

        }
        catch (Exception ex)
        {
            LogException(ex, false);

            return new ServiceResult<bool>(false)
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