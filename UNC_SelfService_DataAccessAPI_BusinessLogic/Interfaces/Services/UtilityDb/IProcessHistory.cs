using UNC.Services.Responses;
using UNC_SelfService_DataAccessAPI_Common.Criteria.UtilityDb;
using UNC_SelfService_DataAccessAPI_Common.Entities.UtilityDb;

namespace UNC_SelfService_DataAccessAPI_BusinessLogic.Interfaces.Services.UtilityDb
{
    public interface IProcessHistory
    {
        Task<ServiceResult<PagedResponse<ProcessHistory>>> GetProcessHistories(ProcessHistoryCriteria criteria, CancellationToken cancellationToken);
        
        Task<ServiceResult<ProcessHistory>> AddProcessHistory(ProcessHistory entity, CancellationToken cancellationToken);
        Task<ServiceResult<bool>> DeleteProcessHistory(int entityId, CancellationToken cancellationToken);
        Task<ServiceResult<bool>> UpdateProcessHistory(ProcessHistory entity, CancellationToken cancellationToken);
    }
}
