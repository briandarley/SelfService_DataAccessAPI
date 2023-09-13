using UNC.Services.Responses;
using UNC_SelfService_DataAccessAPI_Common.Criteria.UtilityDb;
using UNC_SelfService_DataAccessAPI_Common.Entities.UtilityDb;

namespace UNC_SelfService_DataAccessAPI_BusinessLogic.Interfaces.Services.UtilityDb
{
    public interface IProcessService
    {
        Task<ServiceResult<Process>> AddProcess(Process entity, CancellationToken cancellationToken);
        Task<ServiceResult<bool>> UpdateProcess(Process entity, CancellationToken cancellationToken);
        Task<ServiceResult<bool>> DeleteProcess(int entityId, CancellationToken cancellationToken);
        
        Task<ServiceResult<List<Process>>> GetProcesses(ProcessCriteria criteria, CancellationToken cancellationToken);
    }
}
