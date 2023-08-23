namespace UNC_SelfService_DataAccessAPI_Common.Entities.UtilityDb
{
    public class ApiEndpoint:BaseEntity
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string Notes { get; set; }
        public string Uri { get; set; }
        public string Environment { get; set; }
    }
}
