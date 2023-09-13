using Microsoft.Extensions.Logging;
using UNC.Services;
using UNC.Services.Enums;
using UNC.Services.Responses;
using UNC_SelfService_DataAccessAPI_BusinessLogic.Interfaces.Services.UtilityDb;
using UNC_SelfService_DataAccessAPI_Common.Criteria.UtilityDb;
using UNC_SelfService_DataAccessAPI_Common.Entities.UtilityDb;
using ResponseCodes = UNC.Models.Constants.ResponseCodes;
namespace UNC_SelfService_DataAccessAPI_BusinessLogic.Services.UtilityDb
{
    public class UtilityDbService : ServiceBase<UtilityDbService>, IUtilityDbService
    {
        private readonly UNC_SelfService_DataAccessAPI_Services.Interfaces.Services.UtilityDb.IUtilityDbService _service;

        public UtilityDbService(ILogger<UtilityDbService> logger, UNC_SelfService_DataAccessAPI_Services.Interfaces.Services.UtilityDb.IUtilityDbService service) : base(logger)
        {
            _service = service;
        }

        public Task<ServiceResult<List<AppSetting>>> GetAppSettings(AppSettingsCriteria criteria, CancellationToken cancellationToken)
        {
            return _service.GetAppSettings(criteria, cancellationToken);
        }
        public Task<ServiceResult<AppSetting>> AddAppSetting(AppSetting entity, CancellationToken cancellationToken)
        {
            var validationErrors = ValidateModel(entity, out var isValid);

            if (!isValid)
            {
                return Task.FromResult(new ServiceResult<AppSetting>(null) { Errors = validationErrors.Select(c => c.ErrorMessage).ToList() });
            }

            return _service.AddAppSetting(entity, cancellationToken);
        }
        public async Task<ServiceResult<bool>> UpdateAppSetting(AppSetting entity, CancellationToken cancellationToken)
        {
            var validationErrors = ValidateModel(entity, out var isValid);

            if (!isValid)
            {
                return new ServiceResult<bool>(false) { Errors = validationErrors.Select(c => c.ErrorMessage).ToList() };
            }

            var request = await _service.GetAppSettings(new AppSettingsCriteria { Id = entity.Id }, cancellationToken);
            if (request.Success)
            {
                var appSetting = request.Data.FirstOrDefault();
                if (appSetting != null)
                {
                    appSetting.Value = entity.Value;
                    return await _service.UpdateAppSetting(appSetting, cancellationToken);
                }
                else
                {
                    return new ServiceResult<bool>(false, ResponseCodes.ResourceNotFound);
                }
            }
            return new ServiceResult<bool>(false) { Errors = request.Errors };
        }
        public async Task<ServiceResult<bool>> DeleteAppSetting(int entityId, CancellationToken cancellationToken)
        {

            var request = await _service.GetAppSettings(new AppSettingsCriteria { Id = entityId }, cancellationToken);
            if (request.Success)
            {
                var appSetting = request.Data.FirstOrDefault();
                if (appSetting != null)
                {
                    return await _service.DeleteAppSetting(entityId, cancellationToken);
                }
                else
                {
                    return new ServiceResult<bool>(false, ResponseCodes.ResourceNotFound);
                }
            }

            return new ServiceResult<bool>(false) { Errors = request.Errors };
        }

        public Task<ServiceResult<List<ApiEndpoint>>> GetApiEndpoints(ApiEndpointCriteria criteria, CancellationToken cancellationToken)
        {
            return _service.GetApiEndpoints(criteria, cancellationToken);
        }

        public Task<ServiceResult<ApiEndpoint>> AddApiEndpoint(ApiEndpoint entity, CancellationToken cancellationToken)
        {
            var validationErrors = ValidateModel(entity, out var isValid);

            if (!isValid)
            {
                return Task.FromResult(new ServiceResult<ApiEndpoint>(null) { Errors = validationErrors.Select(c => c.ErrorMessage).ToList() });
            }
            return _service.AddApiEndpoint(entity, cancellationToken);
        }

