using Microsoft.EntityFrameworkCore;
using MediatR;
using UNC.Services.Responses;
using Microsoft.Extensions.Logging;
using UNC.Services;
using UNC_SelfService_DataAccessAPI_Repository;


namespace UNC_SelfService_DataAccessAPI_Services.UtilityDb;

public class DeleteProcessHistoryHandler : ServiceBase<DeleteProcessHistoryHandler>, IRequestHandler<DeleteProcessHistoryCommand, ServiceResult<bool>>
{
    private readonly UtilityDbContext _dbContext;
    public DeleteProcessHistoryHandler(ILogger<DeleteProcessHistoryHandler> logger, UtilityDbContext dbContext) : base(logger)
    {
        _dbContext = dbContext;
    }


    public async Task<ServiceResult<bool>> Handle(DeleteProcessHistoryCommand request, CancellationToken cancellationToken)
    {
        try
        {
            LogBeginRequest();

            _dbContext.ProcessHistories.Remove(await _dbContext.ProcessHistories.SingleAsync(c => c.Id == request.EntityId, cancellationToken));


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