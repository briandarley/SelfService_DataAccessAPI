using MediatR;
using UNC.Services.Responses;
using UNC.Services;
using Microsoft.Extensions.Logging;
using UNC_SelfService_DataAccessAPI_Common.Entities.UtilityDb;
using UNC_SelfService_DataAccessAPI_Repository;
using Microsoft.EntityFrameworkCore;
using UNC.Extensions.General;
using UNC.Services.Enums;
using UNC.Extensions.Data;
namespace UNC_SelfService_DataAccessAPI_Services.UtilityDb;

    public class GetOrganizationalUnitsHandler : ServiceBase<GetOrganizationalUnitsHandler>, IRequestHandler<GetOrganizationalUnitsQuery, ServiceResult<PagedResponse<OrganizationalUnit>>>
    {
        private readonly UtilityDbContext _dbContext;
        public GetOrganizationalUnitsHandler(ILogger<GetOrganizationalUnitsHandler> logger, UtilityDbContext dbContext) : base(logger)
        {
            _dbContext = dbContext;
        }


         public async Task<ServiceResult<PagedResponse<OrganizationalUnit>>> Handle(GetOrganizationalUnitsQuery request, CancellationToken cancellationToken)
         {

            try
            {
                LogBeginRequest();

            var query = _dbContext.OrganizationalUnits.AsNoTracking().Include(c => c.OrganizationalUnitAdmins).AsQueryable();


            if (request.Criteria.Id.HasValue)
            {
                query = query.Where(c => c.Id == request.Criteria.Id.Value);
            }
            if (request.Criteria.Name.HasValue())
            {
                query = query.Where(c => c.Name == request.Criteria.Name);
            }
            if (request.Criteria.DistinguishedName.HasValue())
            {
                query = query.Where(c => c.DistinguishedName == request.Criteria.DistinguishedName);
            }
            if (request.Criteria.Department.HasValue())
            {
                query = query.Where(c => c.Department == request.Criteria.Department);
            }
            if (request.Criteria.Ou.HasValue())
            {
                query = query.Where(c => c.Ou == request.Criteria.Ou);
            }
            if (request.Criteria.IsRootOu.HasValue)
            {
                query = query.Where(c => c.IsRootOu == request.Criteria.IsRootOu.Value);

            }



            if (request.Criteria.FilterText.HasValue())
            {
                query = query.Where(c =>
                    c.Name == request.Criteria.FilterText
                    || c.Department == request.Criteria.FilterText
                    || c.DistinguishedName == request.Criteria.FilterText
                    || c.Ou.Contains(request.Criteria.FilterText));
            }


            var pagedResponse = new PagedResponse<OrganizationalUnit>
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


            return new ServiceResult<PagedResponse<OrganizationalUnit>>(pagedResponse);

        }
            catch (Exception ex)
            {
                LogException(ex, false);
				
				return new ServiceResult<PagedResponse<OrganizationalUnit>>(null){
					 Errors = new List<string>{ex.Message}
				};
            }
            finally
            {
                LogEndRequest();
            }

         }

    }