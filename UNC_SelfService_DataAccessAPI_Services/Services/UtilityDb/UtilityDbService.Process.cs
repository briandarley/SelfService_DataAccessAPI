using UNC.Services.Responses;
using UNC_SelfService_DataAccessAPI_Common.Criteria.UtilityDb;
using UNC_SelfService_DataAccessAPI_Common.Entities.UtilityDb;
using UNC_SelfService_DataAccessAPI_Services.UtilityDb;

namespace UNC_SelfService_DataAccessAPI_Services.Services.UtilityDb
{
    public partial class UtilityDbService
    {
        public async Task<ServiceResult<List<Process>>> GetProcesses(ProcessCriteria criteria, CancellationToken cancellationToken)
        {
            return await _mediator.Send(new GetProcessesQuery(criteria), cancellationToken);
        }

        public async Task<ServiceResult<bool>> DeleteProcess(int entityId, CancellationToken cancellationToken)
        {
            return await _mediator.Send(new DeleteProcessCommand(entityId), cancellationToken);
        }

        public async Task<ServiceResult<Process>> AddProcess(Process entity, CancellationToken cancellationToken)
        {
            return await _mediator.Send(new AddProcessCommand(entity), cancellationToken);
        }

        public async Task<ServiceResult<bool>> UpdateProcess(Process entity, CancellationToken cancellationToken)
        {
            return await _mediator.Send(new UpdateProcessCommand(entity), cancellationToken);
        }

        public async Task<ServiceResult<PagedResponse<ProcessHistory>>> GetProcessHistories(ProcessHistoryCriteria criteria, CancellationToken cancellationToken)
        {
            return await _mediator.Send(new GetProcessHistoriesQuery(criteria), cancellationToken);
        }

        public async Task<ServiceResult<bool>> DeleteProcessHistory(int entityId, CancellationToken cancellationToken)
        {
            return await _mediator.Send(new DeleteProcessHistoryCommand(entityId), cancellationToken);
        }

        public async Task<ServiceResult<ProcessHistory>> AddProcessHistory(ProcessHistory entity, CancellationToken cancellationToken)
        {
            return await _mediator.Send(new AddProcessHistoryCommand(entity), cancellationToken);
        }

        public async Task<ServiceResult<bool>> UpdateProcessHistory(ProcessHistory entity, CancellationToken cancellationToken)
        {
            return await _mediator.Send(new UpdateProcessHistoryCommand(entity), cancellationToken);
        }
    }
}