        public Task<ServiceResult<bool>> UpdateApiEndpoint(ApiEndpoint entity, CancellationToken cancellationToken)
        {
            var validationErrors = ValidateModel(entity, out var isValid);

            if (!isValid)
            {
                return Task.FromResult(new ServiceResult<bool>(false) { Errors = validationErrors.Select(c => c.ErrorMessage).ToList() });
            }

            return _service.UpdateApiEndpoint(entity, cancellationToken);
        }

        public Task<ServiceResult<bool>> DeleteApiEndpoint(int entityId, CancellationToken cancellationToken)
        {
            return _service.DeleteApiEndpoint(entityId, cancellationToken);
        }

        public Task<ServiceResult<PagedResponse<OrganizationalUnit>>> GetOrganizationalUnits(OrganizationalUnitCriteria criteria, CancellationToken cancellationToken)
        {
            return _service.GetOrganizationalUnits(criteria, cancellationToken);
        }
        public Task<ServiceResult<OrganizationalUnit>> AddOrganizationalUnit(OrganizationalUnit entity, CancellationToken cancellationToken)
        {
            var validationErrors = ValidateModel(entity, out var isValid);

            if (!isValid)
            {
                return Task.FromResult(new ServiceResult<OrganizationalUnit>(null) { Errors = validationErrors.Select(c => c.ErrorMessage).ToList() });
            }

            return _service.AddOrganizationalUnit(entity, cancellationToken);
        }
        public async Task<ServiceResult<bool>> UpdateOrganizationalUnit(OrganizationalUnit entity, CancellationToken cancellationToken)
        {
            var validationErrors = ValidateModel(entity, out var isValid);

            if (!isValid)
            {
                return new ServiceResult<bool>(false) { Errors = validationErrors.Select(c => c.ErrorMessage).ToList() };
            }

            var request = await _service.GetOrganizationalUnits(new OrganizationalUnitCriteria { Id = entity.Id }, cancellationToken);
            if (request.Success)
            {
                if (request.Data.TotalRecords != 1)
                {
                    return new ServiceResult<bool>(false, ResponseCodes.ResourceNotFound);
                }
                return await _service.UpdateOrganizationalUnit(entity, cancellationToken);
            }
            return new ServiceResult<bool>(false) { Errors = request.Errors };
        }
        public async Task<ServiceResult<bool>> DeleteOrganizationalUnit(int entityId, CancellationToken cancellationToken)
        {

            var request = await _service.GetOrganizationalUnits(new OrganizationalUnitCriteria { Id = entityId }, cancellationToken);
            if (request.Success)
            {
                if (request.Data.TotalRecords != 1)
                {
                    return new ServiceResult<bool>(false, ResponseCodes.ResourceNotFound);
                }

                return await _service.DeleteOrganizationalUnit(entityId, cancellationToken);
            }

            return new ServiceResult<bool>(false) { Errors = request.Errors };
        }

        public async Task<ServiceResult<List<OrganizationalUnitAdmin>>> GetOrganizationalUnitAdmins(OrganizationalUnitAdminCriteria criteria, CancellationToken cancellationToken)
        {
            var request = await _service.GetOrganizationalUnits(new OrganizationalUnitCriteria { Id = criteria.OrganizationalUnitId }, cancellationToken);
            if (request.Success)
            {
                if (request.Data.TotalRecords != 1)
                {
                    return new ServiceResult<List<OrganizationalUnitAdmin>>(null)
                    {
                        Errors = new List<string> { ResponseCodes.ResourceNotFound }
                    };
                }
            }


            return await _service.GetOrganizationalUnitAdmins(criteria, cancellationToken);
        }

