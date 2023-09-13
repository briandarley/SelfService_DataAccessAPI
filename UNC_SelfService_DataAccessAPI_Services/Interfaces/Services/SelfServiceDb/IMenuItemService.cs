using UNC.Services.Responses;
using UNC_SelfService_DataAccessAPI_Common.Criteria.SelfServiceDb;
using UNC_SelfService_DataAccessAPI_Common.Entities.SelfServiceDb;

namespace UNC_SelfService_DataAccessAPI_Services.Interfaces.Services.SelfServiceDb
{
    public interface IMenuItemService
    {
        Task<ServiceResult<MenuItem>> AddMenuItem(MenuItem entity, CancellationToken cancellationToken);
        Task<ServiceResult<bool>> DeleteMenuItem(int entityId, CancellationToken cancellationToken);
        Task<ServiceResult<List<MenuItem>>> GetMenuItems(MenuItemCriteria criteria, CancellationToken cancellationToken);
        Task<ServiceResult<bool>> UpdateMenuItem(MenuItem entity, CancellationToken cancellationToken);
    }
}
