namespace UNC_SelfService_DataAccessAPI_Common.Entities.UtilityDb
{
    public class OrganizationalUnitAdmin:BaseEntity
    {
        public int Id { get; set; }
        public int OrganizationalUnitId { get; set; }
        public string SamAccountName { get; set; }
        public string Name { get; set; }
        public string Mail { get; set; }
        public string Phone { get; set; }
        public string Note { get; set; }

        public virtual OrganizationalUnit OrganizationalUnit { get; set; }
    }
}
