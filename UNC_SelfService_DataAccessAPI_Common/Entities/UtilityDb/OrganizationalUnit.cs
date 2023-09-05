namespace UNC_SelfService_DataAccessAPI_Common.Entities.UtilityDb
{
    public class OrganizationalUnit : BaseEntity
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string DistinguishedName { get; set; }
        public string OuAdminGroup { get; set; }
        public string Department { get; set; }
        public string ObjectCategory { get; set; }
        public string Ou { get; set; }
        public string AdsPath { get; set; }
        public string ObjectGuid { get; set; }
        public bool IsRootOu { get; set; }

        public virtual ICollection<OrganizationalUnitAdmin> OrganizationalUnitAdmins { get; set; }
    }
}
