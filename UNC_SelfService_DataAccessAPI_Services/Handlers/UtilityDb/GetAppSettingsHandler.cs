using MediatR;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using UNC.Extensions.General;
using UNC.Services;
using UNC_SelfService_DataAccessAPI_Common.Entities.UtilityDb;
using UNC_SelfService_DataAccessAPI_Repository;
using UNC_SelfService_DataAccessAPI_Services.Queries.UtilityDb;

namespace UNC_SelfService_DataAccessAPI_Services.Handlers.UtilityDb
{
    public class GetAppSettingsHandler : ServiceBase<GetAppSettingsHandler>, IRequestHandler<GetAppSettingsQuery, List<AppSetting>>
    {
        private readonly UtilityDbContext _dbContext;

        public GetAppSettingsHandler(ILogger<GetAppSettingsHandler> logger, UtilityDbContext dbContext) : base(logger)
        {
            _dbContext = dbContext;
        }

        public async Task<List<AppSetting>> Handle(GetAppSettingsQuery request, CancellationToken cancellationToken)
        {

                var query = _dbContext.AppSettings.AsNoTracking().AsQueryable();

                if (request.Criteria == null)
                {
                    return await query.ToListAsync(cancellationToken);
                }

                if (request.Criteria.Id.HasValue)
                {
                    query = query.Where(c => c.Id == request.Criteria.Id.Value);
                }

                if (!request.Criteria.Name.IsEmpty())
                {
                    query = query.Where(c => c.Name == request.Criteria.Name);
                }

                if (!request.Criteria.Filter.IsEmpty())
                {
                    query = query.Where(c => c.Name.Contains(request.Criteria.Filter));
                }

                if (!request.Criteria.AppDomain.IsEmpty())
                {
                    query = query.Where(c => c.AppDomain == request.Criteria.AppDomain);
                }

                return await query.ToListAsync(cancellationToken);

           
        }
    }
}