        public Task<ServiceResult<List<Process>>> GetProcesses(ProcessCriteria criteria, CancellationToken cancellationToken)
        {
            return _service.GetProcesses(criteria, cancellationToken);
        }
        public Task<ServiceResult<Process>> AddProcess(Process entity, CancellationToken cancellationToken)
        {
            var validationErrors = ValidateModel(entity, out var isValid);

            if (!isValid)
            {
                return Task.FromResult(new ServiceResult<Process>(null) { Errors = validationErrors.Select(c => c.ErrorMessage).ToList() });
            }

            return _service.AddProcess(entity, cancellationToken);
        }
        public async Task<ServiceResult<bool>> UpdateProcess(Process entity, CancellationToken cancellationToken)
        {
            var validationErrors = ValidateModel(entity, out var isValid);

            if (!isValid)
            {
                return new ServiceResult<bool>(false) { Errors = validationErrors.Select(c => c.ErrorMessage).ToList() };
            }

            var request = await _service.GetProcesses(new ProcessCriteria { Id = entity.Id }, cancellationToken);
            if (request.Success)
            {
                var appSetting = request.Data.FirstOrDefault();

                if (appSetting != null)
                {
                    return await _service.UpdateProcess(entity, cancellationToken);
                }
                else
                {
                    return new ServiceResult<bool>(false, ResponseCodes.ResourceNotFound);
                }
            }
            return new ServiceResult<bool>(false) { Errors = request.Errors };
        }
        public async Task<ServiceResult<bool>> DeleteProcess(int entityId, CancellationToken cancellationToken)
        {

            var request = await _service.GetProcesses(new ProcessCriteria { Id = entityId }, cancellationToken);
            if (request.Success)
            {
                var appSetting = request.Data.FirstOrDefault();
                if (appSetting != null)
                {
                    return await _service.DeleteProcess(entityId, cancellationToken);
                }
                else
                {
                    return new ServiceResult<bool>(false, ResponseCodes.ResourceNotFound);
                }
            }

            return new ServiceResult<bool>(false) { Errors = request.Errors };
        }

        public Task<ServiceResult<PagedResponse<ProcessHistory>>> GetProcessHistories(ProcessHistoryCriteria criteria, CancellationToken cancellationToken)
        {
            if (criteria is null)
            {
                return Task.FromResult(new ServiceResult<PagedResponse<ProcessHistory>>(null)
                {
                    Errors = new List<string> { "InvalidRequest","Criteria too vague", "Too many records returned" }
                });
            }
            if (!criteria.PageSize.HasValue)
            {
                criteria.PageSize = 100;
                criteria.Index = 0;
                criteria.ListSortDirection = ListSortDirection.Descending;
                criteria.Sort = nameof(ProcessHistory.StartDate);
            }
            return _service.GetProcessHistories(criteria, cancellationToken);
        }
        public Task<ServiceResult<ProcessHistory>> AddProcessHistory(ProcessHistory entity, CancellationToken cancellationToken)
        {
            var validationErrors = ValidateModel(entity, out var isValid);

            if (!isValid)
            {
                return Task.FromResult(new ServiceResult<ProcessHistory>(null) { Errors = validationErrors.Select(c => c.ErrorMessage).ToList() });
            }

            return _service.AddProcessHistory(entity, cancellationToken);
        }
        public async Task<ServiceResult<bool>> UpdateProcessHistory(ProcessHistory entity, CancellationToken cancellationToken)
        {
            var validationErrors = ValidateModel(entity, out var isValid);

            if (!isValid)
            {
                return new ServiceResult<bool>(false) { Errors = validationErrors.Select(c => c.ErrorMessage).ToList() };
            }

            var request = await _service.GetProcessHistories(new ProcessHistoryCriteria { Id = entity.Id }, cancellationToken);

            if (request.Success && request.Data.TotalRecords == 1)
            {
                return await _service.UpdateProcessHistory(entity, cancellationToken);
            }
            else if (request.Success)
            {
                return new ServiceResult<bool>(false, ResponseCodes.ResourceNotFound);
            }

            return new ServiceResult<bool>(false)
            {
                Errors = request.Errors
            };
        }
        public async Task<ServiceResult<bool>> DeleteProcessHistory(int entityId, CancellationToken cancellationToken)
        {

            var request = await _service.GetProcessHistories(new ProcessHistoryCriteria { Id = entityId }, cancellationToken);
            if (request.Success && request.Data.TotalRecords == 1)
            {
                return await _service.DeleteProcessHistory(entityId, cancellationToken);
            }
            else if (request.Success)
            {
                return new ServiceResult<bool>(false, ResponseCodes.ResourceNotFound);
            }

            return new ServiceResult<bool>(false) { Errors = request.Errors };
        }

    }
}
