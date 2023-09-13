using UNC.Services.Criteria;
using UNC_SelfService_DataAccessAPI_Common.Entities.SelfServiceDb;

namespace UNC_SelfService_DataAccessAPI_Common.Criteria.SelfServiceDb;

public class MenuItemCriteria : BaseCriteria<MenuItem>
{
    public int? Id { get; set; }
    public int? ParentId { get; set; }
    public string MenuText { get; set; }
    public string Category { get; set; }
    public string Filter { get; set; }

}
