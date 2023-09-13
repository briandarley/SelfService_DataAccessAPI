using MediatR;
using UNC.Services.Responses;
using UNC_SelfService_DataAccessAPI_Common.Criteria.SelfServiceDb;
using UNC_SelfService_DataAccessAPI_Common.Entities.SelfServiceDb;

namespace UNC_SelfService_DataAccessAPI_Services.SelfServiceDb;

public class GetMenuItemsQuery : IRequest<ServiceResult<List<MenuItem>>>
{
    public MenuItemCriteria Criteria { get; }

    public GetMenuItemsQuery(MenuItemCriteria criteria)
    {
        Criteria = criteria;
    }
}