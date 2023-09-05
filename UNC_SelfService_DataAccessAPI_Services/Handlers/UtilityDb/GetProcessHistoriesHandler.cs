using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using MediatR;
using UNC.Services.Responses;
using UNC.Services;
using UNC.Extensions.General;
using UNC_SelfService_DataAccessAPI_Common.Entities.UtilityDb;
using UNC_SelfService_DataAccessAPI_Repository;
using UNC.Services.Enums;
using UNC.Extensions.Data;
namespace UNC_SelfService_DataAccessAPI_Services.UtilityDb;

public class GetProcessHistoriesHandler : ServiceBase<GetProcessHistoriesHandler>, IRequestHandler<GetProcessHistoriesQuery, ServiceResult<PagedResponse<ProcessHistory>>>
{
    private readonly UtilityDbContext _dbContext;
    public GetProcessHistoriesHandler(ILogger<GetProcessHistoriesHandler> logger, UtilityDbContext dbContext) : base(logger)
    {
        _dbContext = dbContext;
    }


    public async Task<ServiceResult<PagedResponse<ProcessHistory>>> Handle(GetProcessHistoriesQuery request, CancellationToken cancellationToken)
    {

        try
        {
            LogBeginRequest();

            var query = _dbContext.ProcessHistories.AsNoTracking().AsQueryable();


            if (request.Criteria.Id.HasValue)
            {
                query = query.Where(c => c.Id == request.Criteria.Id.Value);
            }

            if (request.Criteria.Failed.HasValue)
            {
                query = query.Where(c => c.Failed == request.Criteria.Failed);
            }

            if (request.Criteria.MachineName.HasValue())
            {
                query = query.Where(c => c.MachineName == request.Criteria.MachineName);
            }

            if (request.Criteria.Source.HasValue())
            {
                query = query.Where(c => c.Source == request.Criteria.Source);
            }

            if (request.Criteria.StartDateFrom.HasValue && !request.Criteria.StartDateThru.HasValue)
            {
                query = query.Where(c => c.StartDate.Date == request.Criteria.StartDateFrom.Value);
            }
            else if (request.Criteria.StartDateFrom.HasValue)
            {
                query = query.Where(c => c.StartDate.Date >= request.Criteria.StartDateFrom.Value);
            }
            if (request.Criteria.StartDateThru.HasValue)
            {
                query = query.Where(c => c.StartDate.Date <= request.Criteria.StartDateThru.Value);
            }

            if (request.Criteria.FilterText.HasValue())
            {
                query = query.Where(c => c.MachineName == request.Criteria.FilterText || c.Name == request.Criteria.FilterText || c.Source == request.Criteria.FilterText || c.Arguments.Contains(request.Criteria.FilterText));
            }


            var pagedResponse = new PagedResponse<ProcessHistory>
            {
                TotalRecords = await query.CountAsync(cancellationToken),
                Index = request.Criteria.Index ?? 0,
                PageSize = request.Criteria.PageSize ?? 0
            };


            var sortDirection = request.Criteria.ListSortDirection ?? ListSortDirection.Ascending;

            if (request.Criteria.Sort.IsEmpty())
            {
                request.Criteria.Sort = "Id";
            }


            query = sortDirection == ListSortDirection.Descending
                ? query.OrderByDescending(request.Criteria.Sort)
                : query.OrderBy(request.Criteria.Sort);



            if (request.Criteria.PageSize.HasValue && request.Criteria.Index.HasValue)
            {
                query = query.Skip(request.Criteria.Index.Value * request.Criteria.PageSize.Value).Take(request.Criteria.PageSize.Value);
            }


            var records = await query.ToListAsync(cancellationToken);

            pagedResponse.Entities = records;

            return new ServiceResult<PagedResponse<ProcessHistory>>(pagedResponse);

        }
        catch (Exception ex)
        {
            LogException(ex, false);

            return new ServiceResult<PagedResponse<ProcessHistory>>(null)
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