using UNC.Services.Attributes;
using UNC.Services.Criteria;
using UNC_SelfService_DataAccessAPI_Common.Entities.UtilityDb;

namespace UNC_SelfService_DataAccessAPI_Common.Criteria.UtilityDb
{
    public class OrganizationalUnitAdminCriteria:BaseCriteria<OrganizationalUnitAdmin>
    {
        [SwaggerExclude]
        public string OuName { get; set; }
        public int? Id { get; set; }
        public int? OrganizationalUnitId { get; set; }
        public string SamAccountName { get; set; }
    }
}
