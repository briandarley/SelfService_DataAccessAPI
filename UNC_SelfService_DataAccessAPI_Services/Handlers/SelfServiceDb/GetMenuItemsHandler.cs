using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using MediatR;
using UNC.Services.Responses;
using UNC.Services;
using UNC.Extensions.General;
using UNC_SelfService_DataAccessAPI_Common.Entities.SelfServiceDb;
using UNC_SelfService_DataAccessAPI_Repository;


namespace UNC_SelfService_DataAccessAPI_Services.SelfServiceDb;

public class GetMenuItemsHandler : ServiceBase<GetMenuItemsHandler>, IRequestHandler<GetMenuItemsQuery, ServiceResult<List<MenuItem>>>
{
    private readonly SelfServiceDbContext _dbContext;
    public GetMenuItemsHandler(ILogger<GetMenuItemsHandler> logger, SelfServiceDbContext dbContext) : base(logger)
    {
        _dbContext = dbContext;
    }


    public async Task<ServiceResult<List<MenuItem>>> Handle(GetMenuItemsQuery request, CancellationToken cancellationToken)
    {

        try
        {
            LogBeginRequest();

            var query = _dbContext.MenuItems
                .Include(c => c.ParentMenuItem)
                .Include(c => c.RouteItem)
                .Include(c => c.RouteItem.RouteItemTags)
                .AsNoTracking().AsQueryable();


            if (request.Criteria == null)
            {
                return new ServiceResult<List<MenuItem>>(await query.ToListAsync(cancellationToken));
            }

            if (request.Criteria.Id.HasValue)
            {
                query = query.Where(c => c.Id == request.Criteria.Id.Value);
            }

            if (request.Criteria.ParentId.HasValue)
            {
                query = query.Where(c => c.ParentMenuItemId == request.Criteria.ParentId.Value);
            }

            if (request.Criteria.MenuText.HasValue())
            {
                query = query.Where(c => c.MenuText == request.Criteria.MenuText);
            }

            if (request.Criteria.Category.HasValue())
            {
                query = query.Where(c => c.Category == request.Criteria.Category);
            }

            if (request.Criteria.Filter.HasValue())
            {
                // Common filter conditions
                IQueryable<MenuItem> ApplyCommonFilter(IQueryable<MenuItem> inputQuery)
                {
                    return inputQuery.Where(c =>
                        SelfServiceDbContext.Soundex(c.MenuText) == SelfServiceDbContext.Soundex(request.Criteria.Filter)
                        || SelfServiceDbContext.Soundex(c.Category) == SelfServiceDbContext.Soundex(request.Criteria.Filter)
                        || c.RouteItem.RouteItemTags.Any(tag => SelfServiceDbContext.Soundex(tag.Tag) == SelfServiceDbContext.Soundex(request.Criteria.Filter)));
                }

                query = ApplyCommonFilter(query);

                if (request.Criteria.Filter.IsNumeric())
                {
                    var number = int.TryParse(request.Criteria.Filter, out var num) ? num : 0;
                    query = query.Where(c => c.Id == number || c.ParentMenuItemId == number);
                }


            }


            return new ServiceResult<List<MenuItem>>(await query.ToListAsync(cancellationToken));

        }
        catch (Exception ex)
        {
            LogException(ex, false);

            return new ServiceResult<List<MenuItem>>(null)
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