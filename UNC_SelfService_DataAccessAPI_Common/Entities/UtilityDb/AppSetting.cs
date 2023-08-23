namespace UNC_SelfService_DataAccessAPI_Common.Entities.UtilityDb
{
    public class AppSetting: BaseEntity
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Value { get; set; }
        public string Description { get; set; }
        public string OverLoad { get; set; }
        public string AppDomain { get; set; }
        
    }
}
