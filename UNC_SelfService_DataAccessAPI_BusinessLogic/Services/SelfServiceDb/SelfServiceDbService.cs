using Microsoft.Extensions.Logging;
using UNC.Services;
using UNC.Services.Responses;
using UNC_SelfService_DataAccessAPI_BusinessLogic.Interfaces.Services.SelfServiceDb;
using UNC_SelfService_DataAccessAPI_Common.Criteria.SelfServiceDb;
using UNC_SelfService_DataAccessAPI_Common.Entities.SelfServiceDb;

namespace UNC_SelfService_DataAccessAPI_BusinessLogic.Services.SelfServiceDb
{
    public class SelfServiceDbService : ServiceBase<SelfServiceDbService>, ISelfServiceDbService

    {
        private readonly UNC_SelfService_DataAccessAPI_Services.Interfaces.Services.SelfServiceDb.ISelfServiceDbService _service;

        public SelfServiceDbService(ILogger<SelfServiceDbService> logger, UNC_SelfService_DataAccessAPI_Services.Interfaces.Services.SelfServiceDb.ISelfServiceDbService service) : base(logger)
        {
            _service = service;
        }

        public Task<ServiceResult<List<RouteItem>>> GetRouteItems(RouteItemCriteria criteria, CancellationToken cancellationToken)
        {
            return _service.GetRouteItems(criteria, cancellationToken);
        }
        public Task<ServiceResult<RouteItem>> AddRouteItem(RouteItem entity, CancellationToken cancellationToken)
        {
            var validationErrors = ValidateModel(entity, out var isValid);

            if (!isValid)
            {
                return Task.FromResult(new ServiceResult<RouteItem>(null) { Errors = validationErrors.Select(c=> c.ErrorMessage).ToList() });
            }

            return _service.AddRouteItem(entity, cancellationToken);
        }
        public async Task<ServiceResult<bool>> UpdateRouteItem(RouteItem entity, CancellationToken cancellationToken)
        {
            var validationErrors = ValidateModel(entity, out var isValid);

            if (!isValid)
            {
                return new ServiceResult<bool>(false) { Errors = validationErrors.Select(c => c.ErrorMessage).ToList() };
            }

            var request = await _service.GetRouteItems(new RouteItemCriteria { Id = entity.Id }, cancellationToken);
            if (request.Success)
            {
                var appSetting = request.Data.FirstOrDefault();
                if (appSetting != null)
                {
                    return await _service.UpdateRouteItem(entity, cancellationToken);
                }
                else
                {
                    return new ServiceResult<bool>(false, "ResourceNotFound");
                }
            }
            return new ServiceResult<bool>(false) { Errors = request.Errors };
        }
        public async Task<ServiceResult<bool>> DeleteRouteItem(int entityId, CancellationToken cancellationToken)
        {

            var request = await _service.GetRouteItems(new RouteItemCriteria { Id = entityId }, cancellationToken);
            if (request.Success)
            {
                var appSetting = request.Data.FirstOrDefault();
                if (appSetting != null)
                {
                    return await _service.DeleteRouteItem(entityId, cancellationToken);
                }
                else
                {
                    return new ServiceResult<bool>(false, "ResourceNotFound");
                }
            }

            return new ServiceResult<bool>(false) { Errors = request.Errors };
        }

        public Task<ServiceResult<List<MenuItem>>> GetMenuItems(MenuItemCriteria criteria, CancellationToken cancellationToken)
        {
            return _service.GetMenuItems(criteria, cancellationToken);
        }
        public Task<ServiceResult<MenuItem>> AddMenuItem(MenuItem entity, CancellationToken cancellationToken)
        {
            var validationErrors = ValidateModel(entity, out var isValid);

            if (!isValid)
            {
                return Task.FromResult(new ServiceResult<MenuItem>(null) { Errors = validationErrors.Select(c=> c.ErrorMessage).ToList() });
            }

            return _service.AddMenuItem(entity, cancellationToken);
        }
        public async Task<ServiceResult<bool>> UpdateMenuItem(MenuItem entity, CancellationToken cancellationToken)
        {
            var validationErrors = ValidateModel(entity, out var isValid);

            if (!isValid)
            {
                return new ServiceResult<bool>(false) { Errors = validationErrors.Select(c => c.ErrorMessage).ToList() };
            }

            var request = await _service.GetMenuItems(new MenuItemCriteria { Id = entity.Id }, cancellationToken);
            if (request.Success)
            {
                var appSetting = request.Data.FirstOrDefault();
                if (appSetting != null)
                {
                    return await _service.UpdateMenuItem(entity, cancellationToken);
                }
                else
                {
                    return new ServiceResult<bool>(false, "ResourceNotFound");
                }
            }
            return new ServiceResult<bool>(false) { Errors = request.Errors };
        }
        public async Task<ServiceResult<bool>> DeleteMenuItem(int entityId, CancellationToken cancellationToken)
        {

            var request = await _service.GetMenuItems(new MenuItemCriteria { Id = entityId }, cancellationToken);
            if (request.Success)
            {
                var appSetting = request.Data.FirstOrDefault();
                if (appSetting != null)
                {
                    return await _service.DeleteMenuItem(entityId, cancellationToken);
                }
                else
                {
                    return new ServiceResult<bool>(false, "ResourceNotFound");
                }
            }

            return new ServiceResult<bool>(false) { Errors = request.Errors };
        }
    }
}
