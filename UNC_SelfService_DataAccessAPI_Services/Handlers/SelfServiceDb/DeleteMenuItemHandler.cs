using Microsoft.EntityFrameworkCore;
using MediatR;
using UNC.Services.Responses;
using Microsoft.Extensions.Logging;
using UNC.Services;
using UNC_SelfService_DataAccessAPI_Common.Entities.SelfServiceDb;
using UNC_SelfService_DataAccessAPI_Repository;


namespace UNC_SelfService_DataAccessAPI_Services.SelfServiceDb;

public class DeleteMenuItemHandler : ServiceBase<DeleteMenuItemHandler>, IRequestHandler<DeleteMenuItemCommand, ServiceResult<bool>>
{
    private readonly SelfServiceDbContext _dbContext;
    public DeleteMenuItemHandler(ILogger<DeleteMenuItemHandler> logger, SelfServiceDbContext dbContext) : base(logger)
    {
        _dbContext = dbContext;
    }


    public async Task<ServiceResult<bool>> Handle(DeleteMenuItemCommand request, CancellationToken cancellationToken)
    {


        try
        {
            LogBeginRequest();

            _dbContext.MenuItems.Remove(await _dbContext.MenuItems.SingleAsync(c => c.Id == request.EntityId, cancellationToken));


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