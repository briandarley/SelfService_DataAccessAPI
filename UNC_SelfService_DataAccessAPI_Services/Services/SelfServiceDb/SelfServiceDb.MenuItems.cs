using UNC.Services.Responses;
using UNC_SelfService_DataAccessAPI_Common.Criteria.SelfServiceDb;
using UNC_SelfService_DataAccessAPI_Common.Entities.SelfServiceDb;
using UNC_SelfService_DataAccessAPI_Services.SelfServiceDb;

namespace UNC_SelfService_DataAccessAPI_Services.Services.SelfServiceDb;

public partial class SelfServiceDbService
{
    public async Task<ServiceResult<List<MenuItem>>> GetMenuItems(MenuItemCriteria criteria, CancellationToken cancellationToken)
    {
        return await _mediator.Send(new GetMenuItemsQuery(criteria), cancellationToken);
    }

    public async Task<ServiceResult<bool>> DeleteMenuItem(int entityId, CancellationToken cancellationToken)
    {
        return await _mediator.Send(new DeleteMenuItemCommand(entityId), cancellationToken);
    }

    public async Task<ServiceResult<MenuItem>> AddMenuItem(MenuItem entity, CancellationToken cancellationToken)
    {
        return await _mediator.Send(new AddMenuItemCommand(entity), cancellationToken);
    }

    public async Task<ServiceResult<bool>> UpdateMenuItem(MenuItem entity, CancellationToken cancellationToken)
    {
        return await _mediator.Send(new UpdateMenuItemCommand(entity), cancellationToken);
    }
}
