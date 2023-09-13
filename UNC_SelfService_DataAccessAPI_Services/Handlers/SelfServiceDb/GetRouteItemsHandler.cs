using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using MediatR;
using UNC.Services.Responses;
using UNC.Services;
using UNC.Extensions.General;
using UNC_SelfService_DataAccessAPI_Common.Entities.SelfServiceDb;
using UNC_SelfService_DataAccessAPI_Repository;


namespace UNC_SelfService_DataAccessAPI_Services.SelfServiceDb;

public class GetRouteItemsHandler : ServiceBase<GetRouteItemsHandler>, IRequestHandler<GetRouteItemsQuery, ServiceResult<List<RouteItem>>>
{
    private readonly SelfServiceDbContext _dbContext;
    public GetRouteItemsHandler(ILogger<GetRouteItemsHandler> logger, SelfServiceDbContext dbContext) : base(logger)
    {
        _dbContext = dbContext;
    }


    public async Task<ServiceResult<List<RouteItem>>> Handle(GetRouteItemsQuery request, CancellationToken cancellationToken)
    {

        try
        {
            LogBeginRequest();


            var query = _dbContext.RouteItems
                .Include(c => c.RouteItemTags)
                .AsNoTracking().AsQueryable();


            if (request.Criteria == null)
            {
                return new ServiceResult<List<RouteItem>>(await query.ToListAsync(cancellationToken));
            }

            if (request.Criteria.Id.HasValue)
            {
                query = query.Where(c => c.Id == request.Criteria.Id.Value);
            }

            if (request.Criteria.Route.HasValue())
            {
                query = query.Where(c => c.Route == request.Criteria.Route);
            }

            if (request.Criteria.LinkText.HasValue())
            {
                query = query.Where(c => c.LinkText == request.Criteria.LinkText);
            }
            if (request.Criteria.RequireAuth.HasValue)
            {
                query = query.Where(c => c.RequireAuth == request.Criteria.RequireAuth.Value);
            }
            if (request.Criteria.RequireMfa.HasValue)
            {
                query = query.Where(c => c.RequireMfa == request.Criteria.RequireMfa.Value);
            }
            if (request.Criteria.Searchable.HasValue)
            {
                query = query.Where(c => c.Searchable == request.Criteria.Searchable.Value);
            }
            else
            {
                query = query.Where(c => c.Searchable == true);
            }


            if (request.Criteria.Filter.HasValue())
            {
                if (request.Criteria.Filter.IsNumeric())
                {
                    var number = int.TryParse(request.Criteria.Filter, out var num) ? num : 0;
                    query = query.Where(c => c.Id == number);
                }
                query = query.Where(c => SelfServiceDbContext.Soundex(c.LinkText) == SelfServiceDbContext.Soundex(request.Criteria.Filter));
                query = query.Where(c => c.Description.Contains(request.Criteria.Filter));
                query = query.Where(c => c.RouteItemTags.Any(tag => SelfServiceDbContext.Soundex(tag.Tag) == SelfServiceDbContext.Soundex(request.Criteria.Filter)));
            }


            return new ServiceResult<List<RouteItem>>(await query.ToListAsync(cancellationToken));

        }
        catch (Exception ex)
        {
            LogException(ex, false);

            return new ServiceResult<List<RouteItem>>(null)
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