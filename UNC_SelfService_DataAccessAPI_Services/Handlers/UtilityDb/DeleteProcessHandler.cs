using MediatR;
using UNC.Services.Responses;
using Microsoft.Extensions.Logging;
using UNC.Services;
using UNC_SelfService_DataAccessAPI_Repository;
using Microsoft.EntityFrameworkCore;

namespace UNC_SelfService_DataAccessAPI_Services.UtilityDb;

public class DeleteProcessHandler : ServiceBase<DeleteProcessHandler>, IRequestHandler<DeleteProcessCommand, ServiceResult<bool>>
{
    private readonly UtilityDbContext _dbContext;
    public DeleteProcessHandler(ILogger<DeleteProcessHandler> logger, UtilityDbContext dbContext) : base(logger)
    {
        _dbContext = dbContext;
    }


    public async Task<ServiceResult<bool>> Handle(DeleteProcessCommand request, CancellationToken cancellationToken)
    {
        try
        {
            LogBeginRequest();

            _dbContext.Processes.Remove(await _dbContext.Processes.SingleAsync(c => c.Id == request.EntityId, cancellationToken));


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