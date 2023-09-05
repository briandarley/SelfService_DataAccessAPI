using UNC.Services.Criteria;
using UNC_SelfService_DataAccessAPI_Common.Entities.UtilityDb;

namespace UNC_SelfService_DataAccessAPI_Common.Criteria.UtilityDb
{
    public class OrganizationalUnitCriteria: BasePagingCriteria<OrganizationalUnit>
    {
        public int? Id { get; set; }
        public string Name { get; set; }
        public string DistinguishedName { get; set; }
        public string Department { get; set; }
        public string Ou { get; set; }
        public bool? IsRootOu { get; set; }
    }
}
